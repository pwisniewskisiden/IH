using BusinessLogic.SyncronXL;
using DAL.Context;
using DAL.FTP;
using DAL.IOFile;
using DAL.Model;
using InterHandler.Jobs;
using Quartz;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Jobs
{
    [DisallowConcurrentExecution]
    public class OrderExportJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("OrderExport Iteruje dla OrderExport");

                string host = ConfigurationManager.AppSettings["FtpHostSyncToXL"].ToString();
                string username = ConfigurationManager.AppSettings["UserSyncToXL"].ToString();
                string pass = ConfigurationManager.AppSettings["PasswdSyncToXL"].ToString();
                var ftp = new FTP(host, username, pass);

                string outLocal = ConfigurationManager.AppSettings["LocalOUTPathSyncToXL"].ToString();
                string inFTP = ConfigurationManager.AppSettings["FTPINPathSyncToXL"].ToString();
                ftp.Recive(inFTP, outLocal, "-ORDERS.txt");

                Console.WriteLine("OrderExport Pobrałem z FTP-a");


                string[] filePaths = Directory.GetFiles(outLocal);

                foreach (var file in filePaths)
                {
                    if (!Path.GetFileName(file).EndsWith("-ORDERS.txt")) continue;
                    Console.WriteLine("OrderExport Przetwarzam plik" + file);

                    var stringList = new CoherentDataList<StringOrderExport>(file);
                    var listOut = new List<OrderExport>();

                    string ConStr = ConfigurationManager.AppSettings["DBConString"].ToString();
                    DBContext DB = new DBContext(ConStr);

                    var syncXL = new SyncXL();
                    
                    foreach (StringOrderExport el in stringList.List)
                    {
                        var toSend = new OrderExport(el);

                        listOut.Add(toSend);
                    }
                        syncXL.SendToXL(file, listOut);
                    Console.WriteLine("OrderExport Wysyłam do XL-a");

                    File.Move(file, file +"_" +Guid.NewGuid() + "_" +".BACKUP.txt");

                    foreach (StringOrderExport el in stringList.List)
                    {
                        var toSend = new OrderExport(el);

                        toSend.CreationDate = DateTime.Now;
                        toSend.File = Path.GetFileName(file);
                        toSend.Status = "OrderExport Pobrano z FTP, Przetworzono i Wysłano do XL-a";

                        DB.OrderExport.Add(toSend);
                    }

                    DB.SaveChanges();
                    Console.WriteLine("OrderExport dodano do bazy plik "+file);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                using (StreamWriter writetext = new StreamWriter("OrderExport_" + "Error.txt"))
                {
                    writetext.WriteLine(ex.ToString());
                }

                Thread.Sleep(1 * 60 * 1000);

                SimpleTriggerImpl retryTrigger = new SimpleTriggerImpl(Guid.NewGuid().ToString());
                retryTrigger.Description = "RetryTrigger";
                retryTrigger.RepeatCount = 0;
                retryTrigger.JobKey = context.JobDetail.Key;   // connect trigger with current job      
                retryTrigger.StartTimeUtc = DateBuilder.NextGivenSecondDate(DateTime.Now, 30);  // Execute after 30 seconds from now
                context.Scheduler.ScheduleJob(retryTrigger);   // schedule the trigger

              //  JobExecutionException jex = new JobExecutionException(ex, false);
              //  throw jex;


            }
            //                var syncXL = new SyncXL();
            //                syncXL.Send(file,listOut);
        }
    }
}

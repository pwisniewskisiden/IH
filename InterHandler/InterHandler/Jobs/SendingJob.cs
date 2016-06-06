using AutoMapper;
using BusinessLogic.SyncronXL;
using DAL.Context;
using DAL.FTP;
using DAL.IOFile;
using DAL.Model;
using DAL.Model.BL;
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

namespace InterHandler.Jobs
{
    class SendingJob
    {
        public static void Execute<StringModel, DBModel>(IJobExecutionContext context)
            where StringModel : FileData, new()
            where DBModel : IDBData, new()
        {
            try
            {
                Console.WriteLine("Iteruje dla "+ typeof(DBModel).Name.ToString());

                var syncXL = new SyncXL();
                var lines = syncXL.GetFromXL<DBModel>();

                Console.WriteLine("Pobrano dane z XL-a " + typeof(DBModel).Name.ToString());


                string ConStr = ConfigurationManager.AppSettings["DBConString"].ToString();
                DBContext DB = new DBContext(ConStr);


                var stringList = new CoherentDataList<StringModel>();

                var modelName = typeof(DBModel).Name;//.GetType();//typeof(BLModel. //).GetType().Name;
                var regex = Helper.FileType(modelName);
                var filename = Helper.FileName(modelName);

              
              
                foreach (var item in lines)
                {
                    var itemStringModel = item.ToStringModel<DBModel, StringModel>();
                    stringList.Add(itemStringModel);
                }

              

                string fileToSavePath = ConfigurationManager.AppSettings["LocalINPathXLtoSync"].ToString();
                string fileToSave = fileToSavePath + filename;
                stringList.SaveToFile(fileToSave);

                Console.WriteLine("Zapisoano na dysku plik" + fileToSave);


                string host = ConfigurationManager.AppSettings["FtpHostXLtoSync"].ToString();
                string username = ConfigurationManager.AppSettings["UserXLtoSync"].ToString();
                string pass = ConfigurationManager.AppSettings["PasswdXLtoSync"].ToString();
                var ftp = new FTP(host, username, pass);

                string inLocal = ConfigurationManager.AppSettings["LocalINPathXLtoSync"].ToString();
                string outFTP = ConfigurationManager.AppSettings["FTPOUTPathXLtoSync"].ToString();
                ftp.Send(inLocal, outFTP, regex);

                Console.WriteLine("Wysłano Ftp-em plik" + fileToSave);


                foreach (var item in lines)
                {
                    if (typeof(DBModel).Name == "DealerPartsMaster")
                    {
                        var dbModel = item as DealerPartsMaster;

                        dbModel.CreationDate = DateTime.Now;
                        dbModel.Status = "Wprowadzono do bazy i wysłano FTP-em do Synchrona";
                        dbModel.File = filename;

                        DB.DealerPartsMaster.Add(dbModel);

                    }

                    if (typeof(DBModel).Name == "OpenPurchaseOrders")
                    {

                        var dbModel = item as OpenPurchaseOrders;

                        dbModel.CreationDate = DateTime.Now;
                        dbModel.Status = "Wprowadzono do bazy i wysłano FTP-em do Synchrona";
                        dbModel.File = filename;

                        DB.OpenPurchaseOrders.Add(dbModel);

                    }

                    if (typeof(DBModel).Name == "TransactionalDemand")
                    {

                        var dbModel = item as TransactionalDemand;

                        dbModel.CreationDate = DateTime.Now;
                        dbModel.Status = "Wprowadzono do bazy i wysłano FTP-em do Synchrona";
                        dbModel.File = filename;

                        DB.TransactionalDemand.Add(dbModel);

                    }

                }
                
                 DB.SaveChanges();

                Console.WriteLine("Zapisano w bazie plik" + fileToSave);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                using (StreamWriter writetext = new StreamWriter(typeof(DBModel).Name+"_Error.txt"))
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

           //     JobExecutionException jex = new JobExecutionException(ex, false);
           //     throw jex;


            }

        }
    }
}

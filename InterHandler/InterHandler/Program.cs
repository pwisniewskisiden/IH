using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Model;
using BusinessLogic;
using DAL.IOFile;
using BusinessLogic.Jobs;
using DAL.FTP;
using System.Net; 
using Quartz;
using Quartz.Impl;
using BusinessLogic.SyncronXL;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections.Specialized;

namespace InterHandler
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");

            //var synxXL = new SyncXL();
            //var tst = synxXL.GetFromXL<DealerPartsMaster>();

            //Console.ReadKey();

            NameValueCollection propColl = new NameValueCollection();
            propColl.Add("quartz.threadPool.threadCount", "4");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(propColl);
            var _scheduler = schedulerFactory.GetScheduler();
            _scheduler.Start();



            #region DealerPartsMasterJob
            IJobDetail dealerPartsMasterJob = JobBuilder.Create<DealerPartsMasterJob>()
                                   .WithIdentity("dealerPartsMasterJob")
                                   .Build();

            ITrigger dealerPartsMasterTrigger = TriggerBuilder.Create()
                                             .WithIdentity("dealerPartsMasterTrigger")
                                             .WithCronSchedule(ConfigurationManager.AppSettings["CronDealerPartsMaster"].ToString())
                                             .StartNow()
                                             //.WithSimpleSchedule(x => x.RepeatForever().WithIntervalInHours(1))
                                             .Build();

            _scheduler.ScheduleJob(dealerPartsMasterJob, dealerPartsMasterTrigger);
            #endregion

            #region OpenPurchaseOrdersJob
            IJobDetail openPurchaseOrdersJob = JobBuilder.Create<OpenPurchaseOrdersJob>()
                           .WithIdentity("openPurchaseOrdersJob")
                           .Build();

            ITrigger openPurchaseOrdersTrigger = TriggerBuilder.Create()
                                             .WithIdentity("openPurchaseOrdersTrigger")
                                             .WithCronSchedule(ConfigurationManager.AppSettings["CronOpenPurchaseOrders"].ToString())
                                             .StartNow()
                                             //                              .WithSimpleSchedule(x => x.RepeatForever().WithIntervalInHours(1))
                                             .Build();

            _scheduler.ScheduleJob(openPurchaseOrdersJob, openPurchaseOrdersTrigger);
            #endregion

            #region OrderExportJob
            IJobDetail orderExportJob = JobBuilder.Create<OrderExportJob>()
                           .WithIdentity("orderExportJob")
                           .Build();

            ITrigger orderExportTrigger = TriggerBuilder.Create()
                                             .WithIdentity("orderExportTrigger")
                                             .WithCronSchedule(ConfigurationManager.AppSettings["CronOrderExport"].ToString())
                                             .StartNow()
                                               //                                .WithSimpleSchedule(x => x.RepeatForever().WithIntervalInHours(1))
                                             .Build();

            _scheduler.ScheduleJob(orderExportJob, orderExportTrigger);
            #endregion

            #region TransactionalDemandJob
            IJobDetail transactionalDemandJob = JobBuilder.Create<TransactionalDemandJob>()
                           .WithIdentity("transactionalDemandJob")
                           .Build();

            ITrigger transactionalDemandTrigger = TriggerBuilder.Create()
                                             .WithIdentity("transactionalDemandTrigger")
                                             .WithCronSchedule(ConfigurationManager.AppSettings["CronTransactionalDemand"].ToString())
                                             .StartNow()
                                             //                              .WithSimpleSchedule(x => x.RepeatForever().WithIntervalInHours(1))
                                             .Build();

            _scheduler.ScheduleJob(transactionalDemandJob, transactionalDemandTrigger);

            #endregion

            Console.WriteLine("...");
            Console.WriteLine("Naciśnij przycisk Escape aby zakończyc działanie.");
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    _scheduler.Shutdown();
                    break;
                }
            }
        }
    }
}

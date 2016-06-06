using InterHandlerService.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterHandlerService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private static IScheduler _scheduler;

        protected override void OnStart(string[] args)
        {

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();
            _scheduler.Start();

            #region DealerPartsMasterJob
            IJobDetail dealerPartsMasterJob = JobBuilder.Create<DealerPartsMasterJob>()
                                   .WithIdentity("dealerPartsMasterJob")
                                   .Build();

            ITrigger dealerPartsMasterTrigger = TriggerBuilder.Create()
                                             .WithIdentity("dealerPartsMasterTrigger")
                                             .StartNow()
                                             .WithSimpleSchedule(x => x.RepeatForever().WithIntervalInHours(1))
                                             .Build();

            _scheduler.ScheduleJob(dealerPartsMasterJob, dealerPartsMasterTrigger);
            #endregion

            #region OpenPurchaseOrdersJob
            IJobDetail openPurchaseOrdersJob = JobBuilder.Create<OpenPurchaseOrdersJob>()
                           .WithIdentity("openPurchaseOrdersJob")
                           .Build();

            ITrigger openPurchaseOrdersTrigger = TriggerBuilder.Create()
                                             .WithIdentity("openPurchaseOrdersTrigger")
                                             .StartNow()
                                             .WithCronSchedule("0 * 8-22 * * ?")
                                             .Build();

            _scheduler.ScheduleJob(openPurchaseOrdersJob, openPurchaseOrdersTrigger);
            #endregion

            #region OrderExportJob
            IJobDetail orderExportJob = JobBuilder.Create<OrderExportJob>()
                           .WithIdentity("orderExportJob")
                           .Build();

            ITrigger orderExportTrigger = TriggerBuilder.Create()
                                             .WithIdentity("orderExportTrigger")
                                             .StartNow()
                                             .WithCronSchedule("0 * 8-22 * * ?")
                                             .Build();

            _scheduler.ScheduleJob(orderExportJob, orderExportTrigger);
            #endregion

            #region TransactionalDemandJob
            IJobDetail transactionalDemandJob = JobBuilder.Create<TransactionalDemandJob>()
                           .WithIdentity("transactionalDemandJob")
                           .Build();

            ITrigger transactionalDemandTrigger = TriggerBuilder.Create()
                                             .WithIdentity("transactionalDemandTrigger")
                                             .StartNow()
                                             .WithCronSchedule("0 * 8-22 * * ?")
                                             .Build();

            _scheduler.ScheduleJob(transactionalDemandJob, transactionalDemandTrigger);

            #endregion

            _scheduler.Shutdown();
        }

        protected override void OnStop()
        {
            _scheduler.Shutdown();
        }
    }
}

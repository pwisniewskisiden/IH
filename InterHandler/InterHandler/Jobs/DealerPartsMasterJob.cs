using BusinessLogic.SyncronXL;
using DAL.FTP;
using DAL.IOFile;
using DAL.Model;
using InterHandler.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Jobs
{
    [DisallowConcurrentExecution]
    public class DealerPartsMasterJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            SendingJob.Execute<StringDealerPartsMaster, DealerPartsMaster>(context);
        }
    }
}

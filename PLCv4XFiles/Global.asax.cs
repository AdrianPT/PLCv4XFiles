using PLCv4XFiles.Services;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PLCv4XFiles
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            iniciarTask();
        }


        protected void iniciarTask()
        {

            try
            {

                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                scheduler.Start();


                IJobDetail job = JobBuilder.Create<DBWriter>()
                    .WithIdentity("UniqueWork", "Group")
                    .Build();


                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("Initio", "Group")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(1)
                        .WithRepeatCount(0)
                        .RepeatForever()
                     )
                    .Build();

                // Tell quartz to schedule the job using our trigger
                scheduler.ScheduleJob(job, trigger);

                // A los 10 segundos duerme
                Thread.Sleep(TimeSpan.FromSeconds(400));

                // apaga el scheduler cuando estoy listo para cerrar el programa
                scheduler.Shutdown();

            }
            catch (SchedulerException se)
            {

                // SimpleLog.Log(se);

            }



        }






    }
}

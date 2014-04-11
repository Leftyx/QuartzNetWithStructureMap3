namespace QuartzNetWithStructureMap3.Infrastructure.Scheduler
{
    using Quartz;
    using Quartz.Core;
    using Quartz.Impl;
    using System.Collections.Specialized;

    public class StructureMapSchedulerFactory : StdSchedulerFactory
    {
        private readonly StructureMapJobFactory JobFactory;

        public StructureMapSchedulerFactory(StructureMapJobFactory jobFactory)
        {
            //var properties = new NameValueCollection();

            //properties["quartz.scheduler.instanceName"] = "MyApp";
            //properties["quartz.scheduler.instanceId"] = "AUTO";

            //// Configure Thread Pool 
            //// properties["quartz.threadPool.type"] = "Quartz.Simpl.ZeroSizeThreadPool, Quartz";
            //properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            //properties["quartz.threadPool.threadCount"] = "4";
            //properties["quartz.threadPool.threadPriority"] = "Normal";

            //// Configure Job Store -->
            //properties["quartz.jobStore.misfireThreshold"] = "60000";
            //properties["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz";

            //this.Initialize(properties);
            
            this.Initialize();
            this.JobFactory = jobFactory;
        }

        protected override IScheduler Instantiate(QuartzSchedulerResources rsrcs, QuartzScheduler qs)
        {
            qs.JobFactory = this.JobFactory;
            return base.Instantiate(rsrcs, qs);
        }
    }
}

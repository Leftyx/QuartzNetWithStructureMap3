namespace QuartzNetWithStructureMap3.Infrastructure.Scheduler
{
    using System;
    using Quartz;
    using Quartz.Spi;
    using StructureMap;
    using System.Globalization;

    public class StructureMapJobFactory : IJobFactory
    {
        private readonly IContainer Container;

        public StructureMapJobFactory(IContainer container)
        {
            this.Container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            var jobType = jobDetail.JobType;

            try
            {
                return this.Container.GetInstance(jobType) as IJob;
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(CultureInfo.InvariantCulture, "Cannot instantiate class '{0}'", new object[] { jobDetail.JobType.FullName });
                throw new SchedulerException(errorMessage, ex);
            }
        }

        public void ReturnJob(IJob job)
        {
            // Nothing here. Unity does not maintain a handle to container created instances.
        }
    }
}

namespace QuartzNetWithStructureMap3.Jobs
{
    using System;
    using Common.Logging;
    using Quartz;
    using QuartzNetWithStructureMap3.Services;

    public class SimpleJob : IJob
    {
        private readonly ISimpleService SimpleService = null;

        public SimpleJob(ISimpleService simpleService)
        {
            this.SimpleService = simpleService;
        }

        public virtual void Execute(IJobExecutionContext context)
        {
            JobKey jobKey = context.JobDetail.Key;

            string message = string.Format("Job Key:{0} - Trigger Key:{1} - Start Time:{2} - Schedule Fire Time: {3}", context.JobDetail.Key, context.Trigger.Key, context.Trigger.StartTimeUtc, context.ScheduledFireTimeUtc);

            ILog log = LogManager.GetCurrentClassLogger();
            log.Debug(message);

            Console.WriteLine("Trigger Info: " + message);
            Console.WriteLine("Next Schedule: " + context.Trigger.GetNextFireTimeUtc());

            this.SimpleService.WriteConsole("Job Executed!!!");
        }
    }
}

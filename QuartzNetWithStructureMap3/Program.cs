namespace QuartzNetWithStructureMap3
{
    using System;
    using Quartz;
    using StructureMap;

    class Program
    {
        static void Main(string[] args)
        {
            var container = QuartzNetWithStructureMap3.Infrastructure.DependencyResolution.IoC.Initialize();

            var scheduler = ObjectFactory.GetInstance<IScheduler>();

            scheduler.Start();

            Console.WriteLine("Quartz.Net Started ...");

            ScheduleSimpleJob(scheduler);

            Console.ReadLine();
        }

        private static void ScheduleSimpleJob(IScheduler Scheduler)
        {
            IJobDetail simpleJob = null;
            ITrigger simpleTrigger = null;

            simpleJob = JobBuilder.Create<Jobs.SimpleJob>()
                            .WithIdentity("SimpleJob", "SimpleGroup")
                            .RequestRecovery(true)
                            .Build();

            simpleTrigger = TriggerBuilder.Create()
                            .WithIdentity("SimpleTrigger", "SimpleGroup")
                            .StartNow()
                            .WithSimpleSchedule(x => x.RepeatForever().WithIntervalInSeconds(20))
                            .Build();

            Scheduler.ScheduleJob(simpleJob, simpleTrigger);

            GetNext10FireTimes(simpleTrigger);

        }

        private static void GetNext10FireTimes(ITrigger trigger)
        {
            Console.WriteLine("List of next 10 schedules: ");

            var dt = trigger.GetNextFireTimeUtc();

            for (int i = 0; i < 10; i++)
            {
                if (dt == null)
                    break;

                Console.WriteLine(dt.Value.ToLocalTime());

                dt = trigger.GetFireTimeAfter(dt);
            }
        }
    }
}

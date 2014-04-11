namespace QuartzNetWithStructureMap3.Infrastructure.DependencyResolution
{
    using Quartz;
    using Quartz.Spi;
    using StructureMap.Pipeline;
    using QuartzNetWithStructureMap3.Infrastructure.Scheduler;
    
    public class QuartzRegistry : StructureMap.Configuration.DSL.Registry
    {
        public QuartzRegistry()
        {
            For<ISchedulerFactory>()
                .LifecycleIs<SingletonLifecycle>()
                .Use<StructureMapSchedulerFactory>();

            For<IScheduler>()
                .LifecycleIs<SingletonLifecycle>()
                .Use(o => o.GetInstance<ISchedulerFactory>().GetScheduler());

            For<IJobFactory>()
                .LifecycleIs<SingletonLifecycle>()
                .Use<StructureMapJobFactory>();
        }
    }
}
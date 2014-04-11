namespace QuartzNetWithStructureMap3.Infrastructure.DependencyResolution
{
    using StructureMap.Pipeline;
    using System;

    public class CoreRegistry : StructureMap.Configuration.DSL.Registry
    {
        public CoreRegistry()
        {
            this.For<QuartzNetWithStructureMap3.Services.ISimpleService>()
                .LifecycleIs<ThreadLocalStorageLifecycle>()
                .Use<QuartzNetWithStructureMap3.Services.SimpleService>();

            }
    }
}
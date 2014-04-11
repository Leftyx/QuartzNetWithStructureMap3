namespace QuartzNetWithStructureMap3.Infrastructure.DependencyResolution
{
    using StructureMap;

    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(init =>
                        {
                            init.Scan(scan =>
                                    {
                                       scan.WithDefaultConventions();
                                    });
                            init.AddRegistry<CoreRegistry>();
                            init.AddRegistry<QuartzRegistry>();
                            });

#if DEBUG
            var what = ObjectFactory.Container.WhatDoIHave();
#endif
            
            return (ObjectFactory.Container);
        }
    }
}
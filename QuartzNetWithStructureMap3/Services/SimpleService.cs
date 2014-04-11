using System;

namespace QuartzNetWithStructureMap3.Services
{
    public class SimpleService: ISimpleService
    {
        public void WriteConsole(string message)
        {
            Console.WriteLine(string.Format("{0} - {1}", this.ToString(), message));
        }
    }
}

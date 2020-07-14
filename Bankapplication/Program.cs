using DnsClient.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using System;


namespace Bankapplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<InstanceScanner>();
            var managerInstance = container.GetInstance<Dependency>();
            managerInstance.RunDependency();
        }
    }
}

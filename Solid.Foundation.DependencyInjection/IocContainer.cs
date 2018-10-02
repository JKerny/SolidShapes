using Autofac;
using Solid.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solid.Foundation.DependencyInjection
{
    public class IocContainer
    {
        public void Configure()
        {
            var builder = new ContainerBuilder();

            var servicesAssembly = typeof(IShape).Assembly;
            var servicesTypes = servicesAssembly
                .GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract &&
                    (t.Name.EndsWith("Service") || t.Name.EndsWith("Repository")) &&
                    t.GetInterface("I" + t.Name, false) != null)
                .ToArray();
            builder.RegisterTypes(servicesTypes).AsImplementedInterfaces();


            var container = builder.Build();
            foreach (var type in servicesTypes)
            {
                container.Resolve(type);
            }
        }
    }
}

using Autofac;
using Solid.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Solid.Foundation.DependencyInjection
{
    public static class IocContainer
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            List<Type> serviceTypes = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Solid."));
            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
 .              InstancePerRequest();

            }
            if (serviceTypes != null)
            {                
                var container = builder.Build();
                foreach (var type in serviceTypes)
                {
                    container.Resolve(type);
                }
            }
        }
    }
}

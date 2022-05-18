using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Autofac
{
    public static class AutofacConfigurationExtentions
    {
        public static void AddAutofacDependencyServices(this ContainerBuilder containerBuilder )
        {
            var currentAssembly = Assembly.GetCallingAssembly();
            var coreAssembly = Assembly.Load( "Core" );
            containerBuilder.RegisterAssemblyTypes( new[] { currentAssembly, coreAssembly } )
                            .AssignableTo<IScopedDependency>()
                            .AsImplementedInterfaces()
                            .InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes( new[] { currentAssembly, coreAssembly } )
                            .AssignableTo<ITransientDependency>()
                            .AsImplementedInterfaces()
                            .InstancePerDependency();
            containerBuilder.RegisterAssemblyTypes( new[] { currentAssembly , coreAssembly } )
                            .AssignableTo<ISingletonDependency>()
                            .AsImplementedInterfaces()
                            .SingleInstance();
        }
    }
}

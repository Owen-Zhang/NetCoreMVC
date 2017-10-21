using Autofac;
using KJT.ServiceInterface;
using KJT.WebFrameWork.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace NetCore2MVC.Common
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyStrList = new List<string>{
                "KJT.ServiceImplement.dll",
                "KJT.ServiceInterface.dll",
                "DataImplement",
                "DataInter"
            };

            List<System.Reflection.Assembly> assemblies = new List<System.Reflection.Assembly>();
            foreach (var item in assemblyStrList)
            {
                assemblies.Add(
                    System.Reflection.Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, item)));
            }

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                   .Where(item => typeof(IDependency).IsAssignableFrom(item) && !item.IsAbstract)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}

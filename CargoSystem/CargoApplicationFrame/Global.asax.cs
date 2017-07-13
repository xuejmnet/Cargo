using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;

namespace CargoApplicationFrame
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        private void SetupResolveRules(ContainerBuilder builder)
        {
            var Inter = new List<Type>();
            Assembly assembly = Assembly.Load("Cargo.Core.Data");
            foreach (Type aaa in assembly.GetTypes())
            {
                if (aaa.Name.StartsWith("I") && aaa.Name.EndsWith("Repository"))
                {
                    Inter.Add(aaa);
                }
            }

            var entity = new List<Type>();
            Assembly entassembly = Assembly.Load("Cargo.Core.Data.Repository");
            foreach (Type aaa in entassembly.GetTypes())
            {
                if (aaa.Name.EndsWith("Repository"))
                {
                    entity.Add(aaa);
                }
            }

            foreach (var item in entity)
            {
                Inter.ForEach(a =>
                {
                    if (a.Name.Contains(item.Name))
                    {
                        builder.RegisterType(item).As(a);
                    }
                });
            }

        }
    }
}

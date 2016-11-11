using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ASP.NET_Project;
using ASP.Net_Project.Code.Repositories;

namespace ASP.Net_Project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDataEntityRepository<BlogPost>, BlogFileRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}
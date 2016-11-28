using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ASP.NET_Project;
using ASP.Net_Project.Code.Repositories;
using ASP.Net_Project.Controllers;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            container.RegisterType<IProductRepo<Product>, ProductRepo>();
            container.RegisterType<ICategoryRepo<Category>, CategoryRepo>();
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}
using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_Project.Controllers
{
    public class HomeController : Controller
    {
        private IDataEntityRepository<BlogPost> _blog_post_repo;
        private IProductRepo<Product> _product_repo;

        // GET: Home
        public ActionResult Index()
        {
            List<BlogPost> blogs = _blog_post_repo.GetList();
            List<Product> products = _product_repo.GetList();
            HomePageContent mod = new HomePageContent()
            {
                BlogList = blogs.OrderByDescending(blog => blog.Timestamp).Take(3).ToList(),
                ProductList = products.Take(5).ToList()
            };
        
            return View(mod);
        }

        public HomeController(IDataEntityRepository<BlogPost> repo, IProductRepo<Product> prod_repo)
        {
            _blog_post_repo = repo;
            _product_repo = prod_repo;
        }
    }
}
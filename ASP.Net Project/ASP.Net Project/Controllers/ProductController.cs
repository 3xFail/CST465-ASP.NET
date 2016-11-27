using ASP.Net_Project.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_Project.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo<Product> prod_repo;

        public ProductController()
        {
            prod_repo = new ProductRepo();
        }

        public ProductController(IProductRepo<Product> repo)
        {
            this.prod_repo = repo;
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> list = prod_repo.GetList();
            return View(list);
        }

        public ActionResult Item(int id)
        {
            Product prod = prod_repo.Get(id);
            return View(prod);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProd(Product prod)
        {
            if (ModelState.IsValid)
            {
                prod_repo.Save(prod);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                prod_repo.Save(prod);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(prod_repo.Get(id));
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product prod)
        {
            if (ModelState.IsValid)
            {
                prod_repo.Save(prod);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        public ActionResult Delete(Product Cat)
        {
            prod_repo.Remove(Cat.ID);
            return RedirectToAction("Index");

        }

    }
}
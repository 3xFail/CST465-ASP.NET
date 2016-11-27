using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_Project.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryRepo<Category> cat_repo;

        public CategoryController()
        {
            cat_repo = new CategoryRepo();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<Category> cat = cat_repo.GetList();
            return View(cat);
        }

        public CategoryController(ICategoryRepo<Category> cat)
        {
            this.cat_repo = cat;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCat(string CategoryName)
        {
            if(ModelState.IsValid)
            {
                Category cat = new Category();
                cat.CatagoryName = CategoryName;
                cat_repo.Save(cat);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category Cat)
        {
            if (ModelState.IsValid)
            {
                cat_repo.Save(Cat);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Delete(Category Cat)
        {
            cat_repo.Remove(Cat.ID);
            return RedirectToAction("Index");

        }
        
    }
}
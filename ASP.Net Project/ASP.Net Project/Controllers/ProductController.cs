using ASP.Net_Project;
using ASP.Net_Project.Code.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult SaveProd(ProductModel prod)
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
                byte[] image;
                Product product = new Product();
                product.ID = prod.ID;
                product.CategoryID = prod.CategoryID;
                product.Price = prod.Price;
                product.ProductCode = prod.ProductCode;
                product.ProductDescription = prod.ProductDescription;
                product.ProductName = prod.ProductName;
                product.Quantity = prod.Quantity;

                if (prod.ProductImage != null)
                {

                    WebCache.Remove(product.ID + "big");
                    WebCache.Remove(product.ID + "small");

                    using (MemoryStream mem = new MemoryStream())
                    {
                        prod.ProductImage.InputStream.CopyTo(mem);
                        image = mem.ToArray();
                    }

                    product.ProductImage = image;
                    product.ImageFileName = prod.ProductImage.FileName;
                    product.ImageFileName = prod.ProductImage.ContentType;


                }
                else
                {
                    product.ProductImage = null;
                }

                prod_repo.Save(prod);

            }
            else
            {
                return View("Edit", prod);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                Product prod = prod_repo.Get(id);
                ProductModel product = new ProductModel();
                product.ID = prod.ID;
                product.CategoryID = prod.CategoryID;
                product.Price = Convert.ToDouble(prod.Price);
                product.ProductCode = prod.ProductCode;
                product.ProductDescription = prod.ProductDescription;
                product.ProductName = prod.ProductName;
                product.Quantity = prod.Quantity;
                product.Categories = new SelectList(new CategoryRepo.GetList(), "ID", "CategoryName");

                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductModel prod)
        {
            if (ModelState.IsValid)
            {
                byte[] image;
                Product product = new Product();
                product.ID = prod.ID;
                product.CategoryID = prod.CategoryID;
                product.Price = prod.Price;
                product.ProductCode = prod.ProductCode;
                product.ProductDescription = prod.ProductDescription;
                product.ProductName = prod.ProductName;
                product.Quantity = prod.Quantity;

                if(prod.ProductImage != null)
                {
                    using (MemoryStream mem = new MemoryStream())
                    {
                       prod.ProductImage.InputStream.CopyTo(mem);
                       image = mem.ToArray();
                    }

                    product.ProductImage = image;
                    product.ImageFileName = prod.ProductImage.FileName;
                    product.ImageFileName = prod.ProductImage.ContentType;


                }
                else
                {
                    product.ProductImage = null;
                }

                prod_repo.Save(product);
                
            }
            else
            {
                return View(prod);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Add()
        {
            ProductModel mod = new ProductModel();
            mod.Categories = new SelectList(new CategoryRepo.GetList(), "ID", "CategoryName");
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
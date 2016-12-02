using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_Project.Controllers
{
    public class BlogController : Controller
    {
        public BlogController(IDataEntityRepository<BlogPost> blog)
        {
            this.blog_repo = blog;
        }


        // GET: Blog
        public ActionResult Index()
        {
            return View(this.blog_repo.GetList());
        }


        [HttpPost]
        public ActionResult Index(string filter)
        {
            List<BlogPost> filtered_list = blog_repo.GetListByContent(filter);
            return View(filtered_list);
        }
        private IDataEntityRepository<BlogPost> blog_repo;

        public ActionResult Add()
        {
            BlogPostModel model = new BlogPostModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost post = new BlogPost();
                post.ID = model.ID;
                post.Title = model.Title;
                post.Author = model.Author;
                post.Content = model.Content;

                this.blog_repo.Save(post);
            }
            else { return View(model); }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                BlogPostModel bpm = new BlogPostModel();
                BlogPost bp = blog_repo.Get(id);

                bpm.ID = bp.ID;
                bpm.Title = bp.Title;
                bpm.Author = bp.Author;
                bpm.Content = bp.Content;

                return View(bpm);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(BlogPostModel model)
        {
            if(ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                BlogPost bp = new BlogPost();
                bp.ID = model.ID;
                bp.Title = model.Title;
                bp.Author = model.Author;
                bp.Content = model.Content;

                this.blog_repo.Save(bp);

            }
            else { return View(model); }
            return RedirectToAction("Index");
        }

        public ActionResult Display(int id)
        {
            BlogPost entry = blog_repo.Get(id);
            return View(entry);
        }
    }
}
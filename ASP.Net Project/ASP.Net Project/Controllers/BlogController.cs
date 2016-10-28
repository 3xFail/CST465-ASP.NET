﻿using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_Project.Controllers
{
    public class BlogController : Controller
    {
        public BlogController()
        {
            this.blog_repo = new BlogDBRepository();
        }


        // GET: Blog
        public ActionResult Index()
        {
            return View(this.blog_repo.GetList());
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
            BlogPostModel bpm = new BlogPostModel();
            BlogPost bp = blog_repo.Get(id);

            bpm.ID = bp.ID;
            bpm.Title = bp.Title;
            bpm.Author = bp.Author;
            bpm.Content = bp.Content;

            return View(bpm); 
        }
        [HttpPost]
        public ActionResult Edit(BlogPostModel model)
        {
            if(ModelState.IsValid)
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_Project.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submission(ContactModel mod)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", mod);
            }

        }
    }
}
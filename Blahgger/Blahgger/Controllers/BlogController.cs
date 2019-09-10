using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blahgger.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        // GET: 
        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult EditPost()
        {
            return View();
        }

        public ActionResult AddComment()
        {
            return View();
        }

        public ActionResult EditComment()
        {
            return View();
        }

        public ActionResult DeleteComment()
        {
            return View();
        }
    }
}
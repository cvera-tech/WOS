using Blahgger.Data;
using Blahgger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blahgger.Controllers
{
    public class AccountsController : Controller
    {
        [AllowAnonymous]
        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }
        
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                BlahggerData data = BlahggerData.GetInstance();
                data.AddUser(user);
                return RedirectToAction("Index", "Posts");
            }

            return View(user);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            BlahggerData data = BlahggerData.GetInstance();

            if (data.AuthenticateUser(user))
            {
                return RedirectToAction("Index", "Posts");
            }
            else
            {
                return View(user);
            }
        }
    }
}

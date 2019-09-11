using CommunityShedMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    using BCrypt.Net;
    using Data;
    using Models;
    using System.Web.Security;

    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO Password hashing
                // TODO Compare input with database record
                if (ModelState.IsValidField("EmailAddress") && ModelState.IsValidField("Password"))
                {
                    CommunityShedData data = CommunityShedData.Instance();
                    if (!data.AuthenticateUser(viewModel))
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                }

                if (ModelState.IsValid)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.EmailAddress, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
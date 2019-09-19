using CommunityShedMVC.Data;
using CommunityShedMVC.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace CommunityShedMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValidField("EmailAddress") && ModelState.IsValidField("Password"))
                {
                    if (!CommunityShedData.AuthenticateUser(viewModel))
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

        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterViewModel viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            // TODO Check if email exists in database

            CommunityShedData.RegisterUser(viewModel);
            FormsAuthentication.SetAuthCookie(viewModel.EmailAddress, false);
            return RedirectToAction("Index", "Home");
        }
    }
}
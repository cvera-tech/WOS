using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.Security;
using CommunityShedMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CustomPrincipal customUser = (CustomPrincipal)User;
            HomeViewModel viewModel = new HomeViewModel
            {
                BorrowedItems = new List<Item>(),
                UserItems = new List<Item>(),
                Communities = CommunityShedData.GetCommunities(customUser.Person.Id)
            };
            return View(viewModel);
        }
    }
}
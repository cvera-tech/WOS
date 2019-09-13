using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel
            {
                BorrowedItems = new List<Item>(),
                UserItems = new List<Item>(),
                Communities = CommunityShedData.GetCommunities(CustomUser.Person.Id),
                CommunityRoles = CustomUser.Person.Roles
            };
            return View(viewModel);
        }
    }
}
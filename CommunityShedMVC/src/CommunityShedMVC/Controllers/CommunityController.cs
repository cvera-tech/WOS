using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.Security;
using CommunityShedMVC.ViewModels;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public class CommunityController : Controller
    {
        // GET: Community
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            Community community = new Community();
            return View(community);
        }

        [HttpPost]
        public ActionResult Add(Community community)
        {
            if (ModelState.IsValid)
            {
                // TODO redirect to details page
                CommunityShedData.AddCommunity(community, ((CustomPrincipal)User).Person.Id);
                return RedirectToAction("Index", "Home");
            }
            return View(community);
        }

        public ActionResult List()
        {
            CommunityListViewModel viewModel = new CommunityListViewModel
            {
                Communities = CommunityShedData.GetCommunities()
            };
            return View(viewModel);
        }
    }
}
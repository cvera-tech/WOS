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

        public ActionResult Details(int Id)
        {
            // There is surely a better way to populate this view model.
            // Querying the database for each property can get expensive, but 
            // my brain is too fried to engineer a more efficient solution.
            CommunityDetailsViewModel viewModel = new CommunityDetailsViewModel
            {
                Community = CommunityShedData.GetCommunity(Id),
                PersonRoles = CommunityShedData.GetCommunityPersonRoles(Id),
                Members = CommunityShedData.GetCommunityMembers(Id)
            };
            return View(viewModel);
        }
    }
}
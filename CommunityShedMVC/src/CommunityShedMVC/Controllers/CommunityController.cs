using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.Security;
using CommunityShedMVC.ViewModels;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public class CommunityController : BaseController
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
                CommunityShedData.AddCommunity(community, CustomUser.Person.Id);
                return RedirectToAction("Index", "Home");
            }
            return View(community);
        }

        public ActionResult List()
        {
            CommunityListViewModel viewModel = new CommunityListViewModel
            {
                Communities = CommunityShedData.GetCommunityListItems(CustomUser.Person.Id)
            };
            return View(viewModel);
        }

        public ActionResult Details(int communityId)
        {
            // There is surely a better way to populate this view model.
            // Querying the database for each property can get expensive, but 
            // my brain is too fried to engineer a more efficient solution.
            CommunityDetailsViewModel viewModel = new CommunityDetailsViewModel
            {
                Community = CommunityShedData.GetCommunity(communityId),
                PersonRoles = CommunityShedData.GetCommunityPersonRoles(communityId),
                Members = CommunityShedData.GetCommunityMembers(communityId)
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Join()
        {
            // For now, redirect to home page
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Join(int communityId)
        {
            CommunityJoinViewModel viewModel = new CommunityJoinViewModel()
            {
                CommunityName = CommunityShedData.GetCommunity(communityId).Name,
                Success = CommunityShedData.JoinCommunity(communityId, CustomUser.Person.Id)
            };
            return View(viewModel);
        }
    }
}
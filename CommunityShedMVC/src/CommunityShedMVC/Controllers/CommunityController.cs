using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public class CommunityController : BaseController
    {
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
            // Querying the database for each property can get expensive.
            CommunityDetailsViewModel viewModel = new CommunityDetailsViewModel
            {
                Community = CommunityShedData.GetCommunity(communityId),
                PersonRoles = CommunityShedData.GetCommunityPersonRoles(communityId),
                Members = CommunityShedData.GetCommunityMembers(communityId),
                CanEdit = CustomUser.CanEditCommunity(communityId),
                CanEditMembers = CustomUser.IsInRole("Enforcer", communityId)
            };
            return View(viewModel);
        }

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

        public ActionResult Edit(int communityId)
        {
            if (CustomUser.CanEditCommunity(communityId))
            {
                Community community = CommunityShedData.GetCommunity(communityId);
                return View(community);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(Community community)
        {
            if (ModelState.IsValid && CustomUser.CanEditCommunity(community.Id))
            {
                CommunityShedData.UpdateCommunity(community);
                return RedirectToAction("Details", "Community",
                    routeValues: new { communityId = community.Id });
            }
            return View(community);
        }

        public ActionResult EditMember(int communityId, int personId)
        {
            List<Role> roles = CommunityShedData.GetRoles(personId, communityId);
            bool approver = false;
            bool reviewer = false;
            bool enforcer = false;
            foreach(var role in roles)
            {
                if (role.Name == "Approver")
                    approver = true;
                if (role.Name == "Reviewer")
                    reviewer = true;
                if (role.Name == "Enforcer")
                    enforcer = true;
            }

            CommunityEditMemberViewModel viewModel = new CommunityEditMemberViewModel
            {
                Community = CommunityShedData.GetCommunity(communityId),
                Approver = approver,
                Reviewer = reviewer,
                Enforcer = enforcer
            };
            return View(viewModel);
        }
    }
}
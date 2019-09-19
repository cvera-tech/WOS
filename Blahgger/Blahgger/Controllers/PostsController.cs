using Blahgger.Data;
using Blahgger.Models;
using Blahgger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blahgger.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index()
        {
            BlahggerData data = BlahggerData.GetInstance();
            List<Post> posts = data.GetPosts();
            PostsViewModel postsViewModel = new PostsViewModel() { Posts = posts };
            
            return View(postsViewModel);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            //TODO
            return View();
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            Post post = new Post();
            return View(post);
        }

        // POST: Posts/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                BlahggerData data = BlahggerData.GetInstance();

                string username = User.Identity.Name;
                int usersId = data.GetUsersId(username);
                post.UsersId = usersId;
                post.CreatedOn = DateTimeOffset.Now;

                data.AddPost(post);

                return RedirectToAction("Index");
            }

            return View(post);
        }
    }
}

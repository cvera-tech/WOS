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
            return View();
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            Post post = new Post();
            return View(post);
        }

        // POST: Posts/Create
        [HttpPost]
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

        //// GET: Posts/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Posts/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Posts/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Posts/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

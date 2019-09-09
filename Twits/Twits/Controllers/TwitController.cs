using System.Collections.Generic;
using System.Web.Mvc;
using Twits.Models;

namespace Twits.Controllers
{
    public class TwitController : Controller
    {
        // GET: Twit
        public ActionResult Index()
        {
            List<Twit> twits = new List<Twit>();
            return View(twits);
        }

        //// GET: Twit/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Twit/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Twit/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Twit/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Twit/Edit/5
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

        //// GET: Twit/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Twit/Delete/5
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

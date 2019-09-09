using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Twits.Models;

namespace Twits.Controllers
{
    public class TwitController : Controller
    {
        // GET: Twit
        public ActionResult Index()
        {
            string sql = @"
                SELECT Id, Text, CreatedOn
                FROM Twits
                ORDER BY CreatedOn DESC
                OFFSET 0 ROWS
                FETCH NEXT 100 ROWS ONLY
            ";

            List<Twit> twits = new List<Twit>();
            DataTable twitsTable = DatabaseHelper.Retrieve(sql);

            foreach (DataRow row in twitsTable.Rows)
            {
                Twit twit = new Twit
                {
                    Id = row.Field<int>("Id"),
                    Text = row.Field<string>("Text"),
                    CreatedOn = row.Field<DateTimeOffset>("CreatedOn")
                };
                twits.Add(twit);
            }
            return View(twits);
        }

        //// GET: Twit/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Twit/Create
        public ActionResult Create()
        {
            Twit twit = new Twit();
            return View(twit);
        }

        // POST: Twit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Twit twit = new Twit();
            twit.Text = collection.Get("Text");
            twit.CreatedOn = DateTimeOffset.Now;
            try
            {
                string sql = @"
                    INSERT INTO Twits (Text, CreatedOn)
                    VALUES (@Text, @CreatedOn)
                ";

                DatabaseHelper.Insert(sql,
                    new SqlParameter("@Text", twit.Text),
                    new SqlParameter("@CreatedOn", twit.CreatedOn));

                return RedirectToAction("Index");
            }
            catch
            {
                return View(twit);
            }
        }

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

        // POST: Twit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string sql = @"
                    DELETE FROM Twits
                    WHERE Id=@Id
                ";
                DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@Id", id));

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}

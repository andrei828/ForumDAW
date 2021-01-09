using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace lab6.Controllers
{
    public class UserFeedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserFeed
        public ActionResult Index()
        {
            ViewBag.CurrentUser = db.Users.Find(User.Identity.GetUserId());

            ViewBag.Topics = db.Topics.ToList();

            return View();
        }

        // GET: UserFeed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [ActionName("Topics")]
        public ActionResult Topics()
        {
            ViewBag.Topics = db.Topics.ToList();
            return View(db.Topics.ToList());
        }

        // GET: UserFeed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserFeed/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserFeed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserFeed/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserFeed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserFeed/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Infrastructure;
using Berserk_Statistics_MVC.Models;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Controllers
{
    public class RatingController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private IRatingRepository _ratings;
        private IUserProfileRepository _users;

        public RatingController() : this(new DalContext()) { }

        private RatingController(DalContext context)
        {
            _users = context.Users;
            _ratings = context.Ratings;
        }

        //
        // GET: /Rating/

        public ActionResult Index()
        {
            var ratings = db.Ratings.Include(r => r.Member).Include(r => r.Owner);
            return View(_users.CurrentUser.Ratings.ToList());
        }

        //
        // GET: /Rating/Details/5

        public ActionResult Details(int id = 0)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        //
        // GET: /Rating/Create

        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName");
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Rating/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", rating.MemberId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", rating.UserId);
            return View(rating);
        }

        //
        // GET: /Rating/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", rating.MemberId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", rating.UserId);
            return View(rating);
        }

        //
        // POST: /Rating/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", rating.MemberId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", rating.UserId);
            return View(rating);
        }

        //
        // GET: /Rating/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        //
        // POST: /Rating/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rating rating = db.Ratings.Find(id);
            db.Ratings.Remove(rating);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
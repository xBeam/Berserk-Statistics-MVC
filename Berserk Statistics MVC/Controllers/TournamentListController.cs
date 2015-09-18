using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Models;

namespace Berserk_Statistics_MVC.Controllers
{
    public class TournamentListController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /TournamentList/

        public ActionResult Index()
        {
            var tournamentlists = db.TournamentLists.Include(t => t.Member).Include(t => t.User);
            return View(tournamentlists.ToList());
        }

        //
        // GET: /TournamentList/Details/5

        public ActionResult Details(int id = 0)
        {
            TournamentList tournamentlist = db.TournamentLists.Find(id);
            if (tournamentlist == null)
            {
                return HttpNotFound();
            }
            return View(tournamentlist);
        }

        //
        // GET: /TournamentList/Create

        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName");
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /TournamentList/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TournamentList tournamentlist)
        {
            if (ModelState.IsValid)
            {
                db.TournamentLists.Add(tournamentlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", tournamentlist.MemberId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", tournamentlist.UserId);
            return View(tournamentlist);
        }

        //
        // GET: /TournamentList/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TournamentList tournamentlist = db.TournamentLists.Find(id);
            if (tournamentlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", tournamentlist.MemberId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", tournamentlist.UserId);
            return View(tournamentlist);
        }

        //
        // POST: /TournamentList/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TournamentList tournamentlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", tournamentlist.MemberId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", tournamentlist.UserId);
            return View(tournamentlist);
        }

        //
        // GET: /TournamentList/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TournamentList tournamentlist = db.TournamentLists.Find(id);
            if (tournamentlist == null)
            {
                return HttpNotFound();
            }
            return View(tournamentlist);
        }

        //
        // POST: /TournamentList/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TournamentList tournamentlist = db.TournamentLists.Find(id);
            db.TournamentLists.Remove(tournamentlist);
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
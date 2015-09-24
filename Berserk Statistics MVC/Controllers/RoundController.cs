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
    public class RoundController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /Round/

        public ActionResult Index()
        {
            var rounds = db.Rounds.Include(r => r.Tournament);
            return View(rounds.ToList());
        }

        //
        // GET: /Round/Details/5

        public ActionResult Details(int id = 0)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        //
        // GET: /Round/Create

        public ActionResult Create()
        {
            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "TournamentName");
            return View();
        }

        //
        // POST: /Round/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Round round)
        {
            if (ModelState.IsValid)
            {
                db.Rounds.Add(round);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "TournamentName", round.TournamentId);
            return View(round);
        }

        //
        // GET: /Round/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "TournamentName", round.TournamentId);
            return View(round);
        }

        //
        // POST: /Round/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Round round)
        {
            if (ModelState.IsValid)
            {
                db.Entry(round).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "TournamentName", round.TournamentId);
            return View(round);
        }

        //
        // GET: /Round/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        //
        // POST: /Round/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Round round = db.Rounds.Find(id);
            db.Rounds.Remove(round);
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
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Filters;
using Berserk_Statistics_MVC.Infrastructure;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TournamentController : Controller
    {
        private ITournamentRepository _tournaments;
        private IUserProfileRepository _users;

         public TournamentController() : this(new DalContext()) { }

         private TournamentController(IDalContext context)
        {
            _users = context.Users;
            _tournaments = context.Tournaments;
        }

        // GET: /Tournament/
        public ActionResult Index()
        {
            return View(_tournaments.All.ToList());
        }

        // GET: /Tournament/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            Tournament tournament = _tournaments.All.FirstOrDefault(c => c.TournamentId == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: /Tournament/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tournament/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                tournament.Owner = _users.CurrentUser;
                _tournaments.InsertOrUpdate(tournament);
                _tournaments.Save();

                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        public ActionResult Members(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            Tournament tournament = _tournaments.All.FirstOrDefault(c => c.TournamentId == id);

            if (tournament == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // GET: /Tournament/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            return View(_tournaments.All.FirstOrDefault(c => c.TournamentId == id));
        }

        // POST: /Tournament/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournaments.InsertOrUpdate(tournament);
                _tournaments.Save();
            }

            return RedirectToAction("Index");
        }

        // GET: /Tournament/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            return View(_tournaments.All.FirstOrDefault(c => c.TournamentId == id));
        }

        // POST: /Tournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tournaments.Remove(_tournaments.All.FirstOrDefault((c=>c.TournamentId == id)));
            _tournaments.Save();
            return RedirectToAction("Index");
        }
    }
}
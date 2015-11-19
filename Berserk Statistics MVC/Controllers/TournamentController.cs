using System;
using System.Collections.Generic;
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
        private IMemberRepository _members;

         public TournamentController() : this(new DalContext()) { }

         private TournamentController(IDalContext context)
        {
            _users = context.Users;
            _tournaments = context.Tournaments;
            _members = context.Members;
        }

        // GET: /Tournament/
        public ActionResult Index()
        {
            return View(_tournaments.All.Where(c=>c.Owner.UserId == _users.CurrentUser.UserId).ToList());
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
            ViewBag.Members = _members.All.Where(c=>c.Owner.UserId == _users.CurrentUser.UserId).ToList();
            return View();
        }

        // POST: /Tournament/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tournament tournament, List<string> listKey)
        {
            if (ModelState.IsValid)
            {
                if (listKey != null && listKey.Any())
                {
                    foreach (var key in listKey)
                    {
                        var member = _members.All.FirstOrDefault(c => c.MemberName == key);
                        if (member != null)
                            tournament.Members.Add(member);
                    }
                }
               
                tournament.Owner = _users.CurrentUser;
                _tournaments.InsertOrUpdate(tournament);
                _tournaments.Save();

                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        public ActionResult Members()
        {
            return View();
        }

        public ActionResult AddMember()
        {
            return View();
        }

        public ActionResult RemoveMember()
        {
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
        [ValidateAntiForgeryToken]
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
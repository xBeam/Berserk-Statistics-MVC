using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Filters;
using Statistics.Domain;
using Berserk_Statistics_MVC.Infrastructure;

namespace Berserk_Statistics_MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class RoundController : Controller
    {
        private ITournamentRepository _tournaments;
        private IRoundRepository _rounds;
        private ITableRepository _tables;
        private IMemberRepository _members;

        public RoundController() : this(new DalContext())
        {
        }

        private RoundController(IDalContext context)
        {
            _tournaments = context.Tournaments;
            _members = context.Members;
            _rounds = context.Rounds;
            _tables = context.Tables;
        }

        //
        // GET: /Round/

        public ActionResult Index()
        {
            return View(_rounds.All.ToList());
        }

        //
        // GET: /Round/Details/5

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            Round round = _rounds.All.FirstOrDefault(c => c.RoundId == id);
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
            return View();
        }

        //
        // POST: /Round/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Round round)
        {
            _rounds.InsertOrUpdate(round);
            _rounds.Save();

            return View(round);
        }

        //
        // GET: /Round/Edit/5

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            return View(_rounds.All.FirstOrDefault(c => c.RoundId == id));
        }

        //
        // POST: /Round/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Round round)
        {
            if (ModelState.IsValid)
            {
                _rounds.InsertOrUpdate(round);
                _rounds.Save();
            }

            return RedirectToAction("Index", "Round");
        }

        //
        // GET: /Round/Delete/5

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            return View(_rounds.All.FirstOrDefault(c => c.RoundId == id));
        }

        //
        // POST: /Round/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            var connectedTables = _tables.All.Where(c => c.Round.RoundId == id);

            foreach (var connectedTable in connectedTables)
            {
                _tables.Remove(_tables.All.FirstOrDefault(c => c.TableId == connectedTable.TableId));
            }

            _rounds.Remove(_rounds.All.FirstOrDefault((c => c.RoundId == id)));
            _rounds.Save();
            return RedirectToAction("Index");
        }
    }
}

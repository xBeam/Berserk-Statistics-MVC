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
        private DatabaseContext db = new DatabaseContext();
        private ITournamentRepository _tournaments;
        private IUserProfileRepository _users;

         public TournamentController() : this(new DalContext()) { }

         private TournamentController(IDalContext context)
        {
            _users = context.Users;
            _tournaments = context.Tournaments;
        }

        //
        // GET: /Tournament/

        public ActionResult Index()
        {
            var tournaments = db.Tournaments.Include(t => t.Rating).Include(t => t.Owner).Include(t => t.Rounds);
            //return View(tournaments);

            return View(_users.CurrentUser.Tournaments.ToList());
        }

        //
        // GET: /Tournament/Details/5

        public ActionResult Details(int id = 0)
        {
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        //
        // GET: /Tournament/Create

        public ActionResult Create()
        {
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingId");
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
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

            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingId", tournament.RatingId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", tournament.UserId);
            return View(tournament);
        }

        //
        // GET: /Tournament/Edit/5

        public ActionResult Edit(int id = 0)
        {
            return View(_tournaments.All.FirstOrDefault(c => c.TournamentId == id));

            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingId", tournament.RatingId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", tournament.UserId);
            return View(tournament);
        }

        //
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

            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingId", tournament.RatingId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", tournament.UserId);
            return View(tournament);
        }

        //
        // GET: /Tournament/Delete/5

        public ActionResult Delete(int id = 0)
        {
            return View(_tournaments.All.FirstOrDefault(c => c.TournamentId == id));
        }

        //
        // POST: /Tournament/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tournaments.Remove(_tournaments.All.FirstOrDefault((c=>c.TournamentId == id)));
            _tournaments.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
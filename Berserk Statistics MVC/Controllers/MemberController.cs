using System.Data;
using System.Linq;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Filters;
using Berserk_Statistics_MVC.Infrastructure;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class MemberController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private IMemberRepository _members;
        private IUserProfileRepository _users;

        public MemberController() : this(new DalContext()) { }

        private MemberController(IDalContext context)
        {
            _users = context.Users;
            _members = context.Members;
        }

        //
        // GET: /Member/

        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        //
        // GET: /Member/
        public ActionResult GetTournamentMember()
        {
           // var members = db.Members.Include(r => r.Owner);
            //return View(db.Members.ToList());
            return View(_users.CurrentUser.Ratings.ToList());
        }

        //
        // GET: /Member/Details/5

        public ActionResult Details(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // GET: /Member/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Member/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName");
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return View("~/Views/Rating/Create.cshtml");
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //
        // GET: /Member/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // GET: /Member/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /Member/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
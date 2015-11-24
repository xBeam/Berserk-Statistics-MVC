using System.Data;
using System.Linq;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Filters;
using Berserk_Statistics_MVC.Infrastructure;
using Statistics.Domain;
using System;

namespace Berserk_Statistics_MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class MemberController : Controller
    {
        private IMemberRepository _members;
        private IUserProfileRepository _users;

        public MemberController() : this(new DalContext()) { }

        private MemberController(IDalContext context)
        {
            _users = context.Users;
            _members = context.Members;
        }

        // GET: /Member/
        public ActionResult Index()
        {
            return View(_members.All.Where(c => c.Owner.UserId == _users.CurrentUser.UserId).ToList());
        }

        // GET: /Member/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            Member member = _members.All.FirstOrDefault(m => m.MemberId == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: /Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                var allMembers = _members.All.Where(c => c.Owner.UserId != null);

                if (Enumerable.Any(allMembers, memb => memb.MemberName == member.MemberName))
                {
                    ViewBag.Alert = "Участник с таким именем уже существует!";
                    return View(member);
                }

                member.Owner = _users.CurrentUser;
                _members.InsertOrUpdate(member);
                _members.Save();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: /Member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            Member member = _members.All.FirstOrDefault(m => m.MemberId == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: /Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                _members.InsertOrUpdate(member);
                _members.Save();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: /Member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            Member member = _members.All.FirstOrDefault(m => m.MemberId == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: /Member/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException();
            }

            _members.Remove(_members.All.FirstOrDefault((c => c.MemberId == id)));
            _members.Save();
            return RedirectToAction("Index");
        }
    }
}
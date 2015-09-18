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
    public class MemberController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /Member/

        public ActionResult Index()
        {
            var members = db.Members;//.Include(m => m.User);
            return View(members.ToList());
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
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Member/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", member.UserId);
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
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", member.UserId);
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
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", member.UserId);
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
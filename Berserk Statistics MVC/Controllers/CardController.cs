using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Berserk_Statistics_MVC.Filters;
using Berserk_Statistics_MVC.Infrastructure;
using Statistics.Domain;
using System.Threading;

namespace Berserk_Statistics_MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class CardController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private ICardRepository _cards;
        private IUserProfileRepository _users;

        public CardController() : this(new DalContext()) { }

        private CardController(IDalContext context)
        {
            _users = context.Users;
            _cards = context.Cards;
        }

        //
        // GET: /Card/
        public ActionResult Index()
        {
            var cards = db.Cards.Include(c => c.Owner);
            return View(cards);
        }

        //public ActionResult PostIndex(bool IsForSale)
        //{
        //    if (IsForSale)
        //    {
        //        return View(_users.CurrentUser.Cards.Where(c => c.IsForSale == true).ToList());
                
        //    }
        //    return View(_users.CurrentUser.Cards.Where(c => c.IsForSale == false).ToList());
        //}

        //
        // GET: /Card/Details/5

        public ActionResult Details(int id = 0)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // GET: /Card/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Card/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Card card)
        {
            if (ModelState.IsValid)
            {
                card.Owner = _users.CurrentUser;
                _cards.InsertOrUpdate(card);
                _cards.Save();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", card.UserId);
            return View(card);
        }

        //
        // GET: /Card/Edit/5

        public ActionResult Edit(int id = 0)
        {
            return View(_cards.All.FirstOrDefault(c => c.CardId == id));

            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", card.UserId);
            return View(card);
        }

        //
        // POST: /Card/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Card card)
        {
            if (ModelState.IsValid)
            {
                _cards.InsertOrUpdate(card);
                _cards.Save();
            }
            return RedirectToAction("Index");

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", card.UserId);
            return View(card);
        }

        //
        // GET: /Card/Delete/5

        public ActionResult Delete(int id = 0)
        {
            return View(_cards.All.FirstOrDefault(c => c.CardId == id));
        }

        //
        // POST: /Card/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _cards.Remove(_cards.All.FirstOrDefault(c => c.CardId == id));
            _cards.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
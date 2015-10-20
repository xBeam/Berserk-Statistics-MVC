using System.ComponentModel;
using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class CardRepository : ICardRepository
    {
        private DatabaseContext _context;

        public CardRepository(DatabaseContext context)
        {
            _context = context;
        }

        IQueryable<Card> ICardRepository.All
        {
            get { return _context.Cards; }
        }

        void ICardRepository.InsertOrUpdate(Card card)
        {
            if (card.CardId == default(int))
            {
                _context.Cards.Add(card);
            }
            else
            {
                _context.Entry(card).State = System.Data.EntityState.Modified;
            }
        }

        void ICardRepository.Remove(Card card)
        {
            _context.Entry(card).State = System.Data.EntityState.Deleted;
        }

        void ICardRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
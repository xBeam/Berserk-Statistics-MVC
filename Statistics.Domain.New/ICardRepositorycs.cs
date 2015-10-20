using System.Linq;

namespace Statistics.Domain
{
    public interface ICardRepository
    {
        IQueryable<Card> All { get; }
        void InsertOrUpdate(Card card);
        void Remove(Card card);
        void Save();
    }
}

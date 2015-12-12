using System.Linq;

namespace Statistics.Domain
{
    public interface IRoundRepository
    {
        IQueryable<Round> All { get; }
        void InsertOrUpdate(Round round);
        void Remove(Round round);
        void Save();
    }
}

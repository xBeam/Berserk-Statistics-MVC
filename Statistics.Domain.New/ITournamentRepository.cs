using System.Linq;

namespace Statistics.Domain
{
    public interface ITournamentRepository
    {
        IQueryable<Tournament> All { get; }
        void InsertOrUpdate(Tournament tournament);
        void Remove(Tournament tournament);
        void Save();
    }
}

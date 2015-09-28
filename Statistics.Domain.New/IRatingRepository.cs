using System.Linq;

namespace Statistics.Domain
{
    public interface IRatingRepository
    {
        IQueryable<Rating> All { get; }
        void InsertOrUpdate(Rating rating);
        void Remove(Rating rating);
        void Save();
    }
}

using System.Linq;
using Statistics.Domain.New;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class RatingRepository : IRatingRepository
    {
        private DatabaseContext _context;

        public RatingRepository(DatabaseContext context)
        {
            _context = context;
        }

        IQueryable<Rating> IRatingRepository.All
        {
            get { return _context.Ratings; }
        }

        void IRatingRepository.InsertOrUpdate(Rating rating)
        {
            if (rating.UserId == default (int))
            {
                _context.Ratings.Add(rating);
            }
            else
            {
                _context.Entry(rating).State = System.Data.EntityState.Modified;
            }
        }

        void IRatingRepository.Remove(Rating rating)
        {
            _context.Entry(rating).State = System.Data.EntityState.Deleted;
        }

        void IRatingRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
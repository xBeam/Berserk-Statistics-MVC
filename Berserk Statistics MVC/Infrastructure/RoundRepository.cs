using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class RoundRepository : IRoundRepository
    {
        private DatabaseContext _context;

        public RoundRepository(DatabaseContext context)
        {
            _context = context;
        }

        IQueryable<Round> IRoundRepository.All
        {
            get { return _context.Rounds; }
        }

        void IRoundRepository.InsertOrUpdate(Round round)
        {
            if (round.RoundId == default(int))
            {
                _context.Rounds.Add(round);
            }
            else
            {
                _context.Entry(round).State = System.Data.EntityState.Modified;
            }
        }

        void IRoundRepository.Remove(Round round)
        {
            _context.Entry(round).State = System.Data.EntityState.Deleted;
        }

        void IRoundRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
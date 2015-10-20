using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class TournamentRepository : ITournamentRepository
    {
        private DatabaseContext _context;

        public TournamentRepository(DatabaseContext context)
        {
            _context = context;
        }

        IQueryable<Tournament> ITournamentRepository.All
        {
            get { return _context.Tournaments; }
        }

        void ITournamentRepository.InsertOrUpdate(Tournament tournament)
        {
            if (tournament.TournamentId == default(int))
            {
                _context.Tournaments.Add(tournament);
            }
            else
            {
                _context.Entry(tournament).State = System.Data.EntityState.Modified;
            }
        }

        void ITournamentRepository.Remove(Tournament tournament)
        {
            _context.Entry(tournament).State = System.Data.EntityState.Deleted;
        }

        void ITournamentRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
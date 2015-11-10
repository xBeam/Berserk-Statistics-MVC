using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class TournamentRepository : ITournamentRepository
    {
        private DalContext _context;

        public TournamentRepository(DalContext context)
        {
            _context = context;
        }

        IQueryable<Tournament> ITournamentRepository.All
        {
            get { return _context.Tournaments.All; }
        }

        void ITournamentRepository.InsertOrUpdate(Tournament tournament)
        {
            _context.Tournaments.InsertOrUpdate(tournament);
        }

        void ITournamentRepository.Remove(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
        }

        void ITournamentRepository.Save()
        {
            _context.Tournaments.Save();
        }
    }
}
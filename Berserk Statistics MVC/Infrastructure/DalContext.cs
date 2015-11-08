using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class DalContext : IDalContext
    {
        DatabaseContext _database;
        private IUserProfileRepository _users;
        private ITournamentRepository _tournaments;
        private ICardRepository _cards;
        private IMemberRepository _members;

        public DalContext()
        {
            _database = new DatabaseContext();
        }

        public IUserProfileRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_database);
                }
                return _users;
            }
        }

        public ITournamentRepository Tournaments
        {
            get
            {
                if (_tournaments == null)
                {
                    _tournaments = new TournamentRepository(_database);
                }
                return _tournaments;
            }
        }

        public ICardRepository Cards
        {
            get
            {
                if (_cards == null)
                {
                    _cards = new CardRepository(_database);
                }
                return _cards;
            }
        }

        public IMemberRepository Members
        {
            get
            {
                if (_members == null)
                {
                    _members = new MemberRepository(_database);
                }
                return _members;
            }
        }
    }
}
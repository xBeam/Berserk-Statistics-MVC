using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class DalContext : IDalContext
    {
        DatabaseContext _database;
        private IUserProfileRepository _users;
        private ITournamentRepository _tournaments;
        private IMemberRepository _members;
        private IRoundRepository _rounds;
        private ITableRepository _tables;

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

        public IRoundRepository Rounds
        {
            get
            {
                if (_rounds == null)
                {
                    _rounds = new RoundRepository(_database);
                }
                return _rounds;
            }
        }

        public ITableRepository Tables
        {
            get
            {
                if (_tables == null)
                {
                    _tables = new TableRepository(_database);
                }
                return _tables;
            }
        }
    }
}
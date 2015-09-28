using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class DalContext : IDalContext
    {
        DatabaseContext _database;
        private IUserProfileRepository _users;
        private IRatingRepository _ratings;

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

        public IRatingRepository Ratings
        {
            get
            {
                if (_ratings == null)
                {
                    _ratings = new RatingRepository(_database);
                }
                return _ratings;
            }
        }
    }
}
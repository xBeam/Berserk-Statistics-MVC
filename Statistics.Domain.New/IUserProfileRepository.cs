using System.Linq;

namespace Statistics.Domain.New
{
    public interface IUserProfileRepository
    {
        IQueryable<UserProfile> All { get; }
        UserProfile CurrentUser { get; }
        void InsertOrUpdate(UserProfile user);
        void Remove(UserProfile user);
        void Save();
    }
}

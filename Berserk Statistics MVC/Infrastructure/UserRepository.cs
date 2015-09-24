using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statistics.Domain;
using WebMatrix.WebData;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class UserRepository : IUserProfileRepository
    {
        DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        IQueryable<UserProfile> IUserProfileRepository.All
        {
            get { return _context.UserProfiles; }
        }

        UserProfile IUserProfileRepository.CurrentUser
        {
            get
            {
                return
                    _context
                    .UserProfiles
                    .Include("Ratings")
                    .FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);

            }
        }

        void IUserProfileRepository.InsertOrUpdate(UserProfile user)
        {
            if (user.UserId == default(int))
            {
                _context.UserProfiles.Add(user);
            }
            else
            {
                _context.Entry(user).State = System.Data.EntityState.Modified;
            }
        }

        void IUserProfileRepository.Remove(UserProfile user)
        {
            _context.Entry(user).State = System.Data.EntityState.Deleted;
        }

        void IUserProfileRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
using System.Data.Entity;

namespace Berserk_Statistics_MVC.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() 
            : base("name=DatabaseContext")
        {
        }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Card> Cards { get; set; }

        //public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<TournamentList> TournamentLists { get; set; }
    }
}
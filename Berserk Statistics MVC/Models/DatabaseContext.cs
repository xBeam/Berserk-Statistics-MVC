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

        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public DbSet<TournamentList> TournamentLists { get; set; }
        
        public DbSet<Member> Members { get; set; }
        
        public DbSet<Round> Rounds { get; set; }
    }
}
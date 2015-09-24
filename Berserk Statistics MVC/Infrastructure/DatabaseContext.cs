using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
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
        
        public DbSet<Member> Members { get; set; }
        
        public DbSet<Round> Rounds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
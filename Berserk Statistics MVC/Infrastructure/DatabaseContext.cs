using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() 
            : base("name=BerserkDB")
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public DbSet<Member> Members { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
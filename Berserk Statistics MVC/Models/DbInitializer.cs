using System.Data.Entity;
using Berserk_Statistics_MVC.Infrastructure;

namespace Berserk_Statistics_MVC.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
        }
    }
}
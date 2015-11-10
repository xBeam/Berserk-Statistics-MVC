using System.Data.Entity;
using Berserk_Statistics_MVC.Infrastructure;

namespace Berserk_Statistics_MVC.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<DalContext>
    {
        protected override void Seed(DalContext context)
        {
            base.Seed(context);
        }
    }
}
using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class TableRepository : ITableRepository
    {
        private DatabaseContext _context;

        public TableRepository(DatabaseContext context)
        {
            _context = context;
        }

        IQueryable<Table> ITableRepository.All
        {
            get { return _context.Tables; }
        }

        void ITableRepository.InsertOrUpdate(Table table)
        {
            if (table.TableId == default(int))
            {
                _context.Tables.Add(table);
            }
            else
            {
                _context.Entry(table).State = System.Data.EntityState.Modified;
            }
        }

        void ITableRepository.Remove(Table table)
        {
            _context.Entry(table).State = System.Data.EntityState.Deleted;
        }

        void ITableRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
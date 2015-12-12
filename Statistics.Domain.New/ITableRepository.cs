using System.Linq;

namespace Statistics.Domain
{
    public interface ITableRepository
    {
        IQueryable<Table> All { get; }
        void InsertOrUpdate(Table table);
        void Remove(Table table);
        void Save();
    }
}

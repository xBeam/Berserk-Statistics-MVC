using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Domain
{
    public interface IRatingRepository
    {
        IQueryable<Rating> All { get; }
        void InsertOrUpdate(Rating rating);
        void Remove(Rating rating);
        void Save();
    }
}

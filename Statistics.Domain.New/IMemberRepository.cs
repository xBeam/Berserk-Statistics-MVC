using System.Linq;

namespace Statistics.Domain
{
    public interface IMemberRepository
    {
        IQueryable<Member> All { get; }
        void InsertOrUpdate(Member member);
        void Remove(Member member);
        void Save();
    }
}

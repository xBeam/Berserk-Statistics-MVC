using System.ComponentModel;
using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class MemberRepository : IMemberRepository
    {
        private DalContext _context;

        public MemberRepository(DalContext context)
        {
            _context = context;
        }

        IQueryable<Member> IMemberRepository.All
        {
            get { return _context.Members.All; }
        }

        void IMemberRepository.InsertOrUpdate(Member member)
        {
            _context.Members.InsertOrUpdate(member);
        }

        void IMemberRepository.Remove(Member member)
        {
            _context.Members.Remove(member);
        }

        void IMemberRepository.Save()
        {
            _context.Members.Save();
        }
    }
}
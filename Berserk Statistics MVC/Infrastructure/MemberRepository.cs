using System.ComponentModel;
using System.Linq;
using Statistics.Domain;

namespace Berserk_Statistics_MVC.Infrastructure
{
    public class MemberRepository : IMemberRepository
    {
        private DatabaseContext _context;

        public MemberRepository(DatabaseContext context)
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
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
            get { return _context.Members; }
        }

        void IMemberRepository.InsertOrUpdate(Member member)
        {
            if (member.MemberId == default(int))
            {
                _context.Members.Add(member);
            }
            else
            {
                _context.Entry(member).State = System.Data.EntityState.Modified;
            }
        }

        void IMemberRepository.Remove(Member member)
        {
            _context.Entry(member).State = System.Data.EntityState.Deleted;
        }

        void IMemberRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
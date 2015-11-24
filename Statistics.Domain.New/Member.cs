using System.Collections.Generic;

namespace Statistics.Domain
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public UserProfile Owner { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
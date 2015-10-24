using System.Collections.Generic;

namespace Statistics.Domain
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}
using System.Collections.Generic;

namespace Statistics.Domain.New
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string DeckList { get; set; }
        public List<Round> Rounds { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
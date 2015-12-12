using System.Collections.Generic;

namespace Statistics.Domain
{
    public class Round
    {
        public int RoundId { get; set; }
        public string RoundName { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}

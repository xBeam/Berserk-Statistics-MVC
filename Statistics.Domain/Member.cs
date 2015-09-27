using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statistics.Domain;

namespace Statistics.Domain
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string DeckList { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
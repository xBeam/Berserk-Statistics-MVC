using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berserk_Statistics_MVC.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int UserId { get; set; }
        public string DeckList { get; set; }
        public List<TournamentList> TournamentLists { get; set; }
        public List<Round> Rounds { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Rating> Ratings { get; set; }
        public UserProfile User { get; set; }
    }
}
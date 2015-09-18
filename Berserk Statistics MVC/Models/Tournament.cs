using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berserk_Statistics_MVC.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int TournamentListId { get; set; }
        public int UserId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public decimal MemberPoints { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        public TournamentList TournamentList { get; set; }
        public List<Member> Members { get; set; }
        public List<Round> Rounds { get; set; }
        public UserProfile User { get; set; }
    }
}
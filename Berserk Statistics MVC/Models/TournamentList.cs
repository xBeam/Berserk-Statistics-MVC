using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berserk_Statistics_MVC.Models
{
    public class TournamentList
    {
        public int TournamentListId { get; set; }
        public string TournamentListName { get; set; }
        public int UserId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int MembersNumber { get; set; }
        public int RatingId { get; set; }
        public string RatingName { get; set; }
        public DateTime Date { get; set; }
        public Member Member { get; set; }
        public UserProfile User { get; set; }
    }
}
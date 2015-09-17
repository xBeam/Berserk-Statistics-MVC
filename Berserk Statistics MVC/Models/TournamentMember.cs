using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berserk_Statistics_MVC.Models
{
    public class TournamentMember
    {
        public int TournamentMemberId { get; set; }
        public string TournamentMemberName { get; set; }
        public int TournamentId { get; set; }
        public int UserId { get; set; }
        public string DeckList { get; set; }
        public Tournament Tournament { get; set; }
    }
}
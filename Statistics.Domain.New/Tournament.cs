using System;
using System.Collections.Generic;

namespace Statistics.Domain
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public UserProfile Owner { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public DateTime Date { get; set; }
    }
}
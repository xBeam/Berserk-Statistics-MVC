using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Statistics.Domain
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public UserProfile Owner { get; set; }
        public ICollection<Member> Members { get; set; }
        public DateTime Date { get; set; }
    }
}
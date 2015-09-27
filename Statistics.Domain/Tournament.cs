﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statistics.Domain
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public UserProfile Owner { get; set; }
    }
}
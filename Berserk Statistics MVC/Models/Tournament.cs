﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berserk_Statistics_MVC.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public int UserId { get; set; }
        public int MemberId { get; set; }
        public int MembersNumber { get; set; }
        public int RatingId { get; set; }
        public DateTime Date { get; set; }
        public Rating Rating { get; set; }
    }
}
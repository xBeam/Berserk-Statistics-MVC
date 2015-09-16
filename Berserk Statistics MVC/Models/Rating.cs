using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berserk_Statistics_MVC.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int MemberId { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int TournamentsNumber { get; set; }
        public decimal PercentPoint { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Domain
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
        public Member Member { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public UserProfile Owner { get; set; }
    }
}

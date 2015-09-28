using System.Collections.Generic;

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
        public ICollection<Tournament> Tournaments { get; set; }
        public UserProfile Owner { get; set; }
    }
}

namespace Statistics.Domain
{
    public class Round
    {
        public int RoundId { get; set; }
        public Tournament Tournament { get; set; }
        public Member FirstMember { get; set; }
        public Member SecondMember { get; set; }
    }
}
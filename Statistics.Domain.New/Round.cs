namespace Statistics.Domain
{
    public class Round
    {
        public int RoundId { get; set; }
        public string RoundName { get; set; }
        public int TournamentId { get; set; }
        public int FirstMemberId { get; set; }
        public string FirstMemberName { get; set; }
        public int SecondMemberId { get; set; }
        public string SecondMemberName { get; set; }
        public Tournament Tournament { get; set; }
        public Member FirstMember { get; set; }
        public Member SecondMember { get; set; }
    }
}
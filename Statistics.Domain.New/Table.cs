namespace Statistics.Domain
{
    public class Table
    {
        public int TableId { get; set; }
        public Round Round { get; set; }
        public Member FirstMember { get; set; }
        public Member SecondMember { get; set; }
        public int FirstMemberPoints { get; set; }
        public int SecondMemberPoints { get; set; }
    }
}

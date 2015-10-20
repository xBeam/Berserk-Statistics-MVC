namespace Statistics.Domain
{
    public interface IDalContext
    {
        IUserProfileRepository Users { get; }
        IRatingRepository Ratings { get; }
        ITournamentRepository Tournaments { get; }
        ICardRepository Cards { get; }
        IMemberRepository Members { get; }
    }
}
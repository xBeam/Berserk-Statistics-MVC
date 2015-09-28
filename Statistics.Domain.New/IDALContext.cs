namespace Statistics.Domain
{
    public interface IDalContext
    {
        IUserProfileRepository Users { get; }
        IRatingRepository Ratings { get; }
    }
}
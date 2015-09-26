namespace Statistics.Domain.New
{
    public interface IDalContext
    {
        IUserProfileRepository Users { get; }
        IRatingRepository Ratings { get; }
    }
}
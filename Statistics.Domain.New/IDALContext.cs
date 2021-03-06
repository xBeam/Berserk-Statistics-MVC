﻿namespace Statistics.Domain
{
    public interface IDalContext
    {
        IUserProfileRepository Users { get; }
        ITournamentRepository Tournaments { get; }
        IMemberRepository Members { get; }
        IRoundRepository Rounds { get; }
        ITableRepository Tables { get; }
    }
}
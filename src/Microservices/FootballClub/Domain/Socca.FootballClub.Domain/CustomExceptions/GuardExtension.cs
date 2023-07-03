using System;
using System.Reflection.Metadata;
using Socca.Domain.Core.GuardClause;

namespace Socca.Domain.Core.GuardClause
{
    public static class GuardExtension
    {
        public static void NullFootballClub(this IGuardClause guardClause, string name,
            Socca.FootballClub.Domain.Entities.FootballClub footballClub)
        {
            if (footballClub == null)
                throw new FootballClubNotFoundException(name);
        }

        public static void NullFootballClub(this IGuardClause guardClause, int id,
            Socca.FootballClub.Domain.Entities.FootballClub footballClub)
        {
            if (footballClub == null)
                throw new FootballClubNotFoundException(id);
        }
    }
}


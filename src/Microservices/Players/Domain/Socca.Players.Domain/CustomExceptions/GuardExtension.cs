using System;
using Socca.Domain.Core.GuardClause;

namespace Socca.Domain.Core.GuardClause
{
    public static class GuardExtension
    {
        public static void NullPlayer(this IGuardClause guardClause, string name, Socca.Players.Domain.Entities.Player player)
        {
            if (player == null)
                throw new PlayerNotFoundException(name);
        }

        public static void NullPlayer(this IGuardClause guardClause, int id, Socca.Players.Domain.Entities.Player player)
        {
            if (player == null)
                throw new PlayerNotFoundException(id);
        }
    }
}


using System;
namespace Socca.Domain.Core.GuardClause
{

    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(string name)
            : base($"Player {name} was not found.")
        {
        }
        public PlayerNotFoundException(int id)
            : base($"Player with Id {id} was not found.")
        {
        }
    }
}


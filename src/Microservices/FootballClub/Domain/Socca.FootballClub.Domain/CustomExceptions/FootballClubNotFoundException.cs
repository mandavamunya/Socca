using System;
namespace Socca.Domain.Core.GuardClause
{
    public class FootballClubNotFoundException: Exception
    {
        public FootballClubNotFoundException(string name)
            : base($"{name} Football club was not found.")
        {
        }
        public FootballClubNotFoundException(int id)
            : base($"Football club with Id {id} was not found.")
        {
        }
    }
}


using System;
using Socca.Domain.Core.Interfaces;

namespace Socca.Domain.Core.GuardClause
{
    public class Guard: IGuardClause
    {
        public static IGuardClause Against { get; } = (IGuardClause)new Guard();
        //public static object Against { get; set; }

        public Guard()
        {
        }
    }
}


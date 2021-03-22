using System.Collections.Generic;

namespace Socca.Players.Data.Context
{
    public class SamplePlayerData
    {

        private static readonly object padlock = new object();
        private static SamplePlayerData _instance;

        public static SamplePlayerData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new SamplePlayerData();
                    return _instance;
                }
            }
        }

        public List<Domain.Entities.Player> Players
        {
            get
            {
                return new List<Domain.Entities.Player>()
                {

                    new Domain.Entities.Player()
                    {
                        FirstName = "Hakim",
                        LastName = "Ziyech",
                        Position = "Midfielder"
                    },
                    new Domain.Entities.Player() 
                    {
                        FirstName = "Paul",
                        LastName = "Pogba",
                        Position = "Midfielder"
                    },
                    new Domain.Entities.Player()
                    {
                        FirstName = "Edinson",
                        LastName = "Cavani",
                        Position = "Forward"
                    },
                    new Domain.Entities.Player()
                    {
                        FirstName = "Timo",
                        LastName = "Werner",
                        Position = "Forward"
                    }
                };
            }
        }

    }
}

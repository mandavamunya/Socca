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
                        Position = "Midfielder",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/d/dd/Hakim_Ziyech_2020.jpg" 
                    },
                    new Domain.Entities.Player() 
                    {
                        FirstName = "Paul",
                        LastName = "Pogba",
                        Position = "Midfielder",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/c/cc/FRA-ARG_%2811%29_-_Paul_Pogba_%28cropped_2%29.jpg"
                    },
                    new Domain.Entities.Player()
                    {
                        FirstName = "Edinson",
                        LastName = "Cavani",
                        Position = "Forward",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/8/88/Edinson_Cavani_2018.jpg"
                    },
                    new Domain.Entities.Player()
                    {
                        FirstName = "Timo",
                        LastName = "Werner",
                        Position = "Forward",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/c/c0/20180602_FIFA_Friendly_Match_Austria_vs._Germany_Timo_Werner_850_0621.jpg"
                    }
                };
            }
        }

    }
}

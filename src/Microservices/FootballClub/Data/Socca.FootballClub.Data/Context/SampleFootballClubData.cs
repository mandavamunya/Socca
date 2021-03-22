using System.Collections.Generic;

namespace Socca.FootballClub.Data.Context
{
    public class SampleFootballClubData
    {
        private static readonly object padlock = new object();
        private static SampleFootballClubData _instance;

        public static SampleFootballClubData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new SampleFootballClubData();
                    return _instance;
                }
            }
        }

        public List<Domain.Entities.FootballClub> FootballClubs
        {
            get
            {
                return new List<Domain.Entities.FootballClub>()
                {

                    new Domain.Entities.FootballClub()
                    {
                        Location = "Greater Manchester, England",
                        Name = "Manchester United Football Club"
                    },
                    new Domain.Entities.FootballClub()
                    {
                        Location = "Fulham, London",
                        Name = "Chelsea Football Club"
                    }

                };
            }
        }
    }
}

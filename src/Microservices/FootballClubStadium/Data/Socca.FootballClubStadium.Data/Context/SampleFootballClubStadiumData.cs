using System.Collections.Generic;

namespace Socca.FootballClubStadium.Data.Context
{
    public class SampleFootballClubStadiumData
    {
        private static readonly object padlock = new object();
        private static SampleFootballClubStadiumData _instance;

        public static SampleFootballClubStadiumData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new SampleFootballClubStadiumData();
                    return _instance;
                }
            }
        }

        public List<Domain.Entities.FootballClubStadium> Data
        {
            get
            {
                return new List<Domain.Entities.FootballClubStadium>()
                {

                    new Domain.Entities.FootballClubStadium()
                    {
                        StadiumId = 1,
                        FootballClubId = 2
                    },
                    new Domain.Entities.FootballClubStadium()
                    {
                        StadiumId = 2,
                        FootballClubId = 1
                    }

                };
            }
        }
    }
}

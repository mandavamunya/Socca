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
                        Name = "Manchester United Football Club",
                        Description = "Manchester United Football Club is a professional football club. Founded in 1878, the club competes in the Premier League, the top flight of English football.",
                        Image = "https://upload.wikimedia.org/wikipedia/en/7/7a/Manchester_United_FC_crest.svg"
                    },
                    new Domain.Entities.FootballClub()
                    {
                        Location = "Fulham, London",
                        Name = "Chelsea Football Club",
                        Description = "Chelsea Football Club is an English professional football club. Founded in 1905, the club competes in the Premier League, the top division of English football.",
                        Image = "https://upload.wikimedia.org/wikipedia/en/c/cc/Chelsea_FC.svg"
                    },
                    new Domain.Entities.FootballClub()
                    {
                        Location = "Greater Manchester, England",
                        Name = "Manchester City Football Club",
                        Description = "Manchester City Football Club is an English football club. Founded in 1880, the club competes in the Premier League, the top flight of English football.",
                        Image = "https://upload.wikimedia.org/wikipedia/en/e/eb/Manchester_City_FC_badge.svg" 
                    },
                    new Domain.Entities.FootballClub()
                    {
                        Location = "Liverpool, England",
                        Description = "Liverpool Football Club is a professional football club. Founded in 1892, the club competes in the Premier League, the top tier of English football.",
                        Name = "Liverpool Football Club",
                        Image = "https://upload.wikimedia.org/wikipedia/en/0/0c/Liverpool_FC.svg"
                    }
                };
            }
        }
    }
}

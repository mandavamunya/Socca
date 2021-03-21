using System.Collections.Generic;

namespace Socca.Stadium.Data.Context
{
    public class SampleStadiumData
    {
        private static readonly object padlock = new object();
        private static SampleStadiumData _instance;

        public static SampleStadiumData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new SampleStadiumData();
                    return _instance;
                }
            }
        }

        public List<Domain.Entities.Stadium> Stadiums
        {
            get
            {
                return new List<Domain.Entities.Stadium>()
                {

                    new Domain.Entities.Stadium()
                    {
                        Name = "Old Trafford",
                        Capacity = 10000
                    },
                    new Domain.Entities.Stadium()
                    {
                        Name = "Stamford Bridge",
                        Capacity = 8000
                    }

                };
            }
        }
    }
}

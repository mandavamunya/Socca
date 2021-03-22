using System.Collections.Generic;

namespace Socca.PlayerTransfers.Data.Context
{
    public class SamplePlayerTransferData
    {

        private static readonly object padlock = new object();
        private static SamplePlayerTransferData _instance;

        public static SamplePlayerTransferData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new SamplePlayerTransferData();
                    return _instance;
                }
            }
        }

        public List<Domain.Entities.PlayerTransfer> Players
        {
            get
            {
                return new List<Domain.Entities.PlayerTransfer>()
                {

                    new Domain.Entities.PlayerTransfer()
                    {
                        FromTeam = 1,
                        ToTeam = 2,
                        PlayerId = 1
                    },
                    new Domain.Entities.PlayerTransfer()
                    {
                        FromTeam = 2,
                        ToTeam = 1,
                        PlayerId = 4
                    }

                };
            }
        }

    }
}

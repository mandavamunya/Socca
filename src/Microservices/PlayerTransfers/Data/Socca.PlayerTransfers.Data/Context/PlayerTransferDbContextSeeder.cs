using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Socca.PlayerTransfers.Data.Context
{
    public class PlayerTransferDbContextSeeder
    {

        public static async Task SeedAsync(PlayerTransferDbContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.PlayerTransfers.Any())
                {
                    await dbContext.PlayerTransfers.AddRangeAsync(SamplePlayerTransferData.Instance.Players);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<PlayerTransferDbContext>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

    }
}

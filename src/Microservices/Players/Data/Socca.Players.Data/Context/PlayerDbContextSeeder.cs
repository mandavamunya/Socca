using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Socca.Players.Data.Context
{
    public class PlayerDbContextSeeder
    {

        public static async Task SeedAsync(PlayerDbContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.Players.Any())
                {
                    await dbContext.Players.AddRangeAsync(SamplePlayerData.Instance.Players);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<PlayerDbContextSeeder>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

    }
}

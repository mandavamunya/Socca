using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Socca.FootballClub.Data.Context
{
    public class FootballClubDbContextSeeder
    {
        public static async Task SeedAsync(FootballClubDbContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.FootballClubs.Any())
                {
                    await dbContext.FootballClubs.AddRangeAsync(SampleFootballClubData.Instance.FootballClubs);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<FootballClubDbContextSeeder>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

    }
}

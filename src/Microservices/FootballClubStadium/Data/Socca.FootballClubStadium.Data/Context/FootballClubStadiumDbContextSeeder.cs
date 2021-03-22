using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Socca.FootballClubStadium.Data.Context
{
    public class FootballClubStadiumDbContextSeeder
    {

        public static async Task SeedAsync(FootballClubStadiumDbContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.FootballClubStadiums.Any())
                {
                    await dbContext.FootballClubStadiums.AddRangeAsync(SampleFootballClubStadiumData.Instance.Data);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<FootballClubStadiumDbContextSeeder>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}

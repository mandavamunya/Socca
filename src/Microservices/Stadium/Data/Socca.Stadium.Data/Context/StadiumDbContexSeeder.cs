using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Socca.Stadium.Data.Context
{
    public class StadiumDbContexSeeder
    {
        public static async Task SeedAsync(StadiumDbContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.Stadiums.Any())
                {
                    await dbContext.Stadiums.AddRangeAsync(SampleStadiumData.Instance.Stadiums);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<StadiumDbContexSeeder>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}

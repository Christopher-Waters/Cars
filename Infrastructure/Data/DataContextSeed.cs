using System.Text.Json;
using Microsoft.Extensions.Logging;
using Core.Entities;

namespace Infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Makes.Any())
                {
                    var makeData = File.ReadAllText("../Infrastructure/Data/SeedData/makes.json");

                    var makes = JsonSerializer.Deserialize<List<Make>>(makeData);

                    foreach (var make in makes)
                    {
                        context.Makes.Add(make);                      
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ModelYears.Any())
                {
                    var modelData = File.ReadAllText("../Infrastructure/Data/SeedData/models.json");

                    var models = JsonSerializer.Deserialize<List<ModelYear>>(modelData);

                    foreach (var model in models)
                    {
                        context.ModelYears.Add(model);                      
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
        
    }
}
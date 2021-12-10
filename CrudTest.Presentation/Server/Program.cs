using CrudTest.Domain;
using CrudTest.Domain.Seed;
using CrudTest.Presentation.Server.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
            .Build()
            .MigrateDatabase<AppDbContext>((context, services) =>
            {
                var logger = (ILogger<AppDbContextDataSeeder>)services.GetService(typeof(ILogger<AppDbContextDataSeeder>));
                AppDbContextDataSeeder
                .SeedAsync(context, logger)
                .Wait();
            })
            .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

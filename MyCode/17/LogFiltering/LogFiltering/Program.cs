using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogFiltering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureLogging((ctx, logging) =>
                    {
                        logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                    });
                    builder.UseStartup<Startup>();
                });
    }
}
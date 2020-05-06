using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace SettingHostConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder().ConfigureWebHostDefaults(x =>
           {
               x.UseConfiguration(GetLaunchConfiguration());
               x.UseStartup<Startup>();
           });

        public static IConfiguration GetLaunchConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", false, false)
                .Build();
    }
}
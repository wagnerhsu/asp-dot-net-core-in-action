using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace api.shopping.com
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x => x.UseStartup<Startup>());
    }
}
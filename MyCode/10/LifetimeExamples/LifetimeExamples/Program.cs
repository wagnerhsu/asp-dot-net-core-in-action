using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LifetimeExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder => builder
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options =>
                {
                    // set the value to true to always validate scopes,
                    // or use the alternative definition below to only
                    // validate in dev environments
                    options.ValidateScopes = true;
                })
                //.UseDefaultServiceProvider((ctx, options) =>
                //{
                //    options.ValidateScopes = ctx.HostingEnvironment.IsDevelopment();
                //})
               );
    }
}
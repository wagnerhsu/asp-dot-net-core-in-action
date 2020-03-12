using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LifetimeExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
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
                ;
    }
}
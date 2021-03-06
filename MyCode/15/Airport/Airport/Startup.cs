using Airport.Authorization;
using Airport.Data;
using Airport.Models;
using Airport.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddControllersWithViews();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "CanEnterSecurity",
                    policyBuilder => policyBuilder
                        .RequireClaim(Claims.BoardingPassNumber));

                options.AddPolicy(
                    "CanAccessLounge",
                    policyBuilder => policyBuilder.AddRequirements(
                        new MinimumAgeRequirement(18),
                        new AllowedInLoungeRequirement()
                    ));
            });

            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddSingleton<IAuthorizationHandler, FrequentFlyerHandler>();
            services.AddSingleton<IAuthorizationHandler, BannedFromLoungeHandler>();
            services.AddSingleton<IAuthorizationHandler, IsAirlineEmployeeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Airport/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Airport}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
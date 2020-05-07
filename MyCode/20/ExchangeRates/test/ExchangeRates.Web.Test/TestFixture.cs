using ExchangeRates.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace ExchangeRateHelper.Test
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        public TestFixture()
        {
            // Currently TestServer only support IWebHostBuilder
            IWebHostBuilder builder = WebHost.CreateDefaultBuilder().UseStartup<Startup>();
            //var builder = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<StartupBase>()).Build();
            Server = new TestServer(builder);

            Client = Server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        public HttpClient Client { get; }
        public TestServer Server { get; }

        public void Dispose()
        {
            Client?.Dispose();
            Server?.Dispose();
        }
    }
}
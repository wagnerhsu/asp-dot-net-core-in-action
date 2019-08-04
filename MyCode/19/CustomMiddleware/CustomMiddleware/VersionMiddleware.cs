using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    public class VersionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly string _version =
            PlatformServices.Default.Application.ApplicationVersion;

        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var version = new { Version = _version };
            var content = JsonConvert.SerializeObject(version);
            await context.Response.WriteAsync(content);
        }
    }
}
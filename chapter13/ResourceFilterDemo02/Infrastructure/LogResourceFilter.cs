using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ResourceFilterDemo01.Infrastructure
{
    public class LogResourceFilter : Attribute, IResourceFilter
    {
        ILogger<LogResourceFilter> _logger;
        public LogResourceFilter(ILogger<LogResourceFilter> logger)
        {
            _logger = logger;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogDebug("Executing IResourceFilter.OnResourceExecuting");
            //context.Result = new ContentResult()
            //{
            //    Content = "IResourceFilter - Short-circuiting ",
            //};
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogDebug($"Executing IResourceFilter.OnResourceExecuted: cancelled {context.Canceled}");
        }
    }
}

using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionExample.Services
{
    public class FacebookSender : IMessageSender
    {
        ILogger<FacebookSender> _logger;
        public FacebookSender(ILogger<FacebookSender> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string message)
        {
            _logger.LogDebug($"Sending Facebook message: {message}");
        }
    }
}

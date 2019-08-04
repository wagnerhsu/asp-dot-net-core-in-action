using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionExample.Services
{
    public class EmailSender : IMessageSender
    {
        ILogger<EmailSender> _logger;
        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string message)
        {
            _logger.LogDebug($"Sending Email message: {message}");
        }
    }
}

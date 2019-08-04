using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionExample.Services
{
    public class SmsSender : IMessageSender
    {
        ILogger<SmsSender> _logger;
        public SmsSender(ILogger<SmsSender> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string message)
        {
            _logger.LogDebug($"Sending SMS: {message}");
        }
    }
}

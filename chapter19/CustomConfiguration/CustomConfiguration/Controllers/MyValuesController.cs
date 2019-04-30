using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CustomConfiguration.Controllers
{
    [Produces("application/json")]
    [Route("api/MyValues")]
    public class MyValuesController : Controller
    {
        ILogger<MyValuesController> _logger;
        IConfiguration _configuration;
        public MyValuesController(ILogger<MyValuesController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public CurrencyOptions Get()
        {
            var result = _configuration.GetSection("Currencies").Get<CurrencyOptions>();
            return result;
        }
    }
}
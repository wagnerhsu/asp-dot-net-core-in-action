using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFilterDemo03.Infrastructure;

namespace ResourceFilterDemo03.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [FeatureEnabled(IsEnabled = false)]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [FeatureEnabled(IsEnabled = true)]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
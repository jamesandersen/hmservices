using System.Collections.Generic;
using HMServices.Models;
using Microsoft.AspNetCore.Mvc;
using HMServices.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HMServices.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISECService _secService;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ISECService secService, ILogger<ValuesController> logger) {
            _secService = secService;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Symbol>> Get()
        {
            _logger.LogTrace("Get Values!");
            return await _secService.GetSymbols();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

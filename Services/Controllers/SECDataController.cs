using System.Net;
using HMServices.Models;
using HMServices.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using HMServices.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HMServices.Controllers
{
    [Route("api/[controller]")]
    public class SECDataController : Controller
    {
        private readonly ISECService _secService;
        private readonly ILogger<ValuesController> _logger;

        public SECDataController(ISECService secService, ILogger<ValuesController> logger) {
            _secService = secService;
            _logger = logger;
        }

        // GET api/values
        [HttpGet("{ticker}/symbol")]
        public async Task<Symbol> GetSymbol(string ticker)
        {
            _logger.LogTrace(string.Format("Get {0} symbol", ticker));
            var symbol = await _secService.GetSymbolByTicker(ticker);

            if (symbol != null) return symbol;

            
            throw new HttpException(HttpStatusCode.NotFound);
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

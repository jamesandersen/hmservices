using System.Net;
using HMServices.Models;
using HMServices.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using HMServices.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        // GET api/secdata/AAPL/symbol
        [HttpGet("{ticker}/symbol")]
        public async Task<Symbol> GetSymbol(string ticker)
        {
            _logger.LogTrace(string.Format("Get {0} symbol", ticker));
            var symbol = await _secService.GetSymbolByTicker(ticker);

            if (symbol != null) return symbol;
            
            throw new HttpException(HttpStatusCode.NotFound);
        }

        // GET api/secdata/AAPL/filing
        [HttpGet("{ticker}/filing")]
        public async Task<Filing> GetMostRecentFiling(string ticker, string type = "10-K")
        {
            _logger.LogTrace(string.Format("Get {0} most recent {1} filing", ticker, type));
            var filing = await _secService.GetMostRecentFilingByTicker(ticker, type);

            if (filing != null) return filing;
            
            throw new HttpException(HttpStatusCode.NotFound);
        }

        // GET api/secdata/search/AM e.g AMZN
        [HttpGet("search/{query}")]
        public async Task<IEnumerable<Symbol>> SearchSymbol(string query)
        {
            _logger.LogTrace(string.Format("Searching for symbols starting with {0}", query));
            return await _secService.SearchSymbols(query);
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

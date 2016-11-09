using System.Collections.Generic;
using System.Linq;
using HMServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HMServices.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<SECOptions> _options;

        public ValuesController(IOptions<SECOptions> options) {
            _options = options;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Symbol> Get()
        {
            var client = new MongoClient(_options.Value.MongoConnectionString);
            var db = client.GetDatabase(_options.Value.DatabaseName);
            var symbolsCol = db.GetCollection<Symbol>("symbols");
            var symbols = symbolsCol.AsQueryable().Take(10);
            return symbols.ToList();
            //return new string[] { "value1", "value2", "value3" };
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

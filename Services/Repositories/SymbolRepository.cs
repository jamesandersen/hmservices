using System.Collections.Generic;
using HMServices.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HMServices.Repositories
{

    public class SymbolRepository : ISymbolRepository
    {
        private readonly IOptions<SECOptions> _options;

        public SymbolRepository(IOptions<SECOptions> options) {
            _options = options;
        }

        public async Task<Symbol> GetSymbolByTicker(string ticker)
        {
            var client = new MongoClient(_options.Value.MongoConnectionString);
            var db = client.GetDatabase(_options.Value.DatabaseName);
            
            var symbolsCol = db.GetCollection<Symbol>("symbols");
            
            var symbol = await symbolsCol.Find(_ => _.Ticker.ToLower().Contains(ticker.ToLower())).FirstOrDefaultAsync();
            return symbol;
        }

        public async Task<IEnumerable<Symbol>> GetSymbols()
        {
            var client = new MongoClient(_options.Value.MongoConnectionString);
            var db = client.GetDatabase(_options.Value.DatabaseName);
            
            var symbolsCol = db.GetCollection<Symbol>("symbols");
            
            var symbols = symbolsCol.Find(new BsonDocument());
            symbols.Options.Limit = 10;
            return await symbols.ToListAsync();
        }
    }

}
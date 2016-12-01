using System.Collections.Generic;
using HMServices.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace HMServices.Repositories
{

    public class SymbolRepository : ISymbolRepository
    {
        private static MongoClient client;
        private static IMongoDatabase db;

        private readonly IOptions<SECOptions> _options;

        public SymbolRepository(IOptions<SECOptions> options) {
            _options = options;
            client = new MongoClient(_options.Value.MongoConnectionString);
            db = client.GetDatabase(_options.Value.DatabaseName);
        }

        public async Task<Symbol> GetSymbolByTicker(string ticker)
        {
            var symbolsCol = db.GetCollection<Symbol>("symbols");
            
            var symbol = await symbolsCol.Find(_ => _.Ticker.ToLower().Contains(ticker.ToLower())).FirstOrDefaultAsync();
            return symbol;
        }

        public async Task<IEnumerable<Symbol>> GetSymbols()
        {
            var symbolsCol = db.GetCollection<Symbol>("symbols");
            
            var symbols = symbolsCol.Find(new BsonDocument());
            symbols.Options.Limit = 10;
            return await symbols.ToListAsync();
        }

        public async Task<Filing> GetMostRecentFilingByTicker(string ticker, string type = "10-K")
        {
            var filingsCol = db.GetCollection<Filing>("filings");
            
            var filing = await filingsCol.Find(_ => 
                _.TradingSymbol.ToLower() == ticker.ToLower() &&
                _.DocumentType == type).Sort(Builders<Filing>.Sort.Descending(_ => _.dateFiled))
                .FirstOrDefaultAsync();
            return filing;
        }

        public async Task<IEnumerable<Symbol>> SearchSymbols(string tickerQuery)
        {
            var symbolsCol = db.GetCollection<Symbol>("symbols");
            
            var symbols = symbolsCol.Find(_ => 
                _.Ticker.ToUpper().StartsWith(tickerQuery.ToUpper()))
                .Sort(Builders<Symbol>.Sort.Descending(_ => _.Ticker));
            symbols.Options.Limit = 10;
                
            return await symbols.ToListAsync();
        }
    }

}
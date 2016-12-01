using HMServices.Models;
using HMServices.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HMServices.Services
{
    public class SECService : ISECService
    {
        private readonly ISymbolRepository _symbolRepo;

        public SECService(ISymbolRepository symbolRepo) {
            this._symbolRepo = symbolRepo;
        }

        public Task<Filing> GetMostRecentFilingByTicker(string ticker, string type)
        {
            return this._symbolRepo.GetMostRecentFilingByTicker(ticker, type);
        }

        public Task<Symbol> GetSymbolByTicker(string ticker)
        {
            return this._symbolRepo.GetSymbolByTicker(ticker);
        }

        public Task<IEnumerable<Symbol>> GetSymbols()
        {
            return _symbolRepo.GetSymbols();
        }

        public Task<IEnumerable<Symbol>> SearchSymbols(string tickerQuery)
        {
            return _symbolRepo.SearchSymbols(tickerQuery);
        }
    }
}
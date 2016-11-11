using HMServices.Models;
using HMServices.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMServices.Services {

    public class SECService : ISECService
    {
        private readonly ISymbolRepository _symbolRepo;

        public SECService(ISymbolRepository symbolRepo) {
            this._symbolRepo = symbolRepo;
        }
        public Task<IEnumerable<Symbol>> GetSymbols()
        {
            return _symbolRepo.GetSymbols();
        }
    }
}
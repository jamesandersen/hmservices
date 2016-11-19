namespace HMServices.Repositories {

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HMServices.Models;

    public interface ISymbolRepository {
        Task<IEnumerable<Symbol>> GetSymbols();

        Task<Symbol> GetSymbolByTicker(string ticker);
    }
}
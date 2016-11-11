using HMServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMServices.Services {
    public interface ISECService {
        Task<IEnumerable<Symbol>> GetSymbols();
    }
}
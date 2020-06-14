using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumberMultiplicationApp.Utilities
{
    public interface IPrimeNumberGenerator
    {
        Task<List<int>> GeneratePrimes(int i);
    }
}

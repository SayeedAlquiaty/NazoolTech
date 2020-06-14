using PrimeNumberMultiplicationApp.DTOs;
using PrimeNumberMultiplicationApp.DTOs.Requests;
using PrimeNumberMultiplicationApp.Services.Interfaces;
using PrimeNumberMultiplicationApp.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumberMultiplicationApp.Services
{
    public class PrimeNumberMultiplicationService : IPrimeNumberMultiplicationService
    {
        private readonly IPrimeNumberGenerator primeNumberGenerator;

        public PrimeNumberMultiplicationService(IPrimeNumberGenerator primeNumberGenerator)
        {
            this.primeNumberGenerator = primeNumberGenerator;
        }

        public async Task<PrimeNumberMultiplicationResponse> GetMultiplicationTable(PrimeNumberMultiplicationRequest request)
        {
            var response = new PrimeNumberMultiplicationResponse();

            if (request == null || request.Number == null || request.Number <= 0)
            {
                response.Data = null;
                response.AddErrorMessage("Invalid request");
                return response;
            }
            
            var primenumbers = await primeNumberGenerator.GeneratePrimes(request.Number.Value);
            List<List<double>> PrimeMultiplicationTable = new List<List<double>>();
            List<int> firstRow = new List<int>();
            firstRow.Add(1);
            firstRow.AddRange(primenumbers.Select(x => x));

            foreach (int n in firstRow)
            {
                List<double> nextRow = new List<double>();
                foreach (int number in firstRow)
                {
                    nextRow.Add(number * n);
                }
                PrimeMultiplicationTable.Add(nextRow);
            }
            response.Data = PrimeMultiplicationTable;

            return response;
        }
    }
}

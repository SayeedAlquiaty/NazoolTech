using PrimeNumberMultiplicationApp.DTOs;
using PrimeNumberMultiplicationApp.DTOs.Requests;
using System.Threading.Tasks;

namespace PrimeNumberMultiplicationApp.Services.Interfaces
{
    public interface IPrimeNumberMultiplicationService
    {
        Task<PrimeNumberMultiplicationResponse> GetMultiplicationTableAsync(PrimeNumberMultiplicationRequest request);
    }
}

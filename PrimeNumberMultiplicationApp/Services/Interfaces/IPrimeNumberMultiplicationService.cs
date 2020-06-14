using PrimeNumberMultiplicationApp.DTOs;
using PrimeNumberMultiplicationApp.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumberMultiplicationApp.Services.Interfaces
{
    public interface IPrimeNumberMultiplicationService
    {
        Task<PrimeNumberMultiplicationResponse> GetMultiplicationTable(PrimeNumberMultiplicationRequest request);
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeNumberMultiplicationApp.DTOs;
using PrimeNumberMultiplicationApp.DTOs.Requests;
using PrimeNumberMultiplicationApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeNumberMultiplicationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeNumberMultiplicationController : ControllerBase
    {
        private readonly IPrimeNumberMultiplicationService multiplicationService;

        public PrimeNumberMultiplicationController(IPrimeNumberMultiplicationService multiplicationService)
        {
            this.multiplicationService = multiplicationService;
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<PrimeNumberMultiplicationResponse>> GetPrimeNumberMultiplication(int number)
        {
            var request = new PrimeNumberMultiplicationRequest { Number = number };
            return await multiplicationService.GetMultiplicationTable(request);
        }
    }
}
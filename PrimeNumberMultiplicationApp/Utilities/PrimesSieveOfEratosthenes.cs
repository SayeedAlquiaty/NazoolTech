using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumberMultiplicationApp.Utilities
{
    public class PrimesSieveOfEratosthenes : IPrimeNumberGenerator
    {
        public async Task<List<int>> GeneratePrimes(int n)
        {
            if(n <= 0)
            {
                return null;
            }

            List<int> primenumbers = new List<int>();
            primenumbers.AddRange(await GeneratePrimesSieveOfEratosthenes(n));
            return primenumbers;
        }

        private  int ApproximateNthPrime(int nn)
        {
            double n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11}[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        // Find all primes up to and including the limit
        private BitArray SieveOfEratosthenes(int limit)
        {
            BitArray bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }

        private async Task<List<int>> GeneratePrimesSieveOfEratosthenes(int n)
        {
            List<int> primes = new List<int>();
            await Task.Run(() =>
            {
                int limit = ApproximateNthPrime(n);
                BitArray bits = SieveOfEratosthenes(limit);
                for (int i = 0, found = 0; i < limit && found < n; i++)
                {
                    if (bits[i])
                    {
                        primes.Add(i);
                        found++;
                    }
                }
                if (limit <= 11)
                {
                    primes.Add(limit);
                }
            });
            
            return primes;
        }
    }
}

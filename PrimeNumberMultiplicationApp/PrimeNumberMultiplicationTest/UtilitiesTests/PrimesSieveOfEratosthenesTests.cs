using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberMultiplicationApp.Utilities;

namespace PrimeNumberMultiplicationTest.UtilitiesTests
{
    [TestClass]
    public class PrimesSieveOfEratosthenesTests
    {
        private IPrimeNumberGenerator primeNumberGenerator;

        [TestInitialize]
        public void Initialize()
        {
            this.primeNumberGenerator = new PrimesSieveOfEratosthenes();
        }

        [TestMethod]
        public void PrimesSieveOfEratosthenes_GeneratePrimesForZero_ResponseIsNull()
        {
            //Arrange
            int number = 0;

            //Act
            var response = this.primeNumberGenerator.GeneratePrimes(number).Result;

            //Assert
            Assert.IsNull(response);
        }

        [TestMethod]
        public void PrimesSieveOfEratosthenes_GeneratePrimesForTen_ResponseIsNotNull()
        {
            //Arrange
            int number = 10;
           
            //Act
            var response = this.primeNumberGenerator.GeneratePrimes(number).Result;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(number, response.Count);
        }

        [TestMethod]
        public void PrimesSieveOfEratosthenes_GeneratePrimes_CheckAllPrime()
        {
            //Arrange
            int number = 30;

            //Act
            var response = this.primeNumberGenerator.GeneratePrimes(number).Result;

            //Assert
            foreach(int n in response)
            {
                Assert.IsTrue(chkprime(n));
            }

            Assert.IsNotNull(response);
            Assert.AreEqual(number, response.Count);
        }

        private bool chkprime(int num)
        {
            for (int i = 2; i < (num/2 + 1); i++)
                if (num % i == 0)
                    return false;
            return true;
        }
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrimeNumberMultiplicationApp.DTOs.Requests;
using PrimeNumberMultiplicationApp.Services;
using PrimeNumberMultiplicationApp.Services.Interfaces;
using PrimeNumberMultiplicationApp.Utilities;
using System.Collections.Generic;

namespace PrimeNumberMultiplicationText.ServicesTests
{
    [TestClass]
    public class PrimeNumberMultiplicationServiceTest
    {
        private IPrimeNumberMultiplicationService primeNumberMultiplicationService;
        private Mock<IPrimeNumberGenerator> primeNumberGeneratorMock;

        [TestInitialize]
        public void Initialize()
        {
            this.primeNumberGeneratorMock = new Mock<IPrimeNumberGenerator>();
            

            this.primeNumberMultiplicationService = new PrimeNumberMultiplicationService(primeNumberGeneratorMock.Object);
        }

        [TestMethod]
        public void GetMultiplicationTable_PrimeNumberMultiplicationRequestAsNull_ResponseSuccessFalse()
        {
            //Arrange
            PrimeNumberMultiplicationRequest request = null;

            //Act
            var response = this.primeNumberMultiplicationService.GetMultiplicationTable(request).Result;

            //Assert
            Assert.AreEqual(response.Errors[0].ErrorMessage,"Invalid request");
            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public void MultiplicationOfTenPrimeNumbers_PrimeNumberMultiplicationRequest_ResponseSuccessTrue()
        {
            //Arrange
            var request = new PrimeNumberMultiplicationRequest();
            request.Number = 10;
            this.primeNumberGeneratorMock
                .Setup(x => x.GeneratePrimes(10))
                .ReturnsAsync(new List<int> { 2, 3, 5, 7, 11, 13, 17, 23, 29, 31 });

            //Act
            var response = this.primeNumberMultiplicationService.GetMultiplicationTable(request).Result;

            //Assert
            Assert.AreEqual(request.Number + 1, response.Data.Count);
            Assert.AreEqual(request.Number + 1, response.Data[0].Count);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void MultiplicationOfOnePrimeNumbers_PrimeNumberMultiplicationRequest_ResponseSuccessTrue()
        {
            //Arrange
            var request = new PrimeNumberMultiplicationRequest();
            request.Number = 1;
            this.primeNumberGeneratorMock
                .Setup(x => x.GeneratePrimes(1))
                .ReturnsAsync(new List<int> { 2 });

            //Act
            var response = this.primeNumberMultiplicationService.GetMultiplicationTable(request).Result;

            //Assert
            Assert.AreEqual(request.Number + 1, response.Data.Count);
            Assert.AreEqual(request.Number + 1, response.Data[0].Count);
            Assert.IsTrue(response.Success);
        }
    }
}

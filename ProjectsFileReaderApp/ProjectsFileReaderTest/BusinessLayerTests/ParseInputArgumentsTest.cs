using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectsFileReaderApp.BusinessLayer;
using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.Constants;
using ProjectsFileReaderApp.DTOs.Requests;

namespace ProjectsFileReaderTest.ServicesTests
{
    [TestClass]
    public class ParseInputArgumentsTest
    {
        private IParseInputArguments parseInputArguments = new ParseInputArguments();

        [TestMethod]
        public void InvalidRequest_GetParsedInputData_SuccessFalse()
        {
            //Arrange
            var request = new Request();

            //Act
            var response = this.parseInputArguments.GetParsedInputData(request);

            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Errors[0].ErrorMessage.Contains(ErrorStatus.InvalidRequest));
        }

        [TestMethod]
        public void LessThanTwoArguments_GetParsedInputData_SuccessFalse()
        {
            //Arrange
            var request = new ProcessInputArgumentsRequest {
                args = new string[] {"--file"}
            };

            //Act
            var response = this.parseInputArguments.GetParsedInputData(request);

            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Errors[0].ErrorMessage.Contains(ErrorStatus.InvalidArgument));
        }

        [TestMethod]
        public void MissingFileCommandArguments_GetParsedInputData_SuccessFalse()
        {
            //Arrange
            var request = new ProcessInputArgumentsRequest
            {
                args = new string[] { "--sortByStartDate", "--project", "1"}
            };

            //Act
            var response = this.parseInputArguments.GetParsedInputData(request);

            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Errors[0].ErrorMessage.Contains(ErrorStatus.InvalidCommand));
        }

        [TestMethod]
        public void ValidCommandArguments_GetParsedInputData_SuccessFalse()
        {
            //Arrange
            var request = new ProcessInputArgumentsRequest
            {
                args = new string[] { "--file", "..\\Resources\\ExampleData.txt","--sortByStartDate", "--project", "1" }
            };

            //Act
            var response = this.parseInputArguments.GetParsedInputData(request);

            //Assert
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
        }
    }
}

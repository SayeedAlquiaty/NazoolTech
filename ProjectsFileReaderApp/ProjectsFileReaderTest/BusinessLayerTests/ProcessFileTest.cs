using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectsFileReaderApp.BusinessLayer;
using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.Constants;
using ProjectsFileReaderApp.DTOs.Requests;
using System;
using System.Linq;

namespace ProjectsFileReaderTest.ServicesTests
{
    [TestClass]
    public class ProcessFileTest
    {
        private IProcess processFile = new ProcessFile();

        [TestMethod]
        public void InvalidRequest_GenerateObjects_SuccessFalse()
        {
            //Arrange
            var request = new Request();

            //Act
            var response = this.processFile.GenerateObjects(request);

            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Errors[0].ErrorMessage.Contains(ErrorStatus.InvalidRequest));
        }

        [TestMethod]
        public void InvalidFilePath_GenerateObjects_SuccessFalse()
        {
            //Arrange
            var request = new ProjectsFileRequest
            {
                FilePath = "..\\Resources\\ExampleData.txt",
                IsSortByStartDate = true,
                ProjectId = "2"
            };

            //Act
            var response = this.processFile.GenerateObjects(request);

            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Errors[0].ErrorMessage.Contains(ErrorStatus.Exception));
        }

        [TestMethod]
        public void InvalidComplexityDataFile_GenerateObjects_SuccessFalse()
        {
            //Arrange
            var request = new ProjectsFileRequest
            {
                FilePath = ".\\Resources\\InvalidComplexityData.txt",
                ProjectId = "3"
            };

            //Act
            var response = this.processFile.GenerateObjects(request);


            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Errors[0].ErrorMessage.Contains(ErrorStatus.InvalidComplexity));
        }

        [TestMethod]
        public void ValidDataFile_GenerateObjects_SuccessTrueWithValidFilteredOutputData()
        {
            //Arrange
            var request = new ProjectsFileRequest
            {
                FilePath = ".\\Resources\\ExampleData.txt",
                ProjectId = "3"
            };

            //Act
            var response = this.processFile.GenerateObjects(request);
            

            //Assert
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.Count);
            Assert.AreEqual(2, response.Data[0].Count);
        }


        [TestMethod]
        public void ValidDataFile_GenerateObjects_SuccessTrueWithValidStartDateFilter()
        {
            //Arrange
            var request = new ProjectsFileRequest
            {
                FilePath = ".\\Resources\\ExampleData.txt",
                IsSortByStartDate = true
            };

            //Act
            var response = this.processFile.GenerateObjects(request);


            //Assert
            Assert.IsTrue(response.Success);
            Assert.IsTrue(DateTime.Compare(response.Data[1].Project.StartDate, response.Data[0].Project.StartDate) > 0);
        }
    }
}

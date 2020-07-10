using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectsFileReaderApp.BusinessLayer.Interfaces;

namespace ProjectsFileReaderTest.ServicesTests
{
    [TestClass]
    public class ProjectFileServiceTest
    {
        private  Mock<IParseInputArguments> parseInputArgumentsMock;
        private  Mock<IProcess> processFileMock;
        private  Mock<ISendInformation> sendInformationToConsoleMock;

        [TestInitialize]
        public void Initialize()
        {
            this.parseInputArgumentsMock = new Mock<IParseInputArguments>();

            this.processFileMock = new Mock<IProcess>();

            this.sendInformationToConsoleMock = new Mock<ISendInformation>();
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

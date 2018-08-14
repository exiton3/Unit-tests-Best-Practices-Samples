using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestSamples.Tests
{
    [TestClass]
    public class ReportServiceTests
    {
        private ReportService _reportService;
        private Mock<IReportModelBuilder> _reportModelBuilder;
        private Mock<IClientRepository> _clientRepository;

        [TestInitialize]
        public void TestInit()
        {
            _reportModelBuilder = new Mock<IReportModelBuilder>();

            _clientRepository = new Mock<IClientRepository>();
            _clientRepository.Setup(x => x.GetClientData(It.IsAny<int>())).Returns(new ClientData());
            _reportService = new ReportService(_reportModelBuilder.Object, _clientRepository.Object);
        }


        [TestMethod]
        public void Generate_WithClientId_GetClientData()
        {
            var clientId = 3;

            var generate = _reportService.Generate(clientId);
            //Mock
            _clientRepository.Verify(x => x.GetClientData(clientId));
        }

        [TestMethod]
        public void Generate_WithClientId_BuildReportForClientData()
        {
            var clientId = 3;
            var clientData = new ClientData();
            //Stub
            _clientRepository.Setup(x => x.GetClientData(clientId)).Returns(clientData);

            var generate = _reportService.Generate(clientId);
            //Mock
            _reportModelBuilder.Verify(x => x.Build(clientData));
        }

        [TestMethod]
        public void Generate_WithClientId_ReturnReport()
        {
            var clientId = 3;
            var clientData = new ClientData();
            _clientRepository.Setup(x => x.GetClientData(clientId)).Returns(clientData);

            var expectedReport = new Report();
            _reportModelBuilder.Setup(x => x.Build(clientData)).Returns(expectedReport);

            var actualReport = _reportService.Generate(clientId);

            Assert.AreEqual(expectedReport, actualReport);
        }

        [TestMethod]
        public void Generate_BuildAndReturnReport()
        {
            var clientId = 3;
            var clientData = new ClientData();
            _clientRepository.Setup(x => x.GetClientData(clientId)).Returns(clientData);

            var expectedReport = new Report();
            _reportModelBuilder.Setup(x => x.Build(clientData)).Returns(expectedReport);

            var actualReport = _reportService.Generate(clientId);

            _clientRepository.Verify(x => x.GetClientData(clientId));
            _reportModelBuilder.Verify(x => x.Build(clientData));
            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
namespace UnitTestSamples
{
    public class ReportService
    {
        private readonly IReportModelBuilder _reportModelBuilder;
        private readonly IClientRepository _clientRepository;

        public ReportService(IReportModelBuilder reportModelBuilder, IClientRepository clientRepository)
        {
            _reportModelBuilder = reportModelBuilder;
            _clientRepository = clientRepository;
        }

        public Report Generate(int clientId)
        {
            ClientData clientData = _clientRepository.GetClientData(clientId);

            Report report = _reportModelBuilder.Build(clientData);

            return report;
        }
    }

    public class ClientData
    {
        public int Id { get; set; }

    }

    public interface IClientRepository
    {
        ClientData GetClientData(int clientId);
    }

    public interface IReportModelBuilder
    {
        Report Build(ClientData clientData);
    }

    public class Report
    {
    }
}
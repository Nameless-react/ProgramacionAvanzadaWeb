using Frontend.Helpers.Interface;
using FrontEnd.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using Frontend.ApiModel;

namespace Frontend.Helpers.Implementations
{
    public class TransactionReportHelper : ITransactionReportHelper
    {
        IServiceRepository _ServiceRepository;
        public TransactionReportHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        TransactionReport Convertir(TransactionReportViewModel transactionReport)
        {
            return new TransactionReport
            {
                TransactionReportId = transactionReport.TransactionReportId,
                AccountId = transactionReport.AccountId,
                GeneratorId = transactionReport.GeneratorId,
                StartDate = transactionReport.StartDate,
                EndDate = transactionReport.EndDate,
                TotalAmount = transactionReport.TotalAmount,
                TransactionCount = transactionReport.TransactionCount


            };
        }
        public TransactionReportViewModel Get(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/TransactionReport/" + id.ToString());
            TransactionReport transactionReport = new TransactionReport();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transactionReport = JsonConvert.DeserializeObject<TransactionReport>(content);
            }
            TransactionReportViewModel resultado = new TransactionReportViewModel
            {
                TransactionReportId = transactionReport.TransactionReportId,
                AccountId = transactionReport.AccountId,
                GeneratorId = transactionReport.GeneratorId,
                StartDate = transactionReport.StartDate,
                EndDate = transactionReport.EndDate,
                TotalAmount = transactionReport.TotalAmount,
                TransactionCount = transactionReport.TransactionCount
            };
            return resultado;
        }

        public List<TransactionReportViewModel> GetTransactions()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/TransactionReport");
            List<TransactionReport> transactionReports = new List<TransactionReport>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transactionReports = JsonConvert.DeserializeObject<List<TransactionReport>>(content);
            }
            List<TransactionReportViewModel> result = new List<TransactionReportViewModel>();
            foreach (var item in transactionReports)
            {
                result.Add(
                    new TransactionReportViewModel
                    {
                        TransactionReportId = item.TransactionReportId,
                        AccountId = item.AccountId,
                        GeneratorId = item.GeneratorId,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        TotalAmount = item.TotalAmount,
                        TransactionCount = item.TransactionCount
                    }
                    );
            }
            return result;
        }
    }
}


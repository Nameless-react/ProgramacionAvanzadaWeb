using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface ITransactionReportHelper
    {
        List<TransactionReportViewModel> GetTransactions();
        string Token { get; set; }
        TransactionReportViewModel Get(int id); 
    }
}

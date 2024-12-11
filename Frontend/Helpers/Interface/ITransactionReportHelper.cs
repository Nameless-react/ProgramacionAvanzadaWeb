using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface ITransactionReportHelper
    {
        List<TransactionReportViewModel> GetTransactions();
        TransactionReportViewModel Get(int id); 
    }
}

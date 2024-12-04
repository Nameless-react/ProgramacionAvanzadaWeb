using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface ITransactionHelper
    {
        List<TransactionViewModel> GetTransactions();
        TransactionViewModel Get(int id);
        TransactionViewModel Add(TransactionViewModel transaction);
        TransactionViewModel Update(TransactionViewModel transaction);
        void Delete(int id);
    }
}

using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface ITransactionHelper
    {
        List<TransactionViewModel> GetTransactions();
        string Token { get; set; }
        TransactionViewModel Get(int id);
        TransactionViewModel Add(TransactionViewModel transaction);
        TransactionViewModel Update(TransactionViewModel transaction);
        void Delete(int id);
    }
}

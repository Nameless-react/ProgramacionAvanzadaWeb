using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface ITransactionService
    {
        TransactionDTO Add(TransactionDTO transaction);
        bool Edit(TransactionDTO transaction);
        void Remove(int id);
       
        TransactionDTO Get(int id);
        
        List<TransactionDTO> GetAll();

    }
}

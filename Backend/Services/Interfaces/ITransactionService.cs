using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface ITransactionService
    {
        bool Add(TransactionDTO transaction);
        bool Edit(TransactionDTO transaction);
        bool Delete(TransactionDTO transaction);
        /// <summary>
        /// Obtiene Category por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TransactionDTO Get(int id);
        /// <summary>
        /// Obtiene todas la categories
        /// </summary>
        /// <returns></returns>
        List<TransactionDTO> Get();

    }
}

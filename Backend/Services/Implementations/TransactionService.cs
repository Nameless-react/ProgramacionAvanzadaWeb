using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        IUnidadDeTrabajo Unidad;

        public TransactionService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }

        #region Convert
        Transaction Convert(TransactionDTO transaction)
        {
            return new Transaction
            {
                TransactionId = transaction.TransactionId,
                OriginAccountId = transaction.OriginAccountId,
                DestinationAccountId = transaction.DestinationAccountId,
                TransactionDate = transaction.TransactionDate,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
        }

        TransactionDTO Convert(Transaction transaction) 
        {
            return new TransactionDTO
            {
                TransactionId = transaction.TransactionId,
                OriginAccountId = transaction.OriginAccountId,
                DestinationAccountId = transaction.DestinationAccountId,
                TransactionDate = transaction.TransactionDate,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
        }
        #endregion

        public bool Add(TransactionDTO transaction) 
        {
            Transaction entity = Convert(transaction);
            Unidad.TransactionDAL.Add(entity);
            return Unidad.Complete();

        }

        public bool Edit(TransactionDTO transaction) 
        { 
            var entity = Convert(transaction);
            Unidad.TransactionDAL.Update(entity);
            return Unidad.Complete();
        }

        public bool Delete(TransactionDTO transaction) 
        {
            Unidad.TransactionDAL.Remove(Convert(transaction));
            return Unidad.Complete();
        }

        public TransactionDTO  Get(int id) 
        { 
            return Convert(Unidad.TransactionDAL.Get(id));
        }

        public List<TransactionDTO> Get() 
        { 
            List<TransactionDTO> list = new List<TransactionDTO>();
            var transactions = Unidad.TransactionDAL.GetAll().ToList();

            foreach (var item in transactions) 
            { 
                list.Add(Convert(item));
            }

            return list;
        }
    }
}

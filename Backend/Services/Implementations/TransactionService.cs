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
        #region 
        Transaction Convert(TransactionDTO transaction)
        {
            return new Transaction()
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

        public TransactionDTO Add(TransactionDTO transaction)
        {
            try
            {
                Unidad.TransactionDAL.Add(Convert(transaction));

                Unidad.Complete();
                return transaction;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Edit(TransactionDTO transaction)
        {
            var entity = Convert(transaction);
            Unidad.TransactionDAL.Update(entity);
            return Unidad.Complete();

        }

        public TransactionDTO Get(int id)
        {
            return Convert(Unidad.TransactionDAL.Get(id));

        }

        public List<TransactionDTO> GetAll()
        {
            List<TransactionDTO> list = new List<TransactionDTO>();
            var transactions = Unidad.TransactionDAL.GetAll().ToList();

            foreach (var item in transactions)
            {
                list.Add(Convert(item));
            }

            return list;

        }

        public void Remove(int id)
        {
            Transaction transaction = new Transaction { TransactionId = id };
            Unidad.TransactionDAL.Remove(transaction);
            Unidad.Complete();
        }

       
    }
}

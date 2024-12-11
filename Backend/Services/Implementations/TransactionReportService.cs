using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class TransactionReportService : ITransactionReportService
    {
        IUnidadDeTrabajo Unidad;

        public TransactionReportService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }

        #region Convert
        TransactionReport Convert(TransactionReportDTO transaction)
        {
            return new TransactionReport
            {
                TransactionReportId = transaction.TransactionReportId,
                AccountId = transaction.AccountId,
                GeneratorId = transaction.GeneratorId,
                StartDate = transaction.StartDate,
                EndDate = transaction.EndDate,
                TotalAmount = transaction.TotalAmount,
                TransactionCount = transaction.TransactionCount
            };
        }

        TransactionReportDTO Convert(TransactionReport transaction) 
        {
            return new TransactionReportDTO
            {
                TransactionReportId = transaction.TransactionReportId,
                AccountId = transaction.AccountId, 
                GeneratorId = transaction.GeneratorId,
                StartDate = transaction.StartDate,
                EndDate = transaction.EndDate, 
                TotalAmount = transaction.TotalAmount,
                TransactionCount = transaction.TransactionCount
            };
        }
        #endregion

        

        


        public TransactionReportDTO Get(int id) 
        { 
            return Convert(Unidad.TransactionReportDAL.Get(id));
        }

        public List<TransactionReportDTO> Get() 
        { 
            List<TransactionReportDTO> list = new List<TransactionReportDTO>();
            var transactions = Unidad.TransactionReportDAL.GetAll().ToList();

            foreach (var item in transactions) 
            { 
                list.Add(Convert(item));
            }

            return list;
        }
    }
}

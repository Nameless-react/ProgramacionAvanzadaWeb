using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface ITransactionReportService
    {
        TransactionReportDTO Get(int id);
        List<TransactionReportDTO> Get();

    }
}

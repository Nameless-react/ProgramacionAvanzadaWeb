using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IAccessReportService
    {
        bool Add(AccessReportDTO dto);
        bool Edit(AccessReportDTO dto);
        bool Delete(int id);
        AccessReportDTO Get(int id);
        List<AccessReportDTO> Get();
    }
}

using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IAccessReportService
    {
        bool Add(AccessReportDTO dto);
        AccessReportDTO Get(int id);
        List<AccessReportDTO> Get();
    }
}

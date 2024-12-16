using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class AccessReportService : IAccessReportService
    {
        private readonly IUnidadDeTrabajo _unidad;

        public AccessReportService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }

        #region Convert
        private AccessReport Convert(AccessReportDTO dto)
        {
            return new AccessReport
            {
                AccessReportId = dto.AccessReportId,
                ClientId = dto.ClientId,
                AccessDate = dto.AccessDate,
                Ipaddress = dto.IpAddress,
                Success = dto.Success,
                AccessDescription = dto.AccessDescription
            };
        }

        private AccessReportDTO Convert(AccessReport entity)
        {
            return new AccessReportDTO
            {
                AccessReportId = entity.AccessReportId,
                ClientId = entity.ClientId,
                AccessDate = entity.AccessDate,
                IpAddress = entity.Ipaddress,
                Success = entity.Success,
                AccessDescription = entity.AccessDescription
            };
        }
        #endregion


        public bool Add(AccessReportDTO accessReport)
        {
            AccessReport entity = Convert(accessReport);
            _unidad.AccessReportDAL.Add(entity);
            return _unidad.Complete();
        }


        public AccessReportDTO Get(int id)
        {
            var entity = _unidad.AccessReportDAL.Get(id);
            return entity != null ? Convert(entity) : null;
        }

        public List<AccessReportDTO> Get()
        {
            List<AccessReportDTO> list = new List<AccessReportDTO>();
            var access = _unidad.AccessReportDAL.GetAll().ToList();

            foreach (var item in access)
            {
                list.Add(Convert(item));
            }
            return list;

        }
    }
}

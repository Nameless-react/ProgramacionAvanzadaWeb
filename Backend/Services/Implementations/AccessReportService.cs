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

        public bool Add(AccessReportDTO dto)
        {
            var entity = Convert(dto);
            _unidad.AccessReportDAL.Add(entity);
            return _unidad.Complete();
        }

        public bool Edit(AccessReportDTO dto)
        {
            var entity = Convert(dto);
            _unidad.AccessReportDAL.Update(entity);
            return _unidad.Complete();
        }

        public bool Delete(int id)
        {
            var entity = _unidad.AccessReportDAL.Get(id);
            if (entity != null)
            {
                _unidad.AccessReportDAL.Remove(entity);
                return _unidad.Complete();
            }
            return false;
        }

        public AccessReportDTO Get(int id)
        {
            var entity = _unidad.AccessReportDAL.Get(id);
            return entity != null ? Convert(entity) : null;
        }

        public List<AccessReportDTO> Get()
        {
            var entities = _unidad.AccessReportDAL.GetAll().ToList();
            return entities.Select(Convert).ToList();
        }
    }
}

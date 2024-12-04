using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class AccountTypeService : IAccountTypeService
    {


        IUnidadDeTrabajo Unidad;

        public AccountTypeService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }



        AccountType Convertir(AccountTypeDTO accountType)
        {
            return new AccountType()
            {
                AccountTypeId = accountType.AccountTypeId,
                AccountTypeName = accountType.AccountTypeName,
            };
        }

        AccountTypeDTO Convertir(AccountType accountType)
        {
            return new AccountTypeDTO()
            {
                AccountTypeId = accountType.AccountTypeId,
                AccountTypeName = accountType.AccountTypeName,

            };
        }
        public AccountTypeDTO Get(int id)
        {
            return Convertir(Unidad.AccountTypeDAL.Get(id));
        }

        public List<AccountTypeDTO> GetAll()
        {
            List<AccountTypeDTO> list = new List<AccountTypeDTO>();
            var clients = Unidad.AccountTypeDAL.GetAll().ToList();

            foreach (var item in clients)
            {
                list.Add(Convertir(item));
            }
            return list;
        }
    }
}

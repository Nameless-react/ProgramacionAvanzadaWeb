using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{

    public class AccountService : IAccountService

    {
        IUnidadDeTrabajo Unidad;

        public AccountService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }

        private Account Convertir(AccountDTO accountDTO)
        {
            return new Account
            {
                AccountId = accountDTO.AccountId,
                AccountNumber = accountDTO.AccountNumber,
                ClientId = accountDTO.ClientId,
                AccountTypeId = accountDTO.AccountTypeId,
                Balance = accountDTO.Balance,
                OpeningDate = accountDTO.OpeningDate
            };
        }

         AccountDTO Convertir(Account account)
        {
            return new AccountDTO
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber,
                ClientId = account.ClientId,
                AccountTypeId = account.AccountTypeId,
                Balance = account.Balance,
                OpeningDate = account.OpeningDate
            };
        }

        public bool Add(AccountDTO accountDTO)
        {
            var entity = Convertir(accountDTO);
            object value = Unidad.AccountDAL.Add(entity);
            return Unidad.Complete();
        }

        public AccountDTO Get(int id)
        {
            return Convertir(Unidad.AccountDAL.Get(id));
        }

        public List<AccountDTO> GetAll()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            var accounts = Unidad.AccountDAL.GetAll().ToList();

            foreach (var item in accounts)
            {
                list.Add(Convertir(item));
            }
            return list;
        }

        public bool Remove(AccountDTO accountDTO)
        {
            Unidad.AccountDAL.Remove(Convertir(accountDTO));
            return Unidad.Complete();
        }

        public bool Update(AccountDTO accountDTO)
        {
            var entity = Convertir(accountDTO);
            Unidad.AccountDAL.Update(entity);
            return Unidad.Complete();
        }
    }
}

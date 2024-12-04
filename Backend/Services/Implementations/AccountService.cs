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
                FirstName = account.Client.FirstName,
                email = account.Client.Email,
                phone = account.Client.Phone,
                typeName = account.AccountType.AccountTypeName,
                OpeningDate = account.OpeningDate
            };
        }

        public bool Add(AccountDTO accountDTO)
        {
            Account entity = Convertir(accountDTO);
            Unidad.AccountDAL.Add(entity);
            return Unidad.Complete();
        }

        public AccountDTO Get(int id)
        {
            
            Account account = Unidad.AccountDAL.Get(id);
            AccountType accountType = Unidad.AccountTypeDAL.Get(account.AccountTypeId);
            Client client = Unidad.ClientDAL.Get(account.ClientId);
            account.Client = client;
            account.AccountType = accountType;

            return Convertir(account);
        }

        public List<AccountDTO> GetAll()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            var accounts = Unidad.AccountDAL.GetAll(d => d.Client, c => c.AccountType).ToList();

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

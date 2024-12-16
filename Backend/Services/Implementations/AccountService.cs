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

        Account Convertir(AccountDTO account)
        {

            return new Account()
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber,
                ClientId = account.ClientId,
                AccountTypeId = account.AccountTypeId,
                Balance = account.Balance,
                OpeningDate = account.OpeningDate
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
                typeName = account.AccountType.AccountTypeName,
                OpeningDate = account.OpeningDate
            };
        }

        public bool Add(AccountDTO account)
        {
            Account entity = Convertir(account);
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
        public bool Remove(int id)
        {
            Account account = new Account { AccountId = id };
            Unidad.AccountDAL.Remove(account);
            return Unidad.Complete();
        }

        public bool Update(AccountDTO account)
        {
            var entity = Convertir(account);
            Unidad.AccountDAL.Update(entity);
            return Unidad.Complete();
        }
    }
}

using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class AccountHelper : IAccountHelper
    {

        public string Token { get; set; }

        IServiceRepository _ServiceRepository;
        

        public AccountHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }
        Account Convert(AccountViewModel account)
        {
            return new Account
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber,
                ClientId = account.ClientId,
                AccountTypeId = account.AccountTypeId,
                Balance = account.Balance,
                OpeningDate = account.OpeningDate
            };
        }


        public AccountViewModel Add(AccountViewModel account)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Accounts", Convert(account));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return account;
        }

        public void Delete(int id)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Accounts/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }

        public List<AccountViewModel> GetAccounts()
        {

            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Accounts");
            List<Account> accounts = new List<Account>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                accounts = JsonConvert.DeserializeObject<List<Account>>(content);
            }

            List<AccountViewModel> result = new List<AccountViewModel>();
            foreach (var item in accounts)
            {
                result.Add
                     (
                         new AccountViewModel
                         {
                             AccountId = item.AccountId,
                             AccountNumber = item.AccountNumber,
                             ClientId = item.ClientId,
                             AccountTypeId = item.AccountTypeId,
                             Balance = item.Balance,
                             OpeningDate = item.OpeningDate
                         }
                     );
            }
            return result;
        }

        public AccountViewModel GetAccount(int id) 
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Accounts/" + id.ToString());
            Account account = new Account();
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                account = JsonConvert.DeserializeObject<Account>(content);
            }

            AccountViewModel result =
                new AccountViewModel
                {
                    AccountId = account.AccountId,
                    AccountNumber = account.AccountNumber,
                    ClientId = account.ClientId,
                    AccountTypeId = account.AccountTypeId,
                    Balance = account.Balance,
                    OpeningDate = account.OpeningDate
                };
            return result;
        }

        public AccountViewModel Update(AccountViewModel account) 
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Accounts/" + account.AccountId.ToString(), Convert(account));
            if (response.IsSuccessStatusCode) 
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return account;
        }
    }
}

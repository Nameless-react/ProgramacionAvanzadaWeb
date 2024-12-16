using Frontend.Helpers.Interface;
using FrontEnd.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using Frontend.ApiModel;
using FrontEnd.Helpers.Implementations;

namespace Frontend.Helpers.Implementations
{
    public class TransactionHelper : ITransactionHelper
    {
        IServiceRepository _ServiceRepository;
        public string Token { get; set; }
        public TransactionHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }
        Transaction Convertir(TransactionViewModel transaction)
        {
            return new Transaction
            {
                TransactionId = transaction.TransactionId,
                OriginAccountId = transaction.OriginAccountId,
                DestinationAccountId = transaction.DestinationAccountId,
                TransactionDate = transaction.TransactionDate,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
        }

        public TransactionViewModel Add(TransactionViewModel transaction)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Transaction", Convertir(transaction));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return transaction;
        }

        public void Delete(int id)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Transaction/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }

        public TransactionViewModel Get(int id)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Transaction/" + id.ToString());
            Transaction transaction = new Transaction();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transaction = JsonConvert.DeserializeObject<Transaction>(content);
            }
            TransactionViewModel resultado = new TransactionViewModel
            {
                TransactionId = transaction.TransactionId,
                OriginAccountId = transaction.OriginAccountId,
                DestinationAccountId = transaction.DestinationAccountId,
                TransactionDate = transaction.TransactionDate,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
            return resultado;
        }

        public List<TransactionViewModel> GetTransactions()
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Transaction");
            List<Transaction> transactions = new List<Transaction>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(content);
            }
            List<TransactionViewModel> result = new List<TransactionViewModel>();
            foreach (var item in transactions)
            {
                result.Add(
                    new TransactionViewModel
                    {
                        TransactionId = item.TransactionId,
                        OriginAccountId = item.OriginAccountId,
                        DestinationAccountId = item.DestinationAccountId,
                        TransactionDate = item.TransactionDate,
                        Amount = item.Amount,
                        Description = item.Description
                    }
                    );
            }
            return result;
        }



        public TransactionViewModel Update(TransactionViewModel transaction)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Transaction/" + transaction.TransactionId.ToString(), Convertir(transaction));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

            }
            return transaction;
        }
    }
}


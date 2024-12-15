using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class ClientHelper : IClientHelper
    {
        public string Token { get; set; }

        IServiceRepository _ServiceRepository;
        public ClientHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }
        Client Convertir (ClientViewModel client)
        {
            return new Client
            {
                ClientId = client.ClientId,
                UserName = client.UserName,
                PhoneNumber = client.PhoneNumber, 
                Email = client.Email


            };
        }

        public ClientViewModel Add(ClientViewModel client)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Client",Convertir(client));
            if(response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return client;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Client/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }

        public ClientViewModel Get(int id)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Client/" + id.ToString());
            Client client = new Client();
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                client = JsonConvert.DeserializeObject<Client>(content);
            }
            ClientViewModel resultado = new ClientViewModel
            {
                ClientId = client.ClientId,
                UserName = client.UserName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };
            return resultado;
        }

        public List<ClientViewModel> GetClients()
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Client");
            List<Client> clients = new List<Client>();
            if(responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<List<Client>>(content);
            }
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach(var item in clients)
            {
                result.Add(
                    new ClientViewModel
                    {
                        ClientId = item.ClientId,
                        UserName = item.UserName,
                        PhoneNumber = item.PhoneNumber,
                        Email = item.Email
                    }
                    );
            }return result;
        }

       

       public ClientViewModel Update(ClientViewModel client)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Client/" + client.ClientId.ToString(), Convertir(client));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

            }
            return client;
        }
    }
}

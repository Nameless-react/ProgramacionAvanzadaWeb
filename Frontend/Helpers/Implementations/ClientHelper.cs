using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using FrontEnd.Helpers.Interfaces;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class ClientHelper : IClientHelper
    {
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
                FirstName = client.FirstName,
                LastName = client.LastName, 
                DateOfBirth = client.DateOfBirth,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                City = client.City,     
                Country = client.Country,
                RegistrationDate = client.RegistrationDate,


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
                FirstName = client.FirstName,
                LastName = client.LastName,
                DateOfBirth = client.DateOfBirth,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                City = client.City,
                Country = client.Country,
                RegistrationDate = client.RegistrationDate
            };
            return resultado;
        }

        public List<ClientViewModel> GetClients()
        {
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
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DateOfBirth = item.DateOfBirth,
                        Phone = item.Phone,
                        Email = item.Email,
                        Address = item.Address,
                        City = item.City,
                        Country = item.Country,
                        RegistrationDate = item.RegistrationDate
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

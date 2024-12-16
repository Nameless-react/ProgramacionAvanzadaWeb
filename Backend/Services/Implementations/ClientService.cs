using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ClientService : IClientService
    {
        IUnidadDeTrabajo Unidad;

        public ClientService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }

        Client Convertir(ClientDTO client)
        {
            return new Client()
            {
                ClientId = client.ClientId,
                UserName = client.UserName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };  
        }

        ClientDTO Convertir(Client client)
        {
            return new ClientDTO
            {
                ClientId = client.ClientId,
                UserName = client.UserName,
                PhoneNumber= client.PhoneNumber,
                Email = client.Email
            };
        }

        public bool Add(ClientDTO client)
        {
            Client entity = Convertir(client);
            Unidad.ClientDAL.Add(entity);
            return Unidad.Complete();
        }

        public ClientDTO Get(int id)
        {
            return Convertir(Unidad.ClientDAL.Get(id));
        }

        public List<ClientDTO> GetAll()
        {
            List<ClientDTO> list = new List<ClientDTO>();
            var clients = Unidad.ClientDAL.GetAll().ToList();

            foreach (var item in clients)
            {
                list.Add(Convertir(item));
            }
            return list;
        }

        public void Remove(int id)
        {
            Client client = new Client{ ClientId = id };
            Unidad.ClientDAL.Remove(client);
            Unidad.Complete();
        }

        public bool Update(ClientDTO client)
        {
            var entity = Convertir(client);
            Unidad.ClientDAL.Update(entity);
            return Unidad.Complete();
        }
    }
}

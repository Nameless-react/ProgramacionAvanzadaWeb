using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _clientService.GetAll();
            return Ok(result);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _clientService.Get(id);
            return Ok(result);
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] ClientDTO clientDTO)
        {
            _clientService.Add(clientDTO);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClientDTO client)
        {
            _clientService.Update(client);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ClientDTO client = new ClientDTO
            {
                ClientId = id
            };
            _clientService.Remove(client);
        }
    }
}

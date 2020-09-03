using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using car_service.API.Models;
using car_service.API.Services;

namespace car_service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private ClientService _clientService;
        public ClientsController (ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            
            return _clientService.GetAllClient();
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<Client>> GetId(int id)
        {
            return await _clientService.GetById(id);
        }

        [HttpPost]
        public ActionResult<Client> CreateClient(Client client)
        {
            _clientService.AddClient(client);
            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }
    }
}
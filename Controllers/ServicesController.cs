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
    public class ServicesController : ControllerBase
    {
        private ServiceService _serviceService;
        public ServicesController (ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ActionResult<List<Service>> GetAllService()
        {
            return _serviceService.GetAllService();
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<Service>> GetId(int id)
        {
            return await _serviceService.GetById(id);
        }
        
        [HttpGet("{categoryId}/category")]
        public ActionResult<List<Service>> GetServicesByCategoryId(int categoryId)
        {
            return _serviceService.GetServicesByCategoryId(categoryId);
        }

        [HttpPost]
        public ActionResult<Service> CreateClient(Service service)
        {
            _serviceService.AddService(service);
            return CreatedAtAction("GetClient", new { id = service.Id }, service);
        }

        [HttpPut("{id}/")]
        public IActionResult PutTaskItem(int id, Service service)
        {
            _serviceService.PutService(id, service);
            return NoContent();
        }
    }
}
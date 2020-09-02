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

        [HttpGet("{categoryId}/category")]
        public ActionResult<IEnumerable<Service>> GetServicesByCategoryId(int categoryId)
        {
            return _serviceService.GetServicesByCategoryId(categoryId);
        }
    }
}
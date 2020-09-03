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
    public class ChecksController : ControllerBase
    {
        private CheckService _checkService;
        public ChecksController (CheckService checkService)
        {
            _checkService = checkService;
        }

        [HttpGet]
        public ActionResult<List<Check>> Get()
        {
            
            return _checkService.GetAllCheck();
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<Check>> GetId(int id)
        {
            return await _checkService.GetById(id);
        }
    }
}
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
    public class ExpendableMaterialsController : ControllerBase
    {
        private ExpendableMaterialService _expendableMaterialService;
        public ExpendableMaterialsController (ExpendableMaterialService expendableMaterialService)
        {
            _expendableMaterialService = expendableMaterialService;
        }

        [HttpGet]
        public ActionResult<List<ExpendableMaterial>> Get()
        {
            return _expendableMaterialService.GetAllExpendableMaterial();
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ExpendableMaterial>> GetId(int id)
        {
            return await _expendableMaterialService.GetById(id);
        }
    }
}
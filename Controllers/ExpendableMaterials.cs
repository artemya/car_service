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
        private ExpendableMaterialService _consumableService;
        public ExpendableMaterialsController (ExpendableMaterialService consumableService)
        {
            _consumableService = consumableService;
        }

        [HttpGet]
        public ActionResult<List<ExpendableMaterial>> Get()
        {
            return _consumableService.GetAllExpendableMaterial();
        }
    }
}
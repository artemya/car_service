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

        [HttpGet("{id}/clients")]
        public ActionResult<List<CheckClient>> GetByClientId(int id)
        {
            return _checkService.GetByClientId(id);
        }


        [HttpGet("{id}/all")]
        public ActionResult<List<CheckSum>> GetAllWithAll(int id)
        {
            return _checkService.GetAll(id);
        }

        [HttpPost]
        public ActionResult<Check> CreateMaterial(Check check)
        {
            _checkService.AddCheck(check);
            return CreatedAtAction("GetMaterial", new { id = check.Id }, check);
        }
    }
}
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
    [Route("api/materials")]
    [ApiController]
    public class CheckMaterialItemsController : ControllerBase
    {
        private CheckMaterialItemService _checkMaterialItemService;
        public CheckMaterialItemsController (CheckMaterialItemService checkMaterialItemService)
        {
            _checkMaterialItemService = checkMaterialItemService;
        }


        [HttpPost("items")]
        public ActionResult<CheckMaterialItem> CreateCheckMaterial(CheckMaterialItem checkMaterialItem)
        {
            _checkMaterialItemService.AddCheckMaterial(checkMaterialItem);
            return CreatedAtAction("GetMaterial", new { id = checkMaterialItem.Id }, checkMaterialItem);
        }

    }
}
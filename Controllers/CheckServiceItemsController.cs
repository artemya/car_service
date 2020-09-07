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
    [Route("api/services/items")]
    [ApiController]
    public class CheckServiceItemsController : ControllerBase
    {
        private CheckServiceItemService _checkServiceItemService;
        public CheckServiceItemsController (CheckServiceItemService checkServiceItemService)
        {
            _checkServiceItemService = checkServiceItemService;
        }


        [HttpPost]
        public ActionResult<CheckServiceItem> CreatService(CheckServiceItem checkServiceItem)
        {
            _checkServiceItemService.AddCheckService(checkServiceItem);
            return CreatedAtAction("GetMaterial", new { id = checkServiceItem.Id }, checkServiceItem);
        }

    }
}
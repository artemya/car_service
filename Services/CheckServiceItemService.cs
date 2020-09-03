using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class CheckServiceItemService
    {
        private readonly CarServiceDbContext _context;
        public CheckServiceItemService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public ActionResult<List<CheckServiceItem>> GetAllCheckItem()
        {
            return _context.CheckServiceItem.ToList();
        }

    }
}
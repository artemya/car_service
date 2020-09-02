using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class СonsumableService
    {
        private readonly CarServiceDbContext _context;
        public СonsumableService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public ActionResult<List<Сonsumable>> GetAllCategory()
        {
            return _context.Сonsumable.ToList();
        }
    }
}
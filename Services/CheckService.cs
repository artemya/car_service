using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class CheckService
    {
        private readonly CarServiceDbContext _context;
        public CheckService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public ActionResult<List<Check>> GetAllClient()
        {
            return _context.Check.ToList();
        }

        public async Task<ActionResult<Check>> GetById(int id)
        {
            return await _context.Check.FindAsync(id);
        }
    }
}
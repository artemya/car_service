using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class ExpendableMaterialService
    {
        private readonly CarServiceDbContext _context;
        public ExpendableMaterialService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public ActionResult<List<ExpendableMaterial>> GetAllExpendableMaterial()
        {
            return _context.ExpendableMaterial.ToList();
        }
    }
}
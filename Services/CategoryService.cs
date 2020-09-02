using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class CategoryService
    {
        private readonly CarServiceDbContext _context;
        public CategoryService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public ActionResult<List<Category>> GetAllCategory()
        {
            return _context.Category.ToList();
        }
    }
}
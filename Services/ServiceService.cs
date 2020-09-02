using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class ServiceService
    {
        private readonly CarServiceDbContext _context;
        public ServiceService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public ActionResult<List<Service>> GetAllService()
        {
            return _context.Service.ToList();
        }

        public ActionResult<IEnumerable<Service>> GetServicesByCategoryId(int categoryId)
        {
            return _context.Service.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
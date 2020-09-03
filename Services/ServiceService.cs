using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
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

        public List<Service> GetAllService()
        {
            return _context.Service.ToList();
        }

        public async Task<Service> GetById(int id)
        {
            return await _context.Service.FindAsync(id);
        }
        
        public List<Service> GetServicesByCategoryId(int categoryId)
        {
            return _context.Service.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
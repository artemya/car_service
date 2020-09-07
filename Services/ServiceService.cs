using car_service.API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            
            return (from c in _context.Category
            join s in _context.Service
            on c.Id equals s.CategoryId
            select new Service()
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                CategoryId = s.CategoryId,
                CategoryName = c.Name
            }).ToList(); 
        }

        public async Task<Service> GetById(int id)
        {
            return await _context.Service.FindAsync(id);
        }
        
        public List<Service> GetServicesByCategoryId(int categoryId)
        {
            return _context.Service.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void AddService(Service service)
        {
            _context.Service.Add(service);
            _context.SaveChangesAsync();
        }
    }
}
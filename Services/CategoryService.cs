using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace car_service.API.Services
{
    public class CategoryService
    {
        private readonly CarServiceDbContext _context;
        public CategoryService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public List<Category> GetAllCategory()
        {
            return _context.Category.ToList();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async void PutCategory(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
using car_service.API.Models;

namespace car_service.API.Services
{
    public class CheckMaterialItemService
    {
        private readonly CarServiceDbContext _context;
        public CheckMaterialItemService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public void AddCheckMaterial(CheckMaterialItem checkMaterialItem)
        {
            _context.CheckMaterialItem.Add(checkMaterialItem);
            _context.SaveChangesAsync();
        }
    }
}
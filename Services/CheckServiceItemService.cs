using car_service.API.Models;

namespace car_service.API.Services
{
    public class CheckServiceItemService
    {
        private readonly CarServiceDbContext _context;
        public CheckServiceItemService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public void AddCheckService(CheckServiceItem checkServiceItem)
        {
            _context.CheckServiceItem.Add(checkServiceItem);
            _context.SaveChangesAsync();
        }
    }
}
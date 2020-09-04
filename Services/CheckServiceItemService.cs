using car_service.API.Models;
using System.Linq;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class CheckServiceItemService
    {
        private readonly CarServiceDbContext _context;
        public CheckServiceItemService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public List<CheckServiceItem> GetAllCheckItem()
        {
            return (from csi in _context.CheckServiceItem
            join se in _context.Service on csi.ServiceId equals se.Id
            select new CheckServiceItem()
            {
                Id = csi.Id,
                ServiceName = se.Name,
                ServicePrice = se.Price,
                CheckId = csi.CheckId,
                ServiceId = csi.ServiceId,
            }).ToList(); 
        }

        public void AddCheckService(CheckServiceItem checkServiceItem)
        {
            _context.CheckServiceItem.Add(checkServiceItem);
            _context.SaveChangesAsync();
        }
    }
}
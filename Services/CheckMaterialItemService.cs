using car_service.API.Models;
using System.Linq;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class CheckMaterialItemService
    {
        private readonly CarServiceDbContext _context;
        public CheckMaterialItemService(CarServiceDbContext context) 
        {
            _context = context;
        }

        // public List<CheckMaterialItem> GetAllCheckItem()
        // {
        //     return (from cmi in _context.CheckMaterialItem
        //     join em in _context.ExpendableMaterial on cmi.ExpendableMaterialId equals em.Id
        //     select new CheckMaterialItem()
        //     {
        //         Id = cmi.Id,
        //         MaterialName = em.Name,
        //         MaterialPrice = em.Price,
        //         ExpendableMaterialId = cmi.Id,
        //         CheckId = cmi.CheckId,
        //     }).ToList(); 
        // }

        public void AddCheckMaterial(CheckMaterialItem checkMaterialItem)
        {
            _context.CheckMaterialItem.Add(checkMaterialItem);
            _context.SaveChangesAsync();
        }
    }
}
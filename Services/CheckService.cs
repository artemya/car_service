using car_service.API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class CheckService
    {
        private readonly CarServiceDbContext _context;
        public CheckService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public List<Check> GetAllCheck()
        {
            return (from cl in _context.Client
            join ch in _context.Check
            on cl.Id equals ch.ClientId
            select new Check()
            {
                Id = ch.Id,
                Date = ch.Date,
                ClientId = ch.ClientId,
                ClientName = cl.Name,
            }).ToList(); 
        }

        public async Task<Check> GetById(int id)
        {
            return await _context.Check.FindAsync(id);
        }

        public void AddCheck(Check check)
        {
            _context.Check.Add(check);
            _context.SaveChangesAsync();
        }

        public List<CheckSum> GetAllWithMaterial(int id)
        {
            
            List<Check> check = (from ch in _context.Check
            join cm in _context.CheckMaterialItem on ch.Id equals cm.CheckId
            join m in _context.ExpendableMaterial on cm.ExpendableMaterialId equals m.Id
            where id == ch.Id
            select new Check()
            {
                Id = ch.Id,
                Date = ch.Date,
                ClientId = ch.ClientId,
                MaterialName = m.Name,
                MaterialPrice = m.Price
            }).ToList();
            List<CheckSum> checkSum = new List<CheckSum>();
            float total = check.Sum(item => item.MaterialPrice);
            if(total != 0)
            {
                checkSum.Add(new CheckSum() {CheckId = id, Sum = total});
                return checkSum;
            }
            else
            {
                return new List<CheckSum>();
            }
        }
    }
}
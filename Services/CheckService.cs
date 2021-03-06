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

        public List<CheckClient> GetByClientId(int id)
        {
            var result = (from cl in _context.Client
            join ch in _context.Check on cl.Id equals ch.ClientId
            where id == ch.ClientId
                select new CheckClient()
                { 
                    Id = ch.Id,
                    Date = ch.Date,
                    ClientId = ch.ClientId,
                    ClientName = cl.Name,
                }).ToList();
                
             return result;
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
                MaterialName = m.Name,
                MaterialPrice = m.Price
            }).ToList();
            return Summing(id, check);
        }

        public List<CheckSum> GetAllWithService(int id)
        {
            
            List<Check> check = (from ch in _context.Check
            join cs in _context.CheckServiceItem on ch.Id equals cs.CheckId
            join s in _context.Service on cs.ServiceId equals s.Id
            where id == ch.Id
            select new Check()
            {
                Id = ch.Id,
                ServiceName = s.Name,
                ServicePrice = s.Price
            }).ToList();
            return Summing(id, check);
        }

        public List<CheckSum> Summing(int id, List<Check> check)
        {
            List<CheckSum> checkSum = new List<CheckSum>();
            float sumMaterial = check.Sum(item => item.MaterialPrice);
            float sumService = check.Sum(item => item.ServicePrice);
            float total =  sumMaterial + sumService; 
            List<string> materialName = new List<string>();
            List<string> serviceName = new List<string>();
            foreach(var ch in check)
            {
                materialName.Add(ch.MaterialName);
                serviceName.Add(ch.ServiceName);
            }
            if(total != 0)
            {
                checkSum.Add(new CheckSum() {CheckId = id, Sum = total, checkMaterial = materialName, checkService = serviceName});
                return checkSum;
            }
            else
            {
                return new List<CheckSum>();
            }
        }
        public List<CheckSum> GetAll(int id)
        {
            
            return SumAll(id);
        }

        public List<CheckSum> SumAll(int id)
        {
            List<CheckSum> material = GetAllWithMaterial(id);
            List<CheckSum> service = GetAllWithService(id);
            List<CheckSum> all = material.Concat(service).ToList();
            float total = all.Sum(item => item.Sum);
            if(total != 0)
            {
                List<CheckSum> checkSum = new List<CheckSum>();
                List<string> materialName = new List<string>();
                List<string> serviceName = new List<string>();
                foreach(var mt in material)
                {
                    foreach(var chmt in mt.checkMaterial)
                    {
                        materialName.Add(chmt);
                    }
                }

                foreach(var sr in service)
                {
                    
                    foreach(var chs in sr.checkService)
                    {
                        serviceName.Add(chs);
                    }
                }

                checkSum.Add(new CheckSum() {CheckId = id, Sum = total, checkMaterial = materialName, checkService = serviceName});
                return checkSum;
            }
            else
            {
                return new List<CheckSum>();
            }
        }
    }
}
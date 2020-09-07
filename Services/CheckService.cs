using car_service.API.Models;
using System;
using System.Linq;
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

        public List<CategorySum> GetCheckByCategory(int id)
        {
            List<CategoryCheck> check = (from ch in _context.Check
            join cs in _context.CheckServiceItem on ch.Id equals cs.CheckId
            join s in _context.Service on cs.ServiceId equals s.Id
            join c in _context.Category on s.CategoryId equals c.Id
            where id == ch.Id
            select new CategoryCheck()
            {
                Id = ch.Id,
                ServicePrice = s.Price,
                CategoryId = c.Id,
                CategoryName = c.Name

            }).ToList();
            return SumCategory(id, check);
        }

        public List<CategorySum> SumCategory(int id, List<CategoryCheck> check)
        {
            List<int> temp = new List<int>(); 
            List<CategorySum> sumCategory = new List<CategorySum>();
            float total = 0; 
            foreach(var ch in check)
            {
                temp.Add(ch.CategoryId);
            }

            temp = temp.Distinct().ToList();

            for(int i = 0; i < temp.Count(); i++)
            {
                total = check.Where(item => item.CategoryId == temp[i]).Sum(item => item.ServicePrice);
                Console.WriteLine(total);
                sumCategory.Add(new CategorySum() {CategoryName = check.Find(x => Convert.ToInt32(x.CategoryId) == temp[i]).CategoryName , Sum = total});
            }

            return sumCategory;
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
            List<SumServiceMaterial> materialName = new List<SumServiceMaterial>();
            List<SumServiceMaterial> serviceName = new List<SumServiceMaterial>();
            foreach(var ch in check)
            {
                materialName.Add(new SumServiceMaterial() { Name = ch.MaterialName, Price = ch.MaterialPrice } );
                serviceName.Add(new SumServiceMaterial() { Name = ch.ServiceName, Price = ch.ServicePrice } );
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
            List<CategorySum> category = GetCheckByCategory(id);
            float total = all.Sum(item => item.Sum);
            if(total != 0)
            {
                List<CheckSum> checkSum = new List<CheckSum>();
                List<SumServiceMaterial> materialName = new List<SumServiceMaterial>();
                List<SumServiceMaterial> serviceName = new List<SumServiceMaterial>();
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

                checkSum.Add(new CheckSum() {CheckId = id, Sum = total, checkMaterial = materialName, checkService = serviceName, categoryCheck = category});
                return checkSum;
            }
            else
            {
                return new List<CheckSum>();
            }
        }
    }
}
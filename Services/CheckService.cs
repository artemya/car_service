using car_service.API.Models;
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
    }
}
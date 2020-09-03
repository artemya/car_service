using car_service.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace car_service.API.Services
{
    public class ClientService
    {
        private readonly CarServiceDbContext _context;
        public ClientService(CarServiceDbContext context) 
        {
            _context = context;
        }

        public List<Client> GetAllClient()
        {
            return _context.Client.ToList();
        }

        public async Task<Client> GetById(int id)
        {
            return await _context.Client.FindAsync(id);
        }
    }
}
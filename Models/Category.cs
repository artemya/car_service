using System.Collections.Generic;

namespace car_service.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Service> Services { get; set; }
    }
}
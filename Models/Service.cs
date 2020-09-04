using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public CheckServiceItem CheckServiceItem { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class SumServiceMaterial
    {
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public float Price { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CategorySum
    {
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public float Sum { get; set; }
    }
}
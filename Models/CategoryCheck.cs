using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CategoryCheck
    {
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public float ServicePrice { get; set; }
        [NotMapped]
        public int CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public float Sum { get; set; }
    }
}
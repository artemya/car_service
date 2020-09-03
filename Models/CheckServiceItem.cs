using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CheckServiceItem
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ServiceId { get; set; }
        [NotMapped]
        public string ServiceName { get; set; }
        public float ServicePrice { get; set; }
    }
}
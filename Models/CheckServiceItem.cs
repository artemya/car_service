namespace car_service.API.Models
{
    public class CheckServiceItem
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ServiceId { get; set; }
        public int ExpendableMaterialId { get; set; }
    }
}
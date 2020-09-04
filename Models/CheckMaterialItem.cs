using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CheckMaterialItem
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ExpendableMaterialId { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
        [NotMapped]
        public float MaterialPrice { get; set; }
    }
}
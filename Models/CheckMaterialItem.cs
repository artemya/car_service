using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CheckMaterialItem
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ExpendableMaterialsId { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
        public float MaterialPrice { get; set; }
    }
}
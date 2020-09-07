using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CheckSum
    {
        [NotMapped]
        public int CheckId { get; set; }
        [NotMapped]
        public float Sum { get; set; }
    }
}
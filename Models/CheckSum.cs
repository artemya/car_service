using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CheckSum
    {
        [NotMapped]
        public int CheckId { get; set; }
        [NotMapped]
        public float Sum { get; set; }
        [NotMapped]
        public List<string> checkMaterial { get; set; }
        [NotMapped]
        public List<string> checkService { get; set; }
        [NotMapped]
        public List<CategorySum> categoryCheck { get; set; }

    }
}
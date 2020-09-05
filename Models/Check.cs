using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class Check
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public CheckServiceItem CheckServiceItem { get; set; }

        [NotMapped]
        public string ClientName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
        [NotMapped]
        public float MaterialPrice { get; set; }
    }
}
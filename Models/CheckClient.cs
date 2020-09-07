using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_service.API.Models
{
    public class CheckClient
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }

    }
}
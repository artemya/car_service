using System;
using System.Collections.Generic;

namespace car_service.API.Models
{
    public class Check
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
    }
}
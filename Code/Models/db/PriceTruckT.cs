using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class PriceTruckT
    {
        public int AutoId { get; set; }
        public string? Trucktype { get; set; }
        public string? Min { get; set; }
        public string? Max { get; set; }
        public string? Price { get; set; }
    }
}

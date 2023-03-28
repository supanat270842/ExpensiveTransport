using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class MasterTruckType
    {
        public int AutoId { get; set; }
        public string? TypeTruck { get; set; }
        public string? IdTruck { get; set; }
        public string? Status { get; set; }
    }
}

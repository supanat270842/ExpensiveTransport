using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class ConfigShippingPrice
    {
        public int AutoId { get; set; }
        public string? ShippingType { get; set; }
        public string? Price { get; set; }
        public string? Status { get; set; }
    }
}

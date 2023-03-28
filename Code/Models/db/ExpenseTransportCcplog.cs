using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class ExpenseTransportCcplog
    {
        public int LautoId { get; set; }
        public string? DoNumber { get; set; }
        public DateTime? ActualGidateSap { get; set; }
        public string? SoldTo { get; set; }
        public string? SoldToName { get; set; }
        public string? LshipTo { get; set; }
        public string? LshipToName { get; set; }
        public string? Transport { get; set; }
        public string? ShippingType { get; set; }
        public string? ShippingName { get; set; }
        public string? LtransportZone { get; set; }
        public string? LtransportZoneName { get; set; }
        public double? Lmptprice { get; set; }
        public double? Lcfprice { get; set; }
        public double? Lamount { get; set; }
        public string? Lstatus { get; set; }
        public string? LeditBy { get; set; }
        public DateTime? LeditDate { get; set; }
        public string? Lfactory { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class ExpenseTransportCcp
    {
        public int EtautoId { get; set; }
        public string DoNumber { get; set; }
        public DateTime ActualGidateSap { get; set; }
        public string? SoldTo { get; set; }
        public string? SoldToName { get; set; }
        public string? EtshipTo { get; set; }
        public string? EtshipToName { get; set; }
        public string? Transport { get; set; }
        public string? ShippingType { get; set; }
        public string? ShippingName { get; set; }
        public string? EttransportZone { get; set; }
        public string? EttransportZoneName { get; set; }
        public double? Etmptprice { get; set; }
        public double? Etcfprice { get; set; }
        public double? Etamount { get; set; }
        public string? Etstatus { get; set; }
        public string? EteditBy { get; set; }
        public DateTime EteditDate { get; set; }
        public string? Etfactory { get; set; }
    }
}

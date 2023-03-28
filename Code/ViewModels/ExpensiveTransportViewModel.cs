using System;
using System.Collections.Generic;

namespace TransportManagement.ViewModels
{
    public partial class ExpensiveTransportViewModel
    {
        public int EtautoId { get; set; }
        public string DoNumber { get; set; }
        public string ActualGidateSap { get; set; }
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
        public DateTime? EteditDate { get; set; }
        public string? IdPayroll1 { get; set; }
        public string? Text { get; set; }
        public string? Status { get; set; }
        public string? CheckBotton { get; set; }
        public string? Client { get; set; }

        public string Factory { get; set; }



        public int? No_Id { get; set; }

        public List<APIGETSoldTo>? dataSoldTo { get; set; }

        public List<APIDeliveryAll>? dataDeliveryAll { get; set; }
        
    }
}

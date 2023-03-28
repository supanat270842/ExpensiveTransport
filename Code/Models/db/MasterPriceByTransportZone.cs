using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class MasterPriceByTransportZone
    {
        public int MptautoId { get; set; }
        public string? MpttransportZoneId { get; set; }
        public string? MpttransportZoneName { get; set; }
        public double Mptprice { get; set; }
        public string? Mptstatus { get; set; }
        public string? MpteditBy { get; set; }
        public DateTime? MpteditDate { get; set; }
        public string? Mptremark { get; set; }
    }
}

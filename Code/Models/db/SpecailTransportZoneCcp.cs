using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class SpecailTransportZoneCcp
    {
        public int StzautoId { get; set; }
        public string? StztransportZoneId { get; set; }
        public string? StztransportZoneName { get; set; }
        public double Stzprice { get; set; }
        public string? Stzstatus { get; set; }
        public string? StzeditBy { get; set; }
        public DateTime? StzeditDate { get; set; }
    }
}

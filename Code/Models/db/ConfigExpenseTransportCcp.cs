using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class ConfigExpenseTransportCcp
    {
        public int CfautoId { get; set; }
        public string? Cfname { get; set; }
        public double Cfprice { get; set; }
        public string? Cfstatus { get; set; }
        public string? CfeditBy { get; set; }
        public DateTime? CfeditDate { get; set; }
    }
}

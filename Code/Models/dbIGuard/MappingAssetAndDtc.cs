using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class MappingAssetAndDtc
    {
        public int MadautoId { get; set; }
        public string? AssetId { get; set; }
        public string? Madgpsid { get; set; }
        public string? Madstatus { get; set; }
        public string? MadeditBy { get; set; }
        public DateTime? MadeditDate { get; set; }
        public string? Madremark { get; set; }
    }
}

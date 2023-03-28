using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class MasterAppType
    {
        public int MstAutoId { get; set; }
        public string? MstTypeId { get; set; }
        public string? MstDetail { get; set; }
        public string? MstStatus { get; set; }
        public string? MstCreateBy { get; set; }
        public DateTime? MstCreateDate { get; set; }
        public string? MstEditBy { get; set; }
        public DateTime? MstEditDate { get; set; }
        public string? MstImage { get; set; }
    }
}

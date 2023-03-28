using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class TbTransectionBack1
    {
        public int AutoId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? ApproveId { get; set; }
        public string? LocationId { get; set; }
        public string? Detail { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Editdate { get; set; }
        public string? CreateBy { get; set; }
        public string? EditBy { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public string? AssetId { get; set; }
        public string? AssetType { get; set; }
        public string? DetailOut { get; set; }
    }
}

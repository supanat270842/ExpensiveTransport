using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class TbPicBack1
    {
        public int AutoId { get; set; }
        public string? TypeId { get; set; }
        public int? TranId { get; set; }
        public string? Url { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Editdate { get; set; }
        public string? CreateBy { get; set; }
        public string? EditBy { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public string? TypeTran { get; set; }
    }
}

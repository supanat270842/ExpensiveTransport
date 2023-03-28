using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class TbApprove
    {
        public int AutoId { get; set; }
        public string? ApproveId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Editdate { get; set; }
        public string? CreateBy { get; set; }
        public string? EditBy { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
    }
}

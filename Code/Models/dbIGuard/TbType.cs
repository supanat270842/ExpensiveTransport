using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class TbType
    {
        public int AutoId { get; set; }
        public string? TypeId { get; set; }
        public string? Description { get; set; }
        public string? Pin { get; set; }
        public string? Pout { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Editdate { get; set; }
        public string? CreateBy { get; set; }
        public string? EditBy { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class GiCp
    {
        public int AutoId { get; set; }
        public string? DoNumber { get; set; }
        public string? GiNumber { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? EditDate { get; set; }
        public string? CreateUser { get; set; }
        public string? EditUser { get; set; }
        public string? Remark { get; set; }
    }
}

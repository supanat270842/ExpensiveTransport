using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class LogPrintCp
    {
        public int AutoId { get; set; }
        public string? DoNumber { get; set; }
        public string? Type { get; set; }
        public string? TransportOut { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? EditDate { get; set; }
        public string? CreateUser { get; set; }
        public string? EditUser { get; set; }
        public string? Remark { get; set; }
    }
}

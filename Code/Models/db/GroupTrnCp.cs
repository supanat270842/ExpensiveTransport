using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class GroupTrnCp
    {
        public int AutoId { get; set; }
        public string? DoNumber { get; set; }
        public string? TrnNumber { get; set; }
        public string? Company { get; set; }
        public string? StatusJoin { get; set; }
        public string? Status { get; set; }
        public string? CreateDate { get; set; }
        public string? EditDate { get; set; }
        public string? CreateUser { get; set; }
        public string? EditUser { get; set; }
        public string? Remark { get; set; }
    }
}

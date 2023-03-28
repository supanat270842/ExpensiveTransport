using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class Log
    {
        public int AutoId { get; set; }
        public string? Doc { get; set; }
        public string? CreateDate { get; set; }
        public string? Remark { get; set; }
    }
}

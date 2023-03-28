using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class TbAuthorize
    {
        public int AutoId { get; set; }
        public string? EmpId { get; set; }
        public string? Location { get; set; }
        public string? TypeEdit { get; set; }
        public string? Status { get; set; }
    }
}

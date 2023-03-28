using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class ItemCp
    {
        public int AutoId { get; set; }
        public string? DoNumber { get; set; }
        public string? ItemNumber { get; set; }
        public string? Material { get; set; }
        public string? QtySo { get; set; }
        public string? QtyDo { get; set; }
        public string? Plant { get; set; }
        public string? StgeLoc { get; set; }
        public string? CarType { get; set; }
        public string? Transport { get; set; }
        public string? Driver { get; set; }
        public string? WeightItemDo { get; set; }
        public string? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? EditDate { get; set; }
        public string? CreateUser { get; set; }
        public string? EditUser { get; set; }
        public string? Remark { get; set; }
    }
}

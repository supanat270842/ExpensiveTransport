using System.ComponentModel.DataAnnotations;

public partial class MappingViewModel
    {
        public int MadautoId { get; set; }
        public string? AssetId { get; set; }
        public string? Madgpsid { get; set; }
        public string? Madstatus { get; set; }
        public string? MadeditBy { get; set; }
        public DateTime? MadeditDate { get; set; }
        public string? Madremark { get; set; }

        public string _simNo { get; set; }
    }
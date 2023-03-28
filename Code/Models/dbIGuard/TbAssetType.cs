using System;
using System.Collections.Generic;

namespace TransportManagement.Models.dbIGuard
{
    public partial class TbAssetType
    {
        public int AutoId { get; set; }
        public string? AssetTypeId { get; set; }
        public string? AssetTypeName { get; set; }
        public string? Status { get; set; }
        public string? AssetNonePic { get; set; }
        public string? AssetNonePicOut { get; set; }
    }
}

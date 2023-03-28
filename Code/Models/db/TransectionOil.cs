using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class TransectionOil
    {
        public int TrAutoId { get; set; }
        public string? TrDocument { get; set; }
        public string? MstTypeId { get; set; }
        public string? TrRegistration { get; set; }
        public string? Time { get; set; }
        public string? TrStatus { get; set; }
        public string? TrCreateBy { get; set; }
        public DateTime? TrCreateDate { get; set; }
        public string? TrEditBy { get; set; }
        public DateTime? TrEditDate { get; set; }
        public string? SubdistrictEn { get; set; }
        public string? SubdistrictTh { get; set; }
        public string? DistrictTh { get; set; }
        public string? DistrictEn { get; set; }
        public string? ProvinceTh { get; set; }
        public string? ProvinceEn { get; set; }
        public string? StationId { get; set; }
        public string? StationName { get; set; }
        public double? GpsIdDtc { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public double? Mileage { get; set; }
        public string? DriverCardId { get; set; }
        public string? DriverFullName { get; set; }
        public string? DriverPersonalCard { get; set; }
    }
}

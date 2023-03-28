using System;
using System.Collections.Generic;

namespace TransportManagement.Models.db
{
    public partial class ViewCp
    {
        public int AutoId { get; set; }
        public string? DoNumber { get; set; }
        public string? ItemNumber { get; set; }
        public string? Material { get; set; }
        public string? QtySo { get; set; }
        public string? QtyDo { get; set; }
        public string? Plant { get; set; }
        public string? StgeLoc { get; set; }
        public string? Transport { get; set; }
        public string? Driver { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? EditDate { get; set; }
        public string? CreateUser { get; set; }
        public string? EditUser { get; set; }
        public string? Remark { get; set; }
        public string? SoldTo { get; set; }
        public string? ShipTo { get; set; }
        public string? QtyItem { get; set; }
        public string? DoDate { get; set; }
        public string? Status { get; set; }
        public string? SoNumber { get; set; }
        public string? CarType { get; set; }
        public string? Ponumber { get; set; }
        public string? ShippingType { get; set; }
        public string? WeightItemDo { get; set; }
        public string? WeightDo { get; set; }
        public string? SaleOrderType { get; set; }
        public string? OrderType { get; set; }
        public string? DocumentDate { get; set; }
        public string? PlannedGidate { get; set; }
        public string? ActualGidate { get; set; }
        public string? Incoterms { get; set; }
        public string? Price { get; set; }
        public string? Amphoe { get; set; }
        public string? TransportZone { get; set; }
        public string? PriceTransport { get; set; }
        public string? SoTransport { get; set; }
        public string? Distance { get; set; }
        public string? PlantDo { get; set; }
        public string? DeliveryDate { get; set; }
        public string? GiDate { get; set; }
        public string? TypeTransport { get; set; }
        public string? Tel { get; set; }
        public string? PriceTransportGi { get; set; }
        public string? ActualGidateSap { get; set; }
        public string? DoiTrading { get; set; }
        public string? ShipToiTrading { get; set; }
        public string? DescriptionShipToiTrading { get; set; }
        public string? DistanceiTrading { get; set; }
    }
}

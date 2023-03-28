// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class APIDeliveryAll
    {
        public int AutoID { get; set; }
        public string Division { get; set; }
        public string Plant { get; set; }
        public string PlantZoneStartID { get; set; }
        public string DescriptionStart { get; set; }
        public string ShipToZone { get; set; }
        public string ShipToZoneID { get; set; }
        public string Y4 { get; set; }
        public string Y3 { get; set; }
        public string Y2 { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string EditDate { get; set; }
        public string Remark { get; set; }
    }
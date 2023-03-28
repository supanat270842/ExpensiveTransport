// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumVehicle
    {
        public string gps_id { get; set; }
        public string vehicle_name { get; set; }
        public string license_plate { get; set; }
        public string sim_no { get; set; }
    }

    public class APIVehicleModel
    {
        public bool error { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public int count { get; set; }
        public List<DatumVehicle> data { get; set; }
    }
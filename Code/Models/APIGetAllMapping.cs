// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum
    {
        public int madAutoId { get; set; }
        public string assetID { get; set; }
        public string madgpsId { get; set; }
        public string madStatus { get; set; }
        public string madEditBy { get; set; }
        public DateTime madEditDate { get; set; }
        public object madRemark { get; set; }
    }

    public class APIGetAllMapping
    {
        public bool isSuccess { get; set; }
        public string isError { get; set; }
        public int isCode { get; set; }
        public List<Datum> data { get; set; }
    }
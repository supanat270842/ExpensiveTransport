// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumMaster
    {
        public int autoId { get; set; }
        public string assetId { get; set; }
        public string name { get; set; }
        public object locationId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime editdate { get; set; }
        public string createBy { get; set; }
        public string editBy { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public string assetType { get; set; }
        public string empId { get; set; }
    }

    public class APIGetMasterAssetID
    {
        public string isSuccess { get; set; }
        public string isError { get; set; }
        public string isCode { get; set; }
        public List<DatumMaster> data { get; set; }
    }
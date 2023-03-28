// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum1
    {
        public string Client { get; set; }
        public string LanguageKey { get; set; }
        public string Shippingtype { get; set; }
        public string ShippingName { get; set; }
    }

    public class APIShippingType
    {
        public bool isSuccess { get; set; }
        public string isError { get; set; }
        public int isCode { get; set; }
        public List<Datum1> data { get; set; }
    }
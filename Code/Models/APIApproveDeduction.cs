// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class APIApproveDeduction
    {      
        public string CacheControl { get; set; }      
        public string ContentLength { get; set; }     
        public string ContentType { get; set; }
        public string date { get; set; }
        public string expires { get; set; }
        public string pragma { get; set; }
        public string server { get; set; }    
        public string XAspnetVersion { get; set; }    
        public string XPoweredBy { get; set; }

    public static implicit operator string(APIApproveDeduction v)
    {
        throw new NotImplementedException();
    }
}
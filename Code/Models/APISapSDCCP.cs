// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Data
{
    public string CUSTOMER { get; set; }
    public string NAME { get; set; }
    public string NAME_2 { get; set; }
    public string NAME_3 { get; set; }
    public string NAME_4 { get; set; }
    public string CITY { get; set; }
    public string DISTRICT { get; set; }
    public string PO_BOX { get; set; }
    public string POBX_PCD { get; set; }
    public string POSTL_CODE { get; set; }
    public string REGION { get; set; }
    public string COUNTYCODE { get; set; }
    public string CITY_CODE { get; set; }
    public string STREET { get; set; }
    public string TELEPHONE { get; set; }
    public string COUNTRY { get; set; }
    public string COUNTRYISO { get; set; }
    public string POBX_CTY { get; set; }
    public string LANGU { get; set; }
    public string LANGU_ISO { get; set; }
    public string SORT_FLD { get; set; }
    public string MATCHCODE1 { get; set; }
    public string MATCHCODE2 { get; set; }
    public string MATCHCODE3 { get; set; }
    public string FORMOFADDR { get; set; }
    public string TELEBOX { get; set; }
    public string TELEPHONE2 { get; set; }
    public string TELETEX { get; set; }
    public string TELEX { get; set; }
    public string TRANSPZONE { get; set; }
    public string NIELSEN_ID { get; set; }
    public string TYPE { get; set; }
    public string ID { get; set; }
    public string NUMBER { get; set; }
    public string MESSAGE { get; set; }
    public string LOG_NO { get; set; }
    public string LOG_MSG_NO { get; set; }
    public string MESSAGE_V1 { get; set; }
    public string MESSAGE_V2 { get; set; }
    public string MESSAGE_V3 { get; set; }
    public string MESSAGE_V4 { get; set; }
}

public class APISapSDCCP
{
    public string isSuccess { get; set; }
    public string isError { get; set; }
    public string isCode { get; set; }
    public List<Data> data { get; set; }
}
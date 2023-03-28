using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TransportManagement.Models;

namespace TransportManagement.Services;

public class NetworkService
{
    static HttpClient client = new HttpClient();
    static string api_token_key = "BYXGCJKPEFN176P3T2A44D791GYXMZJK9FUTBS2LRW3D86QHRZEQVN5S8CHL5VUM";
    static string domain = "https://gps.dtc.co.th:8099";
    public static async Task<APIVehicleModel> getVehicleMaster()
    {
        try
        {
            string uri = domain + "/getVehicleMaster";
            string activityReport = MakeRequest(HttpMethod.Post, uri, new
            {
                api_token_key = api_token_key
                // gps_list = new[] { licensePlate }

            }).Result;
            APIVehicleModel result = JsonConvert.DeserializeObject<APIVehicleModel>(activityReport);
            return result;
        }
        catch (HttpRequestException e)
        {
            throw new ArgumentException("NetworkService getVehicleMaster " + e.Message);
        }
        return null;
    }

    static async Task<string> MakeRequest(HttpMethod method, string uri, object body)
    {
        string jsonResult = string.Empty;
        HttpResponseMessage response;

        // Request body
        string jsonContent = JObject.FromObject(body).ToString(Newtonsoft.Json.Formatting.None);
        using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
        {
            HttpRequestMessage request = new HttpRequestMessage(method, uri)
            {
                Content = content
            };
            response = client.SendAsync(request).Result;
            jsonResult = await response.Content.ReadAsStringAsync();
        }
        return jsonResult;
    }


    public static async Task<APIDeliveryCost> APIDelivery(string tpzone)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "http://ccp-info2.com";
                string funtion = "/APIDeliveryCost/api/Get/GetAPIDeliveryCost" +
                $"?ShipToZoneID={tpzone}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(funtion);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIDeliveryCost result = JsonConvert.DeserializeObject<APIDeliveryCost>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("APIDelivery " + e.Message);
            }
        }
        return null;
    }

    public static async Task<String> APIApprove(string soldTo)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string funtion = "/APIApproveDeduction/api/Get/GetSoleToName" +
                $"?SoldToNumber={soldTo}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(funtion);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                String result = JsonConvert.DeserializeObject<String>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("APIApprove " + e.Message);
            }
        }
        return null;
    }


    public static async Task<List<APIGETSoldTo>> GETSoldTo(string data)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APIApproveDeduction/api/Get/GETSoldTo" +
                $"?Description={data}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                List<APIGETSoldTo> result = JsonConvert.DeserializeObject<List<APIGETSoldTo>>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GETSoldTo " + e.Message);
            }
        }

        return null;
    }

    public static async Task<APISapSDCCP> GetCustomerDetail(string data)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APISapSDCCP/api/Master/GetCustomerDetailByNumber" +
                $"?CustomerNo={data}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APISapSDCCP result = JsonConvert.DeserializeObject<APISapSDCCP>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetCustomerDetail" + e.Message);
            }
        }
        return null;
    }

    public static async Task<APIGetDO> GetDO(string DoNum)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APISapSDCCP/api/Master/GetDOHeaderByDONumber" +
                $"?DONo={DoNum}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIGetDO result = JsonConvert.DeserializeObject<APIGetDO>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetDO" + e.Message);
            }
        }
        return null;
    }
    public static async Task<APIGetDOCPS> GetDOCPS(string DoNum)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APISapSDCPS/api/Master/GetDOHeaderByDONumber" +
                $"?DONo={DoNum}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIGetDOCPS result = JsonConvert.DeserializeObject<APIGetDOCPS>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetDOCPS" + e.Message);
            }
        }
        return null;
    }

    public static async Task<APICreatedon> Createdon(string DateStart, string DateEnd)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APISapSDCCP/api/Master/GetDOHeaderByBetweenCreatedonDate" +
                $"?CreatedonDateSatart={DateStart}&CreatedonDateEnd={DateEnd}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APICreatedon result = JsonConvert.DeserializeObject<APICreatedon>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("Createdon" + e.Message);
            }
        }
        return null;
    }

    public static async Task<APIShippingType> GETAllShippingType()
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APISapSDCCP/api/Master/GetAllTransportShippingType";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIShippingType result = JsonConvert.DeserializeObject<APIShippingType>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetAllShippingType" + e.Message);
            }
        }
        return null;
    }

    public static async Task<APILoginModel> StdLogin(string user, string pass, string programId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "http://ccp-info2.com";
                string function = "APIMasterCCP/api/GetData/CheckLoginMasterCCP" +
                $"?username={user}&password={pass}&programId={programId}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APILoginModel result = JsonConvert.DeserializeObject<APILoginModel>(strResponse);

                return result;

            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("StdLogin" + e.Message);
            }
        }
        return null;
    }

    public static async Task<APIGetAllMapping> GetMapping()
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APIOilStation/Get/api/GetAllMappingAssetAndDtcGPSId";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIGetAllMapping result = JsonConvert.DeserializeObject<APIGetAllMapping>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetMapping" + e.Message);
            }
        }
        return null;
    }

    public static async Task<APIGetImage> GetImage(string docNumber)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "http://192.168.0.81";
                string function = "/APIOilStation/Get/api/GetImage" +
                $"?DocNumber={docNumber}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIGetImage result = JsonConvert.DeserializeObject<APIGetImage>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetImage" + e.Message);
            }
        }
        return null;
    }

    public static async Task<List<APIDeliveryAll>> GetDeliveryAlls()
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "http://ccp-info2.com";
                string function = "/APIDeliveryCost/api/Get/GetAPIDeliveryCostAll";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                List<APIDeliveryAll> result = JsonConvert.DeserializeObject<List<APIDeliveryAll>>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetDeliveryAlls" + e.Message);
            }
        }
        return null;
    }
    public static async Task<List<APITest>> GetReportTest(int id)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://localhost:7125";
                string function = "/Report";

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJyb2xlIjoiQWRtaW4iLCJhZGRpdGlvbmFsIjoidG9kbyIsImV4cCI6MTY3NTY2Njk0OSwiaXNzIjoiQ29kZU1vYmlsZXMiLCJhdWQiOiJodHRwczovL2NvZGVtb2JpbGVzLmNvbSJ9.158G3UZz3cPWTABTZrOqjSwYdPnolqLFrUKRyDnPjKI");
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                List<APITest> result = JsonConvert.DeserializeObject<List<APITest>>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetReportTest" + e.Message);
            }
        }
        return null;
    }
    public static async Task<APICreatedonCPS> CreatedonCPS(string DateStart, string DateEnd)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APISapSDCPS/api/Master/GetDOHeaderByBetweenCreatedonDate" +
                $"?CreatedonDateSatart={DateStart}&CreatedonDateEnd={DateEnd}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APICreatedonCPS result = JsonConvert.DeserializeObject<APICreatedonCPS>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("CreatedonCPS" + e.Message);
            }
        }
        return null;
    }
    public static async Task<APIGetMasterAssetID> GetMasterAssetID()
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "https://ccpnext.com";
                string function = "/APIOilStation/Get/api/GetMasterAssetID";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);
                response.EnsureSuccessStatusCode();

                var strResponse = await response.Content.ReadAsStringAsync();
                APIGetMasterAssetID result = JsonConvert.DeserializeObject<APIGetMasterAssetID>(strResponse);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("GetMasterAssetID" + e.Message);
            }
        }
        return null;
    }
    



    internal static Task APIApprove()
    {
        throw new NotImplementedException();
    }

    internal static Task GETSoldTo()
    {
        throw new NotImplementedException();
    }
}
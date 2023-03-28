namespace TransportManagement.ViewModels;

public class CreateExpensiveTransportViewModel
{
    public int EtautoId { get; set; }
    public string? DoNumber { get; set; }
    // public string Createdon { get; set; }
    public string? SoldTo { get; set; }
    public string? ShipTo { get; set; }
    public string? ActualGidateSap { get; set; }
    public string? TransportZone { get; set; }
    public string? Transport { get; set; }
    public string? CarType { get; set; }
    public double Cfprice { get; set; }
    public string? Text { get; set; }
    // public string? StztransportZoneId { get; set; }
    public double Stzprice { get; set; }
    // public string ShipToZone { get; set; }
    public string? SoldToName { get; set; }
    public string? EtshipToName { get; set; }
    public double TotalPrice { get; set; }
    public string ShipToTransportName { get; set; }
    public string Factory { get; set; }

    public List<APIGETSoldTo>? dataSoldTo { get; set; }

    public List<APIDeliveryAll>? dataDeliveryAll { get; set; }

   
}
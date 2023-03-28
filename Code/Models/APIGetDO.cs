// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DataDo
    {
        public string Client { get; set; }
        public string Delivery { get; set; }
        public string Createdby { get; set; }
        public string Time { get; set; }
        public string Createdon { get; set; }
        public string Salesdistrict { get; set; }
        public string ShippingPoint { get; set; }
        public string SalesOrg { get; set; }
        public string DeliveryType { get; set; }
        public string Completedlv { get; set; }
        public string Ordercombinat { get; set; }
        public string Plannedgdsmvmt { get; set; }
        public string LoadingDate { get; set; }
        public string TranspPlngDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PickDate { get; set; }
        public string UnloadingPoint { get; set; }
        public string Incoterms { get; set; }
        public string Incoterms2 { get; set; }
        public string Export { get; set; }
        public string Route { get; set; }
        public string Billingblock { get; set; }
        public string Deliveryblock { get; set; }
        public string Documentcat { get; set; }
        public string FactoryCalendar { get; set; }
        public string notcurrentlyinuseTPQUA { get; set; }
        public string notcurrentlyinuseTPGRP { get; set; }
        public string DeliveryPrior { get; set; }
        public string ShpCond { get; set; }
        public string Shiptoparty { get; set; }
        public string Soldtoparty { get; set; }
        public string Customergroup { get; set; }
        public string notcurrentlyinuseSTZKL { get; set; }
        public string notcurrentlyinuseSTZZU { get; set; }
        public string TotalWeight { get; set; }
        public string Netweight { get; set; }
        public string Weightunit { get; set; }
        public string Volume { get; set; }
        public string Volumeunit { get; set; }
        public string Noofpackages { get; set; }
        public string PickedItmLocat { get; set; }
        public string TimeOfDelivery { get; set; }
        public string Weightgroup { get; set; }
        public string LoadingPoint { get; set; }
        public string Transgroup { get; set; }
        public string DlvBillingType { get; set; }
        public string Billingdate { get; set; }
        public string Invoicingdates { get; set; }
        public string RouteA { get; set; }
        public string Updategroup { get; set; }
        public string Procedure { get; set; }
        public string Doccondition { get; set; }
        public string Doccurrency { get; set; }
        public string SalesOffice { get; set; }
        public string Totalproctime { get; set; }
        public string Combcriteria { get; set; }
        public string Originaldoc { get; set; }
        public string CommunicationNo { get; set; }
        public string StatsCurrency { get; set; }
        public string Exchratestats { get; set; }
        public string ShippingType { get; set; }
        public string ShippingTypeName { get; set; }
        public string SoldToCountry { get; set; }
        public string SoldToName { get; set; }
        public string SoldToName2 { get; set; }
        public string SoldToCity { get; set; }
        public string SoldToPostalCode { get; set; }
        public string SoldToRegion { get; set; }
        public string SoldToStreet { get; set; }
        public string SoldToTelephone1 { get; set; }
        public string SoldToFaxNumber { get; set; }
        public string SoldToAddress { get; set; }
        public string SoldToGroup { get; set; }
        public string SoldToAccountgroup { get; set; }
        public string SoldToDistrict { get; set; }
        public string SoldToTransportZone { get; set; }
        public string SoldToTransportName { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToName { get; set; }
        public string ShipToName2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToPostalCode { get; set; }
        public string ShipToRegion { get; set; }
        public string ShipToStreet { get; set; }
        public string ShipToTelephone1 { get; set; }
        public string ShipToFaxNumber { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToGroup { get; set; }
        public string ShipToAccountgroup { get; set; }
        public string ShipToDistrict { get; set; }
        public string ShipToTransportZone { get; set; }
        public string ShipToTransportName { get; set; }
    }

    public class APIGetDO
    {
        public bool isSuccess { get; set; }
        public string isError { get; set; }
        public int isCode { get; set; }
        public DataDo data { get; set; }
    }

using AspNetCoreHero.ToastNotification.Abstractions;
using TransportManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models.db;
using TransportManagement.Services;
using TransportManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace TransportManagement.Controllers;
[Authorize]
public class ReportExpensiveTransportController : BaseController
{
    private readonly INotyfService _notyfService;
    TransportCCPCPSContext _db;
    public ReportExpensiveTransportController(INotyfService notyfService, TransportCCPCPSContext db)
    {
        _db = db;
        _notyfService = notyfService;
    }

    public async Task<IActionResult> Index(string client, string tuckType, DateTime startDate, DateTime endDate)
    {
        int i = 1;

        var sDate = DateTime.Parse(DateTime.Now.ToString());
        var eDate = DateTime.Parse(DateTime.Now.ToString());

        List<ExpensiveTransportViewModel> etViewmodel = new List<ExpensiveTransportViewModel>();
        TransportViewModel tranViewModel = new TransportViewModel();

        var dataT = await NetworkService.GETAllShippingType();

        if (client == null || client == "CCP")
        {
            if (tuckType != null)
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
                else
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApi1 = resultApi.data.Where(c => c.ShippingType == tuckType);

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });

                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
            }
            //เปิดหน้ารอบแรก
            else
            {
                var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                // var resultApi = await NetworkService.Createdon("20230118", "20230118");


                if (resultApi.isSuccess == true)
                {
                    foreach (var item in resultApi.data)
                    {
                        if (item.DeliveryType != "EL")
                        {
                            var checkdata = await (from api in _db.ExpenseTransportCcps
                                                   where api.Etstatus == "Active"
                                                   && api.DoNumber == item.Delivery
                                                   select api).FirstOrDefaultAsync();

                            var trans = await (from tran in _db.ItemCcps
                                               where tran.DoNumber == item.Delivery
                                               && tran.Status == "Active"
                                               select tran).FirstOrDefaultAsync();
                            if (trans == null)
                            {
                                tranViewModel.Transport = "";
                            }
                            else
                            {
                                tranViewModel.Transport = trans.Transport;
                            }


                            if (checkdata != null)
                            {

                                etViewmodel.Add(new ExpensiveTransportViewModel()
                                {
                                    ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                    No_Id = i++,
                                    Client = item.Client,
                                    EtautoId = checkdata.EtautoId,
                                    DoNumber = checkdata.DoNumber,
                                    SoldTo = checkdata.SoldTo,
                                    SoldToName = checkdata.SoldToName,
                                    EtshipTo = checkdata.EtshipTo,
                                    EtshipToName = checkdata.EtshipToName,
                                    Transport = checkdata.Transport,
                                    ShippingType = checkdata.ShippingType,
                                    ShippingName = checkdata.ShippingName,
                                    Etmptprice = checkdata.Etmptprice,
                                    Etcfprice = checkdata.Etcfprice,
                                    Etamount = checkdata.Etamount,
                                    CheckBotton = "true"
                                });

                            }


                            else
                            {
                                // DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);
                                etViewmodel.Add(new ExpensiveTransportViewModel()
                                {
                                    No_Id = i++,
                                    Client = item.Client,
                                    ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                    DoNumber = item.Delivery,
                                    SoldTo = item.Soldtoparty,
                                    SoldToName = item.SoldToName,
                                    EtshipTo = item.Shiptoparty,
                                    EtshipToName = item.ShipToName,
                                    Transport = tranViewModel.Transport,
                                    ShippingType = item.ShippingType,
                                    ShippingName = item.ShippingTypeName,
                                    Etmptprice = 0,
                                    Etcfprice = 0,
                                    Etamount = 0,
                                    CheckBotton = "false"
                                });
                            }
                        }
                        else
                        {

                        }
                    }

                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    etViewmodel.OrderBy(s => s.DoNumber).ToList();
                }
            }
        }
        else if (client == "CPS")
        {
            if (tuckType != null)
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var resultApi = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
                else
                {
                    var resultApi = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApi1 = resultApi.data.Where(c => c.ShippingType == tuckType);

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });

                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
            }
        }
        else if (client == "ALL")
        {
            if (tuckType != null)
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApiCPS = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false",

                                    });
                                }
                            }
                        }

                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                    if (resultApiCPS.isSuccess == true)
                    {
                        foreach (var item in resultApiCPS.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }
                        }
                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                }
                else
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApi1 = resultApi.data.Where(c => c.ShippingType == tuckType);
                    var resultApiCPS = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApiCPS1 = resultApiCPS.data.Where(c => c.ShippingType == tuckType);

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });

                                }
                            }
                        }
                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                    if (resultApiCPS.isSuccess == true)
                    {
                        foreach (var item in resultApiCPS1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }
                        }
                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                }
            }
        }

        string[] _Client = new string[3];
        _Client[0] = "CCP";
        _Client[1] = "CPS";
        _Client[2] = "ALL";

        ViewData["ClientList"] = new SelectList (_Client,client);

        ViewData["ShippingList"] = new SelectList
        (dataT.data.Where(i => i.LanguageKey == "E"), "Shippingtype", "ShippingName", tuckType);

        ViewBag.StartDate = sDate.ToString("yyyy-MM-dd");
        ViewBag.EndDate = eDate.ToString("yyyy-MM-dd");
        ViewBag.TuckType = tuckType;     

        ViewBag.Client = client;

        return View();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////

    public async Task<IActionResult> PrintPreview(string client, string tuckType, DateTime startDate, DateTime endDate)
    {
        int i = 1;

        var sDate = DateTime.Parse(DateTime.Now.ToString());
        var eDate = DateTime.Parse(DateTime.Now.ToString());

        List<ExpensiveTransportViewModel> etViewmodel = new List<ExpensiveTransportViewModel>();
        TransportViewModel tranViewModel = new TransportViewModel();

        var dataT = await NetworkService.GETAllShippingType();

        if (client == null || client == "CCP")
        {
            if (tuckType != null)
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
                else
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApi1 = resultApi.data.Where(c => c.ShippingType == tuckType);

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });

                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
            }
            //เปิดหน้ารอบแรก
            else
            {
                var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                // var resultApi = await NetworkService.Createdon("20230112", "20230112");


                if (resultApi.isSuccess == true)
                {
                    foreach (var item in resultApi.data)
                    {
                        if (item.DeliveryType != "EL")
                        {
                            var checkdata = await (from api in _db.ExpenseTransportCcps
                                                   where api.Etstatus == "Active"
                                                   && api.DoNumber == item.Delivery
                                                   select api).FirstOrDefaultAsync();

                            var trans = await (from tran in _db.ItemCcps
                                               where tran.DoNumber == item.Delivery
                                               && tran.Status == "Active"
                                               select tran).FirstOrDefaultAsync();
                            if (trans == null)
                            {
                                tranViewModel.Transport = "";
                            }
                            else
                            {
                                tranViewModel.Transport = trans.Transport;
                            }


                            if (checkdata != null)
                            {

                                etViewmodel.Add(new ExpensiveTransportViewModel()
                                {
                                    ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                    No_Id = i++,
                                    Client = item.Client,
                                    EtautoId = checkdata.EtautoId,
                                    DoNumber = checkdata.DoNumber,
                                    SoldTo = checkdata.SoldTo,
                                    SoldToName = checkdata.SoldToName,
                                    EtshipTo = checkdata.EtshipTo,
                                    EtshipToName = checkdata.EtshipToName,
                                    Transport = checkdata.Transport,
                                    ShippingType = checkdata.ShippingType,
                                    ShippingName = checkdata.ShippingName,
                                    Etmptprice = checkdata.Etmptprice,
                                    Etcfprice = checkdata.Etcfprice,
                                    Etamount = checkdata.Etamount,
                                    CheckBotton = "true"
                                });

                            }
                            else
                            {
                                // DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);
                                etViewmodel.Add(new ExpensiveTransportViewModel()
                                {
                                    No_Id = i++,
                                    Client = item.Client,
                                    ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                    DoNumber = item.Delivery,
                                    SoldTo = item.Soldtoparty,
                                    SoldToName = item.SoldToName,
                                    EtshipTo = item.Shiptoparty,
                                    EtshipToName = item.ShipToName,
                                    Transport = tranViewModel.Transport,
                                    ShippingType = item.ShippingType,
                                    ShippingName = item.ShippingTypeName,
                                    Etmptprice = 0,
                                    Etcfprice = 0,
                                    Etamount = 0,
                                    CheckBotton = "false"
                                });
                            }
                        }
                        else
                        {

                        }


                    }

                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    etViewmodel.OrderBy(s => s.DoNumber).ToList();
                }
            }
        }
        else if (client == "CPS")
        {
            if (tuckType != null)
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var resultApi = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
                else
                {
                    var resultApi = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApi1 = resultApi.data.Where(c => c.ShippingType == tuckType);

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });

                                }
                            }

                        }
                        ViewBag.ExpensiveTransportViewModel = etViewmodel;
                    }
                }
            }
        }
        else if (client == "ALL")
        {
            if (tuckType != null)
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApiCPS = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false",

                                    });
                                }
                            }
                        }

                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                    if (resultApiCPS.isSuccess == true)
                    {
                        foreach (var item in resultApiCPS.data)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       select api).OrderBy(s => s.DoNumber).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {

                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });
                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }
                        }
                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                }
                else
                {
                    var resultApi = await NetworkService.Createdon(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApi1 = resultApi.data.Where(c => c.ShippingType == tuckType);

                    var resultApiCPS = await NetworkService.CreatedonCPS(sDate.ToString("yyyyMMdd"), eDate.ToString("yyyyMMdd"));
                    var resultApiCPS1 = resultApiCPS.data.Where(c => c.ShippingType == tuckType);

                    if (resultApi.isSuccess == true)
                    {
                        foreach (var item in resultApi1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });

                                }
                            }
                        }
                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                    if (resultApiCPS.isSuccess == true)
                    {
                        foreach (var item in resultApiCPS1)
                        {
                            if (item.DeliveryType != "EL")
                            {
                                var checkdata = await (from api in _db.ExpenseTransportCcps
                                                       where api.Etstatus == "Active"
                                                       && api.DoNumber == item.Delivery
                                                       && api.ShippingType == tuckType
                                                       select api).FirstOrDefaultAsync();

                                var trans = await (from tran in _db.ItemCcps
                                                   where tran.DoNumber == item.Delivery
                                                   && tran.Status == "Active"
                                                   select tran).FirstOrDefaultAsync();
                                if (trans == null)
                                {
                                    tranViewModel.Transport = "";
                                }
                                else
                                {
                                    tranViewModel.Transport = trans.Transport;
                                }

                                if (checkdata != null)
                                {
                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        ActualGidateSap = checkdata.ActualGidateSap.ToString("yyyy/MM/dd"),
                                        No_Id = i++,
                                        Client = item.Client,
                                        EtautoId = checkdata.EtautoId,
                                        DoNumber = checkdata.DoNumber,
                                        SoldTo = checkdata.SoldTo,
                                        SoldToName = checkdata.SoldToName,
                                        EtshipTo = checkdata.EtshipTo,
                                        EtshipToName = checkdata.EtshipToName,
                                        Transport = checkdata.Transport,
                                        ShippingType = checkdata.ShippingType,
                                        ShippingName = checkdata.ShippingName,
                                        Etmptprice = checkdata.Etmptprice,
                                        Etcfprice = checkdata.Etcfprice,
                                        Etamount = checkdata.Etamount,
                                        CheckBotton = "true"
                                    });

                                }
                                else
                                {
                                    DateTime enteredDate = DateTime.ParseExact(item.Createdon, "yyyyMMdd", null);

                                    etViewmodel.Add(new ExpensiveTransportViewModel()
                                    {
                                        No_Id = i++,
                                        Client = item.Client,
                                        ActualGidateSap = item.Createdon.Insert(4, "/").Insert(7, "/"),
                                        DoNumber = item.Delivery,
                                        SoldTo = item.Soldtoparty,
                                        SoldToName = item.SoldToName,
                                        EtshipTo = item.Shiptoparty,
                                        EtshipToName = item.ShipToName,
                                        Transport = tranViewModel.Transport,
                                        ShippingType = item.ShippingType,
                                        ShippingName = item.ShippingTypeName,
                                        Etmptprice = 0,
                                        Etcfprice = 0,
                                        Etamount = 0,
                                        CheckBotton = "false"
                                    });
                                }
                            }
                        }
                        var output = etViewmodel.OrderBy(c => c.DoNumber);
                        ViewBag.ExpensiveTransportViewModel = output;
                    }
                }
            }
        }



        ViewData["ShippingList"] = new SelectList
        (dataT.data.Where(i => i.LanguageKey == "E"), "Shippingtype", "ShippingName", tuckType);

        ViewBag.StartDate = sDate.ToString("yyyy-MM-dd");
        ViewBag.EndDate = eDate.ToString("yyyy-MM-dd");


        return View();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(ExpensiveTransportViewModel data)
    {
        if (data.DoNumber != null)
        {
            var del = await (from d in _db.ExpenseTransportCcps
                             where d.DoNumber == data.DoNumber && d.Etstatus == "Active"
                             select d).FirstOrDefaultAsync();

            del.Etstatus = "InActive";
            del.Etmptprice = 0;
            del.Etcfprice = 0;
            del.Etamount = 0;
            del.EteditDate = DateTime.Now;

            _db.Update(del);
            _db.SaveChanges();

            _notyfService.Success("ทำการลบรายการสำเร็จ");
        }
        return RedirectToAction("Index");
    }


}
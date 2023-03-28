using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models.db;
using TransportManagement.Services;
using TransportManagement.ViewModels;

namespace TransportManagement.Controllers;
[Authorize]

public class CreateExpensiveTransportController : BaseController
{
    private readonly INotyfService _notyfService;
    TransportCCPCPSContext _db;
    public CreateExpensiveTransportController(INotyfService notyfService, TransportCCPCPSContext db)
    {
        _db = db;
        _notyfService = notyfService;
    }

    public async Task<IActionResult> Index(string DoNumber)
    {
        string[] _Client = new string[2];
        _Client[0] = "CCP";
        _Client[1] = "CPS";

        ViewData["ClientList"] = new SelectList(_Client);

        ViewBag.Client = _Client;

        return View();
    }

    public async Task<IActionResult> InsertDO(string client, string DoNumber, string txtDoNumber, string txtclient)
    {
        CreateExpensiveTransportViewModel cetViewModel = new CreateExpensiveTransportViewModel();
        // List<APIGETSoldTo> getSoldTo = new List<APIGETSoldTo>();
        List<APIDeliveryAll> getDeliveryAll = new List<APIDeliveryAll>();

        string[] _Client = new string[2];
        _Client[0] = "CCP";
        _Client[1] = "CPS";

        ViewData["ClientList"] = new SelectList(_Client, client);

        ViewBag.Client = client;

        var checkDatas = await (from checkdata in _db.ExpenseTransportCcps
                                where checkdata.Etstatus == "Active"
                                && checkdata.DoNumber == DoNumber
                                && checkdata.Etfactory == client
                                select checkdata).FirstOrDefaultAsync();
        if (checkDatas != null)
        {
            ViewBag.CreateModel = checkDatas;

            return RedirectToAction("CheckData"
                                    , "CreateExpensiveTransport"
                                    , new { EtautoId = checkDatas.EtautoId, doNumber = checkDatas.DoNumber, client = client });
        }

        if (@TempData["txtNameShipTo"] != null)
        {
            {
                string transportZone = @TempData["txtNameShipTo"].ToString();
                var data = await NetworkService.GetDeliveryAlls();
                var resultDeliveryAll = data.Where(c => c.ShipToZone.Contains(transportZone));

                foreach (var item in resultDeliveryAll)
                {
                    getDeliveryAll.Add(new APIDeliveryAll()
                    {
                        ShipToZone = item.ShipToZone,
                        ShipToZoneID = item.ShipToZoneID
                    });
                }

                if (getDeliveryAll.Count != 0)
                {
                    @TempData["txtNameShipTo"] = null;
                    cetViewModel.dataDeliveryAll = getDeliveryAll;
                    string DoNum = @TempData["txtDO"].ToString();
                    string ClientNum = @TempData["txtClient"].ToString();
                    @TempData["DoNumber"] = DoNum;
                    @TempData["ClientNumber"] = ClientNum;
                    return View(cetViewModel);
                }
                else
                {
                    @TempData["txtNameShipTo"] = null;
                    DoNumber = @TempData["txtDO"].ToString();
                    client = @TempData["txtClient"].ToString();

                    _notyfService.Error("กรุณากรอกข้อมูลให้ถูกต้อง");
                }

            }

        }
        else if (@TempData["txtDO"] != null && @TempData["txtClient"] != null)
        {
            DoNumber = @TempData["txtDO"].ToString();
            client = @TempData["txtClient"].ToString();
        }

        double tpPrice = 0;
        double otherPrice = 0;

        if (client == "CCP")
        {
            if (!String.IsNullOrEmpty(DoNumber))
            {
                var doNum = await NetworkService.GetDO(DoNumber);

                if (doNum.isSuccess == true)
                {
                    try
                    {
                        cetViewModel.DoNumber = doNum.data.Delivery;
                        cetViewModel.ActualGidateSap = doNum.data.Createdon;
                        cetViewModel.SoldTo = doNum.data.Soldtoparty;
                        cetViewModel.SoldToName = doNum.data.SoldToName;
                        cetViewModel.ShipTo = doNum.data.Shiptoparty;
                        cetViewModel.EtshipToName = doNum.data.ShipToName;
                        cetViewModel.CarType = doNum.data.ShippingType;
                        cetViewModel.Text = doNum.data.ShippingTypeName;
                        cetViewModel.TransportZone = doNum.data.ShipToTransportZone;
                        cetViewModel.ShipToTransportName = doNum.data.ShipToTransportName;
                        cetViewModel.dataDeliveryAll = getDeliveryAll;
                        cetViewModel.Factory = client;

                        var trans = await (from tran in _db.ItemCcps
                                           where tran.Status == "Active"
                                           && tran.DoNumber == doNum.data.Delivery
                                           select tran).FirstOrDefaultAsync();
                        if (trans == null)
                        {
                            cetViewModel.Transport = "";
                        }
                        else
                        {
                            cetViewModel.Transport = trans.Transport;
                        }

                        var cons = await (from con in _db.ConfigExpenseTransportCcps
                                          where con.Cfstatus == "Active"
                                          select con).FirstOrDefaultAsync();
                        cetViewModel.Cfprice = cons.Cfprice;
                        otherPrice = cons.Cfprice;

                        var stz = await (from st in _db.SpecailTransportZoneCcps
                                         where st.StztransportZoneId == doNum.data.ShipToTransportZone
                                         select st).FirstOrDefaultAsync();
                        if (stz != null)
                        {
                            if (stz.Stzprice == 0)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }
                            else
                            {
                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }
                        }
                        else
                        {
                            var mpt = await (from mp in _db.MasterPriceByTransportZones
                                             where mp.MpttransportZoneId == doNum.data.ShipToTransportZone
                                             select mp).FirstOrDefaultAsync();
                            if (mpt == null)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                mpt.Mptprice = 0;
                                cetViewModel.Stzprice = mpt.Mptprice;
                                tpPrice = mpt.Mptprice;

                            }
                            else
                            {
                                if (mpt.Mptprice == 0)
                                {
                                    cetViewModel.Cfprice = 0;
                                    otherPrice = 0;

                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }
                                else
                                {
                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }

                            }

                        }

                        @TempData["txtShipTo"] = cetViewModel.ShipTo;

                        cetViewModel.TotalPrice = tpPrice + otherPrice;

                        if (cetViewModel == null)
                        {
                            _notyfService.Error("ไม่พบข้อมูล DO");
                            return RedirectToAction(nameof(Index));
                        }
                        @TempData["txtDO"] = DoNumber;
                        @TempData["txtClient"] = client;
                        return View(cetViewModel);
                    }
                    catch (Exception ex)
                    {
                        _notyfService.Error(ex.Message);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    _notyfService.Error("No Data");
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                _notyfService.Error("กรุณากรอกข้อมูลเลขDO");
                return RedirectToAction(nameof(Index));
            }
        }
        else if (client == "CPS")
        {
            if (!String.IsNullOrEmpty(DoNumber))
            {
                var doNum = await NetworkService.GetDOCPS(DoNumber);

                if (doNum.isSuccess == true)
                {
                    try
                    {

                        cetViewModel.DoNumber = doNum.data.Delivery;
                        cetViewModel.ActualGidateSap = doNum.data.Createdon;
                        cetViewModel.SoldTo = doNum.data.Soldtoparty;
                        cetViewModel.SoldToName = doNum.data.SoldToName;
                        cetViewModel.ShipTo = doNum.data.Shiptoparty;
                        cetViewModel.EtshipToName = doNum.data.ShipToName;
                        cetViewModel.CarType = doNum.data.ShippingType;
                        cetViewModel.Text = doNum.data.ShippingTypeName;
                        cetViewModel.TransportZone = doNum.data.ShipToTransportZone;
                        cetViewModel.ShipToTransportName = doNum.data.ShipToTransportName;
                        cetViewModel.dataDeliveryAll = getDeliveryAll;
                        cetViewModel.Factory = client;

                        var trans = await (from tran in _db.ItemCcps
                                           where tran.Status == "Active"
                                           && tran.DoNumber == doNum.data.Delivery
                                           select tran).FirstOrDefaultAsync();
                        if (trans == null)
                        {
                            cetViewModel.Transport = "";
                        }
                        else
                        {
                            cetViewModel.Transport = trans.Transport;
                        }

                        var cons = await (from con in _db.ConfigExpenseTransportCcps
                                          where con.Cfstatus == "Active"
                                          select con).FirstOrDefaultAsync();
                        cetViewModel.Cfprice = cons.Cfprice;
                        otherPrice = cons.Cfprice;

                        var stz = await (from st in _db.SpecailTransportZoneCcps
                                         where st.StztransportZoneId == doNum.data.ShipToTransportZone
                                         select st).FirstOrDefaultAsync();
                        if (stz != null)
                        {
                            if (stz.Stzprice == 0)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }
                            else
                            {
                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }
                        }
                        else
                        {
                            var mpt = await (from mp in _db.MasterPriceByTransportZones
                                             where mp.MpttransportZoneId == doNum.data.ShipToTransportZone
                                             select mp).FirstOrDefaultAsync();
                            if (mpt == null)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                mpt.Mptprice = 0;
                                cetViewModel.Stzprice = mpt.Mptprice;
                                tpPrice = mpt.Mptprice;

                            }
                            else
                            {
                                if (mpt.Mptprice == 0)
                                {
                                    cetViewModel.Cfprice = 0;
                                    otherPrice = 0;

                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }
                                else
                                {
                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }

                            }

                        }

                        @TempData["txtShipTo"] = cetViewModel.ShipTo;

                        cetViewModel.TotalPrice = tpPrice + otherPrice;

                        if (cetViewModel == null)
                        {
                            _notyfService.Error("ไม่พบข้อมูล DO");
                            return RedirectToAction(nameof(Index));
                        }
                        @TempData["txtDO"] = DoNumber;
                        @TempData["txtClient"] = client;
                        return View(cetViewModel);
                    }
                    catch (Exception ex)
                    {
                        _notyfService.Error(ex.Message);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    _notyfService.Error("No Data");
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                _notyfService.Error("กรุณากรอกข้อมูลเลขDO");
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            _notyfService.Error("กรุณาเลือก Client");
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    public async Task<IActionResult> CheckData(int EtautoId, string doNumber, string client)
    {
        List<CreateExpensiveTransportViewModel> cetViewModel = new List<CreateExpensiveTransportViewModel>();

        string[] _Client = new string[2];
        _Client[0] = "CCP";
        _Client[1] = "CPS";

        ViewData["ClientList"] = new SelectList(_Client, client);

        cetViewModel.Add(new CreateExpensiveTransportViewModel()
        {
            EtautoId = EtautoId,
            DoNumber = doNumber
        });

        ViewBag.CreateExpensiveTransportViewModel = cetViewModel;

        if (client == null && doNumber == null && EtautoId != null)
        {
            var checks = await (from check in _db.ExpenseTransportCcps
                                where check.Etstatus == "Active"
                                && check.EtautoId == EtautoId
                                select check).FirstOrDefaultAsync();
            if (checks != null)
            {
                return RedirectToAction("EditExpensiveTransport"
                                       , "EditExpensiveTransport"
                                       , new { EtautoId = EtautoId });
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        if(doNumber == "99999")
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateDO(CreateExpensiveTransportViewModel data)
    {
        if (ModelState.IsValid)
        {
            var dataExs = await (from dataEx in _db.ExpenseTransportCcps
                                 where dataEx.Etstatus == "Active"
                                 && dataEx.DoNumber == data.DoNumber
                                 && dataEx.Etfactory == data.Factory
                                 select dataEx).FirstOrDefaultAsync();
            if (dataExs != null)
            {
                DateTime enteredDate = DateTime.ParseExact(data.ActualGidateSap, "yyyyMMdd", null);

                ExpenseTransportCcp exs = new ExpenseTransportCcp();
                dataExs.DoNumber = data.DoNumber;
                dataExs.ActualGidateSap = enteredDate;
                dataExs.SoldTo = data.SoldTo;
                dataExs.SoldToName = data.SoldToName;
                dataExs.EtshipTo = data.ShipTo;
                dataExs.EtshipToName = data.EtshipToName;
                dataExs.Transport = data.Transport;
                dataExs.ShippingType = data.CarType;
                dataExs.ShippingName = data.Text;
                dataExs.EttransportZone = data.TransportZone;
                dataExs.EttransportZoneName = data.ShipToTransportName;
                dataExs.Etmptprice = data.Stzprice;
                dataExs.Etcfprice = data.Cfprice;
                dataExs.Etamount = data.TotalPrice;
                dataExs.Etfactory = data.Factory;
                dataExs.Etstatus = "Active";
                dataExs.EteditBy = User.Identity.Name;
                dataExs.EteditDate = DateTime.Now;

                _db.Update(dataExs);
                await _db.SaveChangesAsync();

                ExpenseTransportCcplog el = new ExpenseTransportCcplog();
                el.DoNumber = data.DoNumber;
                el.ActualGidateSap = enteredDate;
                el.SoldTo = data.SoldTo;
                el.SoldToName = data.SoldToName;
                el.LshipTo = data.ShipTo;
                el.LshipToName = data.EtshipToName;
                el.Transport = data.Transport;
                el.ShippingType = data.CarType;
                el.ShippingName = data.Text;
                el.LtransportZone = data.TransportZone;
                el.LtransportZoneName = data.ShipToTransportName;
                el.Lmptprice = data.Stzprice;
                el.Lcfprice = data.Cfprice;
                el.Lamount = data.TotalPrice;
                el.Lfactory = data.Factory;
                el.Lstatus = "Active";
                el.LeditBy = User.Identity.Name;
                el.LeditDate = DateTime.Now;

                _db.Add(el);
                await _db.SaveChangesAsync();
            }
            else
            {
                DateTime enteredDate = DateTime.ParseExact(data.ActualGidateSap, "yyyyMMdd", null);

                ExpenseTransportCcp exs = new ExpenseTransportCcp();
                exs.DoNumber = data.DoNumber;
                exs.ActualGidateSap = enteredDate;
                exs.SoldTo = data.SoldTo;
                exs.SoldToName = data.SoldToName;
                exs.EtshipTo = data.ShipTo;
                exs.EtshipToName = data.EtshipToName;
                exs.Transport = data.Transport;
                exs.ShippingType = data.CarType;
                exs.ShippingName = data.Text;
                exs.EttransportZone = data.TransportZone;
                exs.EttransportZoneName = data.ShipToTransportName;
                exs.Etmptprice = data.Stzprice;
                exs.Etcfprice = data.Cfprice;
                exs.Etamount = data.TotalPrice;
                exs.Etfactory = data.Factory;
                exs.Etstatus = "Active";
                exs.EteditBy = User.Identity.Name;
                exs.EteditDate = DateTime.Now;

                _db.Add(exs);
                await _db.SaveChangesAsync();

                ExpenseTransportCcplog el = new ExpenseTransportCcplog();
                el.DoNumber = data.DoNumber;
                el.ActualGidateSap = enteredDate;
                el.SoldTo = data.SoldTo;
                el.SoldToName = data.SoldToName;
                el.LshipTo = data.ShipTo;
                el.LshipToName = data.EtshipToName;
                el.Transport = data.Transport;
                el.ShippingType = data.CarType;
                el.ShippingName = data.Text;
                el.LtransportZone = data.TransportZone;
                el.LtransportZoneName = data.ShipToTransportName;
                el.Lmptprice = data.Stzprice;
                el.Lcfprice = data.Cfprice;
                el.Lamount = data.TotalPrice;
                el.Lfactory = data.Factory;
                el.Lstatus = "Active";
                el.LeditBy = User.Identity.Name;
                el.LeditDate = DateTime.Now;

                _db.Add(el);
                await _db.SaveChangesAsync();
            }

            // await _db.SaveChangesAsync();

            _notyfService.Success("บันทึกรายการสำเร็จ");
            return RedirectToAction("Index", "ReportExpensiveTransport");

        }
        else
        {
            _notyfService.Error("บันทึกรายการผิดพลาด มีข้อมูลที่ไม่สมบูรณ์ กรุณาลองใหม่");
            return RedirectToAction(nameof(InsertDO));
        }

        return View(data);
    }

    public IActionResult SearchShipTo(string shipToZone, string txtDoNumber, string txtclient)
    {


        if (!String.IsNullOrEmpty(shipToZone))
        {
            @TempData["txtNameShipTo"] = shipToZone;
            @TempData["txtDo"] = txtDoNumber;
            @TempData["txtClient"] = txtclient;
            return RedirectToAction("InsertDO");
        }
        else
        {
            @TempData["txtDo"] = txtDoNumber;
            @TempData["txtClient"] = txtclient;

            _notyfService.Error("กรุณากรอกชื่อ TransportZone");
            return RedirectToAction("InsertDO");
        }
        return View();

    }

    public async Task<IActionResult> SelectShipTo(string ShipToZone, string ShipToZoneID, string donumber, string client)
    {
        string[] _Client = new string[2];
        _Client[0] = "CCP";
        _Client[1] = "CPS";

        ViewData["ClientList"] = new SelectList(_Client, client);

        ViewBag.Client = client;

        @TempData["txtShipTo"] = ShipToZone;

        CreateExpensiveTransportViewModel cetViewModel = new CreateExpensiveTransportViewModel();
        // List<APIGETSoldTo> getSoldTo = new List<APIGETSoldTo>();
        List<APIDeliveryAll> getDeliveryAll = new List<APIDeliveryAll>();

        if (@TempData["txtNameShipTo"] != null)
        {
            {
                string transportZone = @TempData["txtNameShipTo"].ToString();
                var data = await NetworkService.GetDeliveryAlls();
                var resultDeliveryAll = data.Where(c => c.ShipToZone.Contains(transportZone));

                foreach (var item in resultDeliveryAll)
                {
                    getDeliveryAll.Add(new APIDeliveryAll()
                    {
                        ShipToZone = item.ShipToZone,
                        ShipToZoneID = item.ShipToZoneID
                    });
                }

                if (getDeliveryAll.Count != 0)
                {
                    @TempData["txtNameShipTo"] = null;
                    cetViewModel.dataDeliveryAll = getDeliveryAll;
                    string DoNum = @TempData["txtDO"].ToString();
                    string ClientNum = @TempData["txtClient"].ToString();
                    @TempData["DoNumber"] = DoNum;
                    @TempData["ClientNumber"] = ClientNum;
                    return View(cetViewModel);
                }
                else
                {
                    @TempData["txtNameShipTo"] = null;
                    donumber = @TempData["txtDO"].ToString();
                    client = @TempData["txtClient"].ToString();

                    _notyfService.Error("กรุณากรอกข้อมูลให้ถูกต้อง");
                }

            }

        }
        else if (@TempData["txtDO"] != null && @TempData["txtClient"] != null)
        {
            donumber = @TempData["txtDO"].ToString();
            client = @TempData["txtClient"].ToString();
        }

        double tpPrice = 0;
        double otherPrice = 0;

        if (client == "CCP")
        {
            if (!String.IsNullOrEmpty(donumber))
            {
                var doNum = await NetworkService.GetDO(donumber);

                if (doNum.isSuccess == true)
                {
                    try
                    {
                        cetViewModel.DoNumber = doNum.data.Delivery;
                        cetViewModel.ActualGidateSap = doNum.data.Createdon;
                        cetViewModel.SoldTo = doNum.data.Soldtoparty;
                        cetViewModel.SoldToName = doNum.data.SoldToName;
                        cetViewModel.ShipTo = doNum.data.Shiptoparty;
                        cetViewModel.EtshipToName = doNum.data.ShipToName;
                        cetViewModel.CarType = doNum.data.ShippingType;
                        cetViewModel.Text = doNum.data.ShippingTypeName;
                        cetViewModel.TransportZone = ShipToZoneID;
                        cetViewModel.ShipToTransportName = ShipToZone;
                        cetViewModel.dataDeliveryAll = getDeliveryAll;
                        cetViewModel.Factory = client;

                        var trans = await (from tran in _db.ItemCcps
                                           where tran.Status == "Active"
                                            && tran.DoNumber == doNum.data.Delivery
                                           select tran).FirstOrDefaultAsync();
                        if (trans == null)
                        {
                            cetViewModel.Transport = "";
                        }
                        else
                        {
                            cetViewModel.Transport = trans.Transport;
                        }

                        var cons = await (from con in _db.ConfigExpenseTransportCcps
                                          select con).FirstOrDefaultAsync();
                        cetViewModel.Cfprice = cons.Cfprice;
                        otherPrice = cons.Cfprice;

                        var tranAPI = await NetworkService.GetCustomerDetail(doNum.data.Soldtoparty);

                        var stz = await (from st in _db.SpecailTransportZoneCcps
                                         where st.StztransportZoneId == ShipToZoneID
                                         select st).FirstOrDefaultAsync();
                        if (stz != null)
                        {
                            if (stz.Stzprice == 0)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }
                            else
                            {
                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }

                        }
                        else
                        {
                            var mpt = await (from mp in _db.MasterPriceByTransportZones
                                             where mp.MpttransportZoneId == ShipToZoneID
                                             select mp).FirstOrDefaultAsync();
                            if (mpt == null)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                mpt.Mptprice = 0;
                                cetViewModel.Stzprice = mpt.Mptprice;
                                tpPrice = mpt.Mptprice;

                            }
                            else
                            {
                                if (mpt.Mptprice == 0)
                                {
                                    cetViewModel.Cfprice = 0;
                                    otherPrice = 0;

                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }
                                else
                                {
                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }

                            }

                        }
                        cetViewModel.TransportZone = ShipToZoneID;

                        @TempData["txtShipTo"] = cetViewModel.ShipTo;

                        cetViewModel.TotalPrice = tpPrice + otherPrice;

                        if (cetViewModel == null)
                        {
                            _notyfService.Error("ไม่พบข้อมูล DO");
                            return RedirectToAction(nameof(Index));
                        }
                        @TempData["txtDO"] = donumber;
                        @TempData["txtClient"] = client;
                        return View(cetViewModel);
                    }
                    catch (Exception ex)
                    {
                        _notyfService.Error(ex.Message);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    _notyfService.Error("No Data");
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                _notyfService.Error("กรุณากรอกข้อมูลเลขDO");
                return RedirectToAction(nameof(Index));
            }
        }
        else if (client == "CPS")
        {
            if (!String.IsNullOrEmpty(donumber))
            {
                var doNum = await NetworkService.GetDOCPS(donumber);

                if (doNum.isSuccess == true)
                {
                    try
                    {
                        cetViewModel.DoNumber = doNum.data.Delivery;
                        cetViewModel.ActualGidateSap = doNum.data.Createdon;
                        cetViewModel.SoldTo = doNum.data.Soldtoparty;
                        cetViewModel.SoldToName = doNum.data.SoldToName;
                        cetViewModel.ShipTo = doNum.data.Shiptoparty;
                        cetViewModel.EtshipToName = doNum.data.ShipToName;
                        cetViewModel.CarType = doNum.data.ShippingType;
                        cetViewModel.Text = doNum.data.ShippingTypeName;
                        cetViewModel.TransportZone = ShipToZoneID;
                        cetViewModel.ShipToTransportName = ShipToZone;
                        cetViewModel.dataDeliveryAll = getDeliveryAll;
                        cetViewModel.Factory = client;

                        var trans = await (from tran in _db.ItemCcps
                                           where tran.Status == "Active"
                                            && tran.DoNumber == doNum.data.Delivery
                                           select tran).FirstOrDefaultAsync();
                        if (trans == null)
                        {
                            cetViewModel.Transport = "";
                        }
                        else
                        {
                            cetViewModel.Transport = trans.Transport;
                        }

                        var cons = await (from con in _db.ConfigExpenseTransportCcps
                                          select con).FirstOrDefaultAsync();
                        cetViewModel.Cfprice = cons.Cfprice;
                        otherPrice = cons.Cfprice;

                        var tranAPI = await NetworkService.GetCustomerDetail(doNum.data.Soldtoparty);

                        var stz = await (from st in _db.SpecailTransportZoneCcps
                                         where st.StztransportZoneId == ShipToZoneID
                                         select st).FirstOrDefaultAsync();
                        if (stz != null)
                        {
                            if (stz.Stzprice == 0)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }
                            else
                            {
                                cetViewModel.ShipToTransportName = stz.StztransportZoneName;
                                cetViewModel.Stzprice = stz.Stzprice;
                                tpPrice = stz.Stzprice;
                            }

                        }
                        else
                        {
                            var mpt = await (from mp in _db.MasterPriceByTransportZones
                                             where mp.MpttransportZoneId == ShipToZoneID
                                             select mp).FirstOrDefaultAsync();
                            if (mpt == null)
                            {
                                cetViewModel.Cfprice = 0;
                                otherPrice = 0;

                                mpt.Mptprice = 0;
                                cetViewModel.Stzprice = mpt.Mptprice;
                                tpPrice = mpt.Mptprice;

                            }
                            else
                            {
                                if (mpt.Mptprice == 0)
                                {
                                    cetViewModel.Cfprice = 0;
                                    otherPrice = 0;

                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }
                                else
                                {
                                    cetViewModel.ShipToTransportName = mpt.MpttransportZoneName;
                                    cetViewModel.Stzprice = mpt.Mptprice;
                                    tpPrice = mpt.Mptprice;
                                }

                            }

                        }
                        cetViewModel.TransportZone = ShipToZoneID;

                        @TempData["txtShipTo"] = cetViewModel.ShipTo;

                        cetViewModel.TotalPrice = tpPrice + otherPrice;

                        if (cetViewModel == null)
                        {
                            _notyfService.Error("ไม่พบข้อมูล DO");
                            return RedirectToAction(nameof(Index));
                        }
                        @TempData["txtDO"] = donumber;
                        @TempData["txtClient"] = client;
                        return View(cetViewModel);
                    }
                    catch (Exception ex)
                    {
                        _notyfService.Error(ex.Message);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    _notyfService.Error("No Data");
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                _notyfService.Error("กรุณากรอกข้อมูลเลขDO");
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            _notyfService.Error("กรุณาเลือก Client");
            return RedirectToAction(nameof(Index));
        }


        return View();
    }

}
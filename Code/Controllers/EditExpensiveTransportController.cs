using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models.db;
using TransportManagement.Services;
using TransportManagement.ViewModels;

namespace TransportManagement.Controllers;
[Authorize]

public class EditExpensiveTransportController : BaseController
{
    private readonly INotyfService _notyfService;
    TransportCCPCPSContext _db;
    public EditExpensiveTransportController(INotyfService notyfService, TransportCCPCPSContext db)
    {
        _db = db;
        _notyfService = notyfService;
    }

    public async Task<IActionResult> Index()
    {

        return View();
    }
    public async Task<IActionResult> EditExpensiveTransport(int EtautoId, int txtEtautoId)
    {
        double tpPrice = 0;
        double otherPrice = 0;

        ExpensiveTransportViewModel exViewModel = new ExpensiveTransportViewModel();
        // List<APIGETSoldTo> getSoldTo = new List<APIGETSoldTo>();

        List<APIDeliveryAll> getDeliveryAll = new List<APIDeliveryAll>();
        
        if (@TempData["txtNameShipTo"] != null)
        {
            {
                string transportZone1 = @TempData["txtNameShipTo"].ToString();
                var data = await NetworkService.GetDeliveryAlls();
                var resultDeliveryAll = data.Where(c => c.ShipToZone.Contains(transportZone1));

                foreach(var item in resultDeliveryAll)
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
                    exViewModel.dataDeliveryAll = getDeliveryAll;
                    string DoNum = @TempData["txtDO"].ToString();
                    @TempData["EtautoId"] = DoNum;
                    return View(exViewModel);
                }
                else
                {
                    @TempData["txtNameShipTo"] = null;
                    int.TryParse(@TempData["txtDo"].ToString(), out EtautoId);

                    _notyfService.Error("กรุณากรอกข้อมูลให้ถูกต้อง");
                }

            }

        }
        else if (@TempData["txtDo"] != null)
        {
            int.TryParse(@TempData["txtDo"].ToString(), out EtautoId);
        }

        var eds = await (from ed in _db.ExpenseTransportCcps
                         where ed.EtautoId == EtautoId
                         select ed).FirstOrDefaultAsync();

        int etautoId = eds.EtautoId;
        string donumber = eds.DoNumber;
        string actualGidateSap = eds.ActualGidateSap.ToString("yyyy/MM/dd");
        string soldTo = eds.SoldTo;
        string soldToName = eds.SoldToName;
        string shipTo = eds.EtshipTo;
        string shipToName = eds.EtshipToName;
        string transport = eds.Transport;
        string shippingType = eds.ShippingType;
        string shippingName = eds.ShippingName;
        string transportZone = eds.EttransportZone;
        string transportZoneName = eds.EttransportZoneName;
        double mptPrice = (double)eds.Etmptprice;
        double cfPrice = (double)eds.Etcfprice;
        double amount = (double)eds.Etamount;
        string factory = eds.Etfactory;

        exViewModel.EtautoId = etautoId;
        exViewModel.DoNumber = donumber;
        exViewModel.ActualGidateSap = actualGidateSap;
        exViewModel.SoldTo = soldTo;
        exViewModel.SoldToName = soldToName;
        exViewModel.EtshipTo = shipTo;
        exViewModel.EtshipToName = shipToName;
        exViewModel.Transport = transport;
        exViewModel.ShippingType = shippingType;
        exViewModel.ShippingName = shippingName;
        exViewModel.EttransportZone = transportZone;
        exViewModel.EttransportZoneName = transportZoneName;
        exViewModel.Etmptprice = mptPrice;
        exViewModel.Etcfprice = cfPrice;
        exViewModel.Etamount = amount;
        exViewModel.Factory = factory;
        exViewModel.dataDeliveryAll = getDeliveryAll;


        var edls = await (from edl in _db.ExpenseTransportCcplogs
                          select edl).FirstOrDefaultAsync();

        @TempData["txtShipTo"] = exViewModel.EtshipTo;

        if (exViewModel == null)
        {
            _notyfService.Error("ไม่พบข้อมูล DO");
            return RedirectToAction(nameof(Index));
        }

        @TempData["txtDO"] = exViewModel.EtautoId.ToString();

        return View(exViewModel);
    }

    public IActionResult SearchShipTo(string shipToZone, int txtEtautoId)
    {
        if (!String.IsNullOrEmpty(shipToZone))
        {
            @TempData["txtNameShipTo"] = shipToZone;
            @TempData["txtDo"] = txtEtautoId;

            return RedirectToAction("EditExpensiveTransport");
        }
        else
        {
            @TempData["txtDo"] = txtEtautoId;

            _notyfService.Error("กรุณากรอกชื่อ TransportZone");
            return RedirectToAction("EditExpensiveTransport");
        }
        return View();

    }

    public async Task<IActionResult> EditExpensiveTransport1(string ShipToZone, string ShipToZoneID, int etautoId)
    {
        @TempData["txtShipTo"] = ShipToZone;

        ExpensiveTransportViewModel exViewModel = new ExpensiveTransportViewModel();
        
        List<APIDeliveryAll> getDeliveryAll = new List<APIDeliveryAll>();

        if (@TempData["txtNameShipTo"] != null)
        {
            {
                string transportZone1 = @TempData["txtNameShipTo"].ToString();
                var data = await NetworkService.GetDeliveryAlls();
                var resultDeliveryAll = data.Where(c => c.ShipToZone.Contains(transportZone1));

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
                    exViewModel.dataDeliveryAll = getDeliveryAll;
                    string DoNum = @TempData["txtDO"].ToString();
                    @TempData["EtautoId"] = DoNum;
                    return View(exViewModel);
                }
                else
                {
                    @TempData["txtNameShipTo"] = null;
                    int.TryParse(@TempData["txtDo"].ToString(), out etautoId);

                    _notyfService.Error("กรุณากรอกข้อมูลให้ถูกต้อง");
                }
            }

        }
        else if (@TempData["txtDo"] != null)
        {
            int.TryParse(@TempData["txtDo"].ToString(), out etautoId);
        }

        double tpPrice = 0;
        double otherPrice = 0;

        var eds = await (from ed in _db.ExpenseTransportCcps
                         where ed.EtautoId == etautoId
                         select ed).FirstOrDefaultAsync();

        int _etautoId = eds.EtautoId;
        string donumber = eds.DoNumber;
        string actualGidateSap = eds.ActualGidateSap.ToString("yyyy/MM/dd");
        string soldTo = eds.SoldTo;
        string soldToName = eds.SoldToName;
        string shipTo = eds.EtshipTo;
        string shipToName = eds.EtshipToName;
        string transport = eds.Transport;
        string shippingType = eds.ShippingType;
        string shippingName = eds.ShippingName;
        string transportZone = eds.EttransportZone;
        string transportZoneName = eds.EttransportZoneName;
        double mptPrice = (double)eds.Etmptprice;
        double cfPrice = (double)eds.Etcfprice;
        double amount = (double)eds.Etamount;
        string factory = eds.Etfactory;

        exViewModel.EtautoId = _etautoId;
        exViewModel.DoNumber = donumber;
        exViewModel.ActualGidateSap = actualGidateSap;
        exViewModel.SoldTo = soldTo;
        exViewModel.SoldToName = soldToName;
        exViewModel.EtshipTo = shipTo;
        exViewModel.EtshipToName = shipToName;
        exViewModel.Transport = transport;
        exViewModel.ShippingType = shippingType;
        exViewModel.ShippingName = shippingName;
        exViewModel.EttransportZone = ShipToZoneID;
        exViewModel.EttransportZoneName = ShipToZone;
        exViewModel.Etmptprice = mptPrice;
        exViewModel.Etcfprice = cfPrice;
        exViewModel.Etamount = amount;
        exViewModel.Factory = factory;
        exViewModel.dataDeliveryAll = getDeliveryAll;

        var edls = await (from edl in _db.ExpenseTransportCcplogs
                          select edl).FirstOrDefaultAsync();

        var cons = await (from con in _db.ConfigExpenseTransportCcps
                          select con).FirstOrDefaultAsync();
        exViewModel.Etcfprice = cons.Cfprice;
        otherPrice = cons.Cfprice;

        var tranAPI = await NetworkService.GetCustomerDetail(shipTo);

        var stz = await (from st in _db.SpecailTransportZoneCcps
                         where st.StztransportZoneId == ShipToZoneID
                         select st).FirstOrDefaultAsync();
        if (stz != null)
        {
            if (stz.Stzprice == 0)
            {
                exViewModel.Etcfprice = 0;
                otherPrice = 0;

                exViewModel.EttransportZoneName = stz.StztransportZoneName;
                exViewModel.Etmptprice = stz.Stzprice;
                tpPrice = stz.Stzprice;
            }
            else
            {
                exViewModel.EttransportZoneName = stz.StztransportZoneName;
                exViewModel.Etmptprice = stz.Stzprice;
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
                            exViewModel.Etcfprice = 0;
                            otherPrice = 0;
                          
                            mpt.Mptprice = 0;
                            exViewModel.Etmptprice = mpt.Mptprice;
                            tpPrice = mpt.Mptprice;

                        }
                        else
                        {
                            if (mpt.Mptprice == 0)
                            {
                                exViewModel.Etcfprice = 0;
                                otherPrice = 0;

                                exViewModel.EttransportZoneName = mpt.MpttransportZoneName;
                                exViewModel.Etmptprice = mpt.Mptprice;
                                tpPrice = mpt.Mptprice;
                            }
                            else
                            {
                                exViewModel.EttransportZoneName = mpt.MpttransportZoneName;
                                exViewModel.Etmptprice = mpt.Mptprice;
                                tpPrice = mpt.Mptprice;
                            }

                        }

        }

        exViewModel.EttransportZone = ShipToZoneID;
        

        if (eds == null && edls == null)
        {
            _notyfService.Error("ไม่สามารถแก้ไขได้ กรุณาลองใหม่อีกครั้ง");
        }

        @TempData["txtShipTo"] = exViewModel.EtshipTo;

        exViewModel.Etamount = tpPrice + otherPrice;

        if (exViewModel == null)
        {
            _notyfService.Error("ไม่พบข้อมูล DO");
            return RedirectToAction(nameof(Index));
        }

        @TempData["txtDO"] = exViewModel.EtautoId;

        return View(exViewModel);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditExpensiveTransport(ExpensiveTransportViewModel data)
    {

        if (data != null)
        {
            try
            {
                var us = await (from u in _db.ExpenseTransportCcps
                                where u.DoNumber == data.DoNumber
                                && u.Etfactory == data.Factory
                                && u.Etstatus == "Active"
                                select u).FirstOrDefaultAsync();

                DateTime date; DateTime.TryParse(data.ActualGidateSap, out date);
                us.DoNumber = data.DoNumber;
                us.ActualGidateSap = date;
                us.SoldTo = data.SoldTo;
                us.SoldToName = data.SoldToName;
                us.EtshipTo = data.EtshipTo;
                us.EtshipToName = data.EtshipToName;
                us.Transport = data.Transport;
                us.ShippingType = data.ShippingType;
                us.ShippingName = data.ShippingName;
                us.EttransportZone = data.EttransportZone;
                us.EttransportZoneName = data.EttransportZoneName;
                us.Etmptprice = data.Etmptprice;               
                us.Etcfprice = data.Etcfprice;
                us.Etamount = data.Etamount;
                us.EteditDate = DateTime.Now;
                us.Etfactory = data.Factory;

                _db.Update(us);
                await _db.SaveChangesAsync();

                ExpenseTransportCcplog el = new ExpenseTransportCcplog();
                el.DoNumber = data.DoNumber;
                el.ActualGidateSap = date;
                el.SoldTo = data.SoldTo;
                el.SoldToName = data.SoldToName;
                el.LshipTo = data.EtshipTo;
                el.LshipToName = data.EtshipToName;
                el.Transport = data.Transport;
                el.ShippingType = data.ShippingType;
                el.ShippingName = data.ShippingName;
                el.LtransportZone = data.EttransportZone;
                el.LtransportZoneName = data.EttransportZoneName;
                el.Lmptprice = data.Etmptprice;
                el.Lcfprice = data.Etcfprice;
                el.Lamount = data.Etamount;
                el.Lstatus = "Active";
                el.LeditBy = User.Identity.Name;
                el.LeditDate = DateTime.Now;
                el.Lfactory = data.Factory;

                _db.Add(el);
                await _db.SaveChangesAsync();

                _notyfService.Success("แก้ไขรายการสำเร็จ");
                return RedirectToAction("Index", "ReportExpensiveTransport");
            }
            catch (DbUpdateConcurrencyException)
            {
                bool result = _db.ExpenseTransportCcps.Any(u => u.DoNumber == data.DoNumber);
                if (result == false)
                {
                    _notyfService.Error("การแก้ไขผิดพลาด กรุณาลองใหม่อีกครั้ง");
                }
            }
            return RedirectToAction(nameof(EditExpensiveTransport));
        }
        return View(data);
    }

}
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

public class ListExpensiveTransportController : BaseController
{
    private readonly INotyfService _notyfService;
    TransportCCPCPSContext _db;
    public ListExpensiveTransportController(INotyfService notyfService, TransportCCPCPSContext db)
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

        if (client == "CCP")
        {
            if (tuckType == null)
            {
                var reports = await (from report in _db.ExpenseTransportCcps
                                     where report.Etstatus == "Active"
                                     && report.EteditDate >= sDate
                                     && report.EteditDate <= eDate
                                     select new ExpensiveTransportViewModel
                                     {
                                         EtautoId = report.EtautoId,
                                         ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                         //  ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                         DoNumber = report.DoNumber,
                                         SoldTo = report.SoldTo,
                                         SoldToName = report.SoldToName,
                                         EtshipTo = report.EtshipTo,
                                         EtshipToName = report.EtshipToName,
                                         Transport = report.Transport,
                                         ShippingType = report.ShippingType,
                                         ShippingName = report.ShippingName,
                                         Etmptprice = report.Etmptprice,
                                         Etcfprice = report.Etcfprice,
                                         Etamount = report.Etamount,
                                         Factory = report.Etfactory,
                                         CheckBotton = "true"

                                     }).OrderBy(s => s.DoNumber).ToArrayAsync();

                foreach (var item in reports)
                {
                    etViewmodel.Add(new ExpensiveTransportViewModel()
                    {
                        ActualGidateSap = item.ActualGidateSap.ToString(),
                        No_Id = i++,
                        EtautoId = item.EtautoId,
                        DoNumber = item.DoNumber,
                        SoldTo = item.SoldTo,
                        SoldToName = item.SoldToName,
                        EtshipTo = item.EtshipTo,
                        EtshipToName = item.EtshipToName,
                        Transport = item.Transport,
                        ShippingType = item.ShippingType,
                        ShippingName = item.ShippingName,
                        Etmptprice = item.Etmptprice,
                        Etcfprice = item.Etcfprice,
                        Etamount = item.Etamount,
                        Factory = item.Factory,
                        CheckBotton = "true"
                    });
                }
                ViewBag.ExpensiveTransportViewModel = etViewmodel;
            }
            else
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CCP"
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
                else
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CCP"
                                          && report.ShippingType == tuckType
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
            }

        }
        else if (client == "CPS")
        {
            if (tuckType == null)
            {
                var reports = await (from report in _db.ExpenseTransportCcps
                                     where report.Etstatus == "Active"
                                     && report.EteditDate >= sDate
                                     && report.EteditDate <= eDate
                                     select new ExpensiveTransportViewModel
                                     {
                                         EtautoId = report.EtautoId,
                                         ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                         //  ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                         DoNumber = report.DoNumber,
                                         SoldTo = report.SoldTo,
                                         SoldToName = report.SoldToName,
                                         EtshipTo = report.EtshipTo,
                                         EtshipToName = report.EtshipToName,
                                         Transport = report.Transport,
                                         ShippingType = report.ShippingType,
                                         ShippingName = report.ShippingName,
                                         Etmptprice = report.Etmptprice,
                                         Etcfprice = report.Etcfprice,
                                         Etamount = report.Etamount,
                                         Factory = report.Etfactory,
                                         CheckBotton = "true"

                                     }).OrderBy(s => s.DoNumber).ToArrayAsync();

                foreach (var item in reports)
                {
                    etViewmodel.Add(new ExpensiveTransportViewModel()
                    {
                        ActualGidateSap = item.ActualGidateSap.ToString(),
                        No_Id = i++,
                        EtautoId = item.EtautoId,
                        DoNumber = item.DoNumber,
                        SoldTo = item.SoldTo,
                        SoldToName = item.SoldToName,
                        EtshipTo = item.EtshipTo,
                        EtshipToName = item.EtshipToName,
                        Transport = item.Transport,
                        ShippingType = item.ShippingType,
                        ShippingName = item.ShippingName,
                        Etmptprice = item.Etmptprice,
                        Etcfprice = item.Etcfprice,
                        Etamount = item.Etamount,
                        Factory = item.Factory,
                        CheckBotton = "true"
                    });
                }
                ViewBag.ExpensiveTransportViewModel = etViewmodel;
            }
            else
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CPS"
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
                else
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CPS"
                                          && report.ShippingType == tuckType
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
            }
        }
        else if (client == "ALL" || client == null)
        {
            if (tuckType == null)
            {
                var reports = await (from report in _db.ExpenseTransportCcps
                                     where report.Etstatus == "Active"
                                     && report.EteditDate >= sDate
                                     && report.EteditDate <= eDate
                                     select new ExpensiveTransportViewModel
                                     {
                                         EtautoId = report.EtautoId,
                                         ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                         //  ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                         DoNumber = report.DoNumber,
                                         SoldTo = report.SoldTo,
                                         SoldToName = report.SoldToName,
                                         EtshipTo = report.EtshipTo,
                                         EtshipToName = report.EtshipToName,
                                         Transport = report.Transport,
                                         ShippingType = report.ShippingType,
                                         ShippingName = report.ShippingName,
                                         Etmptprice = report.Etmptprice,
                                         Etcfprice = report.Etcfprice,
                                         Etamount = report.Etamount,
                                         Factory = report.Etfactory,
                                         CheckBotton = "true"

                                     }).OrderBy(s => s.DoNumber).ToArrayAsync();

                foreach (var item in reports)
                {
                    etViewmodel.Add(new ExpensiveTransportViewModel()
                    {
                        ActualGidateSap = item.ActualGidateSap.ToString(),
                        No_Id = i++,
                        EtautoId = item.EtautoId,
                        DoNumber = item.DoNumber,
                        SoldTo = item.SoldTo,
                        SoldToName = item.SoldToName,
                        EtshipTo = item.EtshipTo,
                        EtshipToName = item.EtshipToName,
                        Transport = item.Transport,
                        ShippingType = item.ShippingType,
                        ShippingName = item.ShippingName,
                        Etmptprice = item.Etmptprice,
                        Etcfprice = item.Etcfprice,
                        Etamount = item.Etamount,
                        Factory = item.Factory,
                        CheckBotton = "true"
                    });
                }
                ViewBag.ExpensiveTransportViewModel = etViewmodel;
            }
            else
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
                else
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps

                                          where report.Etstatus == "Active"
                                          && report.ShippingType == tuckType
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
            }

        }

        string[] _Client = new string[3];
        _Client[0] = "ALL";
        _Client[1] = "CCP";
        _Client[2] = "CPS";
        ViewData["ClientList"] = new SelectList(_Client, client);

        ViewData["ShippingList"] = new SelectList
        (dataT.data.Where(i => i.LanguageKey == "E"), "Shippingtype", "ShippingName", tuckType);

        ViewBag.StartDate = sDate.ToString("yyyy-MM-dd");
        ViewBag.EndDate = eDate.ToString("yyyy-MM-dd");
        ViewBag.TuckType = tuckType;

        ViewBag.Client = client;

        return View();
    }

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

    public async Task<IActionResult> PrintPreview(string tuckType, DateTime startDate, DateTime endDate, string client)
    {
        int i = 1;

        var sDate = DateTime.Parse(DateTime.Now.ToString());
        var eDate = DateTime.Parse(DateTime.Now.ToString());

        List<ExpensiveTransportViewModel> etViewmodel = new List<ExpensiveTransportViewModel>();
        TransportViewModel tranViewModel = new TransportViewModel();

        var dataT = await NetworkService.GETAllShippingType();


        if (client == "CCP")
        {
            if (tuckType == null)
            {
                var reports = await (from report in _db.ExpenseTransportCcps
                                     where report.Etstatus == "Active"
                                     && report.EteditDate >= sDate
                                     && report.EteditDate <= eDate
                                     select new ExpensiveTransportViewModel
                                     {
                                         EtautoId = report.EtautoId,
                                         ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                         //  ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                         DoNumber = report.DoNumber,
                                         SoldTo = report.SoldTo,
                                         SoldToName = report.SoldToName,
                                         EtshipTo = report.EtshipTo,
                                         EtshipToName = report.EtshipToName,
                                         Transport = report.Transport,
                                         ShippingType = report.ShippingType,
                                         ShippingName = report.ShippingName,
                                         Etmptprice = report.Etmptprice,
                                         Etcfprice = report.Etcfprice,
                                         Etamount = report.Etamount,
                                         Factory = report.Etfactory,
                                         CheckBotton = "true"

                                     }).OrderBy(s => s.DoNumber).ToArrayAsync();

                foreach (var item in reports)
                {
                    etViewmodel.Add(new ExpensiveTransportViewModel()
                    {
                        ActualGidateSap = item.ActualGidateSap.ToString(),
                        No_Id = i++,
                        EtautoId = item.EtautoId,
                        DoNumber = item.DoNumber,
                        SoldTo = item.SoldTo,
                        SoldToName = item.SoldToName,
                        EtshipTo = item.EtshipTo,
                        EtshipToName = item.EtshipToName,
                        Transport = item.Transport,
                        ShippingType = item.ShippingType,
                        ShippingName = item.ShippingName,
                        Etmptprice = item.Etmptprice,
                        Etcfprice = item.Etcfprice,
                        Etamount = item.Etamount,
                        Factory = item.Factory,
                        CheckBotton = "true"
                    });
                }
                ViewBag.ExpensiveTransportViewModel = etViewmodel;
            }
            else
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CCP"
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
                else
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CCP"
                                          && report.ShippingType == tuckType
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
            }

        }
        else if (client == "CPS")
        {
            if (tuckType == null)
            {
                var reports = await (from report in _db.ExpenseTransportCcps
                                     where report.Etstatus == "Active"
                                     && report.EteditDate >= sDate
                                     && report.EteditDate <= eDate
                                     select new ExpensiveTransportViewModel
                                     {
                                         EtautoId = report.EtautoId,
                                         ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                         //  ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                         DoNumber = report.DoNumber,
                                         SoldTo = report.SoldTo,
                                         SoldToName = report.SoldToName,
                                         EtshipTo = report.EtshipTo,
                                         EtshipToName = report.EtshipToName,
                                         Transport = report.Transport,
                                         ShippingType = report.ShippingType,
                                         ShippingName = report.ShippingName,
                                         Etmptprice = report.Etmptprice,
                                         Etcfprice = report.Etcfprice,
                                         Etamount = report.Etamount,
                                         Factory = report.Etfactory,
                                         CheckBotton = "true"

                                     }).OrderBy(s => s.DoNumber).ToArrayAsync();

                foreach (var item in reports)
                {
                    etViewmodel.Add(new ExpensiveTransportViewModel()
                    {
                        ActualGidateSap = item.ActualGidateSap.ToString(),
                        No_Id = i++,
                        EtautoId = item.EtautoId,
                        DoNumber = item.DoNumber,
                        SoldTo = item.SoldTo,
                        SoldToName = item.SoldToName,
                        EtshipTo = item.EtshipTo,
                        EtshipToName = item.EtshipToName,
                        Transport = item.Transport,
                        ShippingType = item.ShippingType,
                        ShippingName = item.ShippingName,
                        Etmptprice = item.Etmptprice,
                        Etcfprice = item.Etcfprice,
                        Etamount = item.Etamount,
                        Factory = item.Factory,
                        CheckBotton = "true"
                    });
                }
                ViewBag.ExpensiveTransportViewModel = etViewmodel;
            }
            else
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CPS"
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
                else
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.Etfactory == "CPS"
                                          && report.ShippingType == tuckType
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
            }
        }
        else if (client == "ALL" || client == null)
        {
            if (tuckType == null)
            {
                var reports = await (from report in _db.ExpenseTransportCcps
                                     where report.Etstatus == "Active"
                                     && report.EteditDate >= sDate
                                     && report.EteditDate <= eDate
                                     select new ExpensiveTransportViewModel
                                     {
                                         EtautoId = report.EtautoId,
                                         ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                         //  ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                         DoNumber = report.DoNumber,
                                         SoldTo = report.SoldTo,
                                         SoldToName = report.SoldToName,
                                         EtshipTo = report.EtshipTo,
                                         EtshipToName = report.EtshipToName,
                                         Transport = report.Transport,
                                         ShippingType = report.ShippingType,
                                         ShippingName = report.ShippingName,
                                         Etmptprice = report.Etmptprice,
                                         Etcfprice = report.Etcfprice,
                                         Etamount = report.Etamount,
                                         Factory = report.Etfactory,
                                         CheckBotton = "true"

                                     }).OrderBy(s => s.DoNumber).ToArrayAsync();

                foreach (var item in reports)
                {
                    etViewmodel.Add(new ExpensiveTransportViewModel()
                    {
                        ActualGidateSap = item.ActualGidateSap.ToString(),
                        No_Id = i++,
                        EtautoId = item.EtautoId,
                        DoNumber = item.DoNumber,
                        SoldTo = item.SoldTo,
                        SoldToName = item.SoldToName,
                        EtshipTo = item.EtshipTo,
                        EtshipToName = item.EtshipToName,
                        Transport = item.Transport,
                        ShippingType = item.ShippingType,
                        ShippingName = item.ShippingName,
                        Etmptprice = item.Etmptprice,
                        Etcfprice = item.Etcfprice,
                        Etamount = item.Etamount,
                        Factory = item.Factory,
                        CheckBotton = "true"
                    });
                }
                ViewBag.ExpensiveTransportViewModel = etViewmodel;
            }
            else
            {
                sDate = DateTime.Parse(startDate.ToString());
                eDate = DateTime.Parse(endDate.ToString());

                if (tuckType == "เลือกทั้งหมด")
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps
                                          where report.Etstatus == "Active"
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
                else
                {
                    var _reports = await (from report in _db.ExpenseTransportCcps

                                          where report.Etstatus == "Active"
                                          && report.ShippingType == tuckType
                                          && report.EteditDate >= sDate
                                          && report.EteditDate <= eDate
                                          select new ExpensiveTransportViewModel
                                          {
                                              EtautoId = report.EtautoId,
                                              ActualGidateSap = report.ActualGidateSap.ToString("yyyy/MM/dd"),
                                              //   ActualGidateSap = report.EteditDate.ToString("yyyy/MM/dd"),
                                              DoNumber = report.DoNumber,
                                              SoldTo = report.SoldTo,
                                              SoldToName = report.SoldToName,
                                              EtshipTo = report.EtshipTo,
                                              EtshipToName = report.EtshipToName,
                                              Transport = report.Transport,
                                              ShippingType = report.ShippingType,
                                              ShippingName = report.ShippingName,
                                              Etmptprice = report.Etmptprice,
                                              Etcfprice = report.Etcfprice,
                                              Etamount = report.Etamount,
                                              Factory = report.Etfactory,
                                              CheckBotton = "true"

                                          }).OrderBy(s => s.DoNumber).ToArrayAsync();

                    foreach (var item in _reports)
                    {
                        etViewmodel.Add(new ExpensiveTransportViewModel()
                        {
                            ActualGidateSap = item.ActualGidateSap.ToString(),
                            No_Id = i++,
                            EtautoId = item.EtautoId,
                            DoNumber = item.DoNumber,
                            SoldTo = item.SoldTo,
                            SoldToName = item.SoldToName,
                            EtshipTo = item.EtshipTo,
                            EtshipToName = item.EtshipToName,
                            Transport = item.Transport,
                            ShippingType = item.ShippingType,
                            ShippingName = item.ShippingName,
                            Etmptprice = item.Etmptprice,
                            Etcfprice = item.Etcfprice,
                            Etamount = item.Etamount,
                            Factory = item.Factory,
                            CheckBotton = "true"
                        });
                    }
                    ViewBag.ExpensiveTransportViewModel = etViewmodel;
                }
            }

        }

        ViewData["ShippingList"] = new SelectList
        (dataT.data.Where(i => i.LanguageKey == "E"), "Shippingtype", "ShippingName", tuckType);

        ViewBag.StartDate = sDate.ToString("yyyy-MM-dd");
        ViewBag.EndDate = eDate.ToString("yyyy-MM-dd");
        ViewBag.TuckType = tuckType;

        return View();
    }


}
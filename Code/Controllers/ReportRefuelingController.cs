using AspNetCoreHero.ToastNotification.Abstractions;
using TransportManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models.db;
using TransportManagement.Services;
using TransportManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace TransportManagement.Controllers;
[Authorize]
public class ReportRefuelingController : BaseController
{
    private readonly INotyfService _notyfService;
    ApplicationOilStationContext _db;

    public ReportRefuelingController(INotyfService notyfService, ApplicationOilStationContext db)
    {
        _db = db;
        _notyfService = notyfService;

    }

    public async Task<IActionResult> Index(string _assetId, DateTime dStart, DateTime dEnd)
    {
        string _sDate = string.Empty;
        string _eDate = string.Empty;
        if (dEnd.ToString() == "1/1/0001 12:00:00 AM")
        {
            _sDate = DateTime.Now.ToString("yyyy-MM-dd");
            _eDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
            _sDate = dStart.ToString();
            _eDate = dEnd.ToString();
        }

        var sDate = DateTime.Parse(_sDate);
        var eDate = DateTime.Parse(_eDate).AddTicks(-1).AddDays(1);

        List<ReportRefuelingViewmodel> rrViewModel = new List<ReportRefuelingViewmodel>();

        var mappingData = await NetworkService.GetMapping();

        if (_assetId == null || _assetId == "ทั้งหมด")
        {

            var fOils = await (from oil in _db.TransectionOils
                               where oil.TrStatus == "Active"
                               && oil.MstTypeId == "T1"
                               && oil.TrCreateDate >= sDate
                               && oil.TrCreateDate <= eDate
                               select new ReportRefuelingViewmodel
                               {
                                   TrDocument = oil.TrDocument,
                                   TrCreateDate = oil.TrCreateDate,
                                   TrRegistration = oil.TrRegistration,
                                   Mileage = oil.Mileage,
                                   DriverFullName = oil.DriverFullName,
                                   StationId = oil.StationId,
                                   StationName = oil.StationName,
                               }).ToArrayAsync();

            foreach (var item in fOils)
            {
                DateTime d = DateTime.Parse(item.TrCreateDate.ToString());

                rrViewModel.Add(new ReportRefuelingViewmodel()
                {
                    TrDocument = item.TrDocument,
                    timeString24Hour = d.ToString("dd/MM/yyyy HH:mm:ss"),
                    TrRegistration = item.TrRegistration,
                    Mileage = item.Mileage,
                    DriverFullName = item.DriverFullName,
                    StationId = item.StationId,
                    StationName = item.StationName,
                });
            }
            ViewBag.ReportRefuelingViewmodel = rrViewModel;

        }
        else
        {
            var typeOils = await (from oil in _db.TransectionOils
                                  where oil.TrStatus == "Active"
                                  && oil.MstTypeId == "T1"
                                  && oil.TrRegistration == _assetId
                                  && oil.TrCreateDate >= sDate
                                  && oil.TrCreateDate <= eDate
                                  select new ReportRefuelingViewmodel
                                  {
                                      TrDocument = oil.TrDocument,
                                      TrCreateDate = oil.TrCreateDate,
                                      TrRegistration = oil.TrRegistration,
                                      Mileage = oil.Mileage,
                                      DriverFullName = oil.DriverFullName,
                                      StationId = oil.StationId,
                                      StationName = oil.StationName,
                                  }).ToArrayAsync();

            foreach (var item in typeOils)
            {
                DateTime d = DateTime.Parse(item.TrCreateDate.ToString());

                rrViewModel.Add(new ReportRefuelingViewmodel()
                {
                    TrDocument = item.TrDocument,
                    timeString24Hour = d.ToString("dd/MM/yyyy HH:mm:ss"),
                    TrRegistration = item.TrRegistration,
                    Mileage = item.Mileage,
                    DriverFullName = item.DriverFullName,
                    StationId = item.StationId,
                    StationName = item.StationName,
                });
            }
            ViewBag.ReportRefuelingViewmodel = rrViewModel;
        }

        ViewData["MappingList"] = new SelectList
        (mappingData.data, "assetID", "assetID", _assetId);

        ViewBag.StartDate = sDate.ToString("yyyy-MM-dd");
        ViewBag.EndDate = eDate.ToString("yyyy-MM-dd");

        return View();
    }

    public async Task<IActionResult> ViewImages(string TrDocument)
    {
        int i = 1;

        List<ImagesViewModel> imView = new List<ImagesViewModel>();

        var imageData = await NetworkService.GetImage(TrDocument);

        if (imageData.isSuccess == true)
        {
            foreach (var item in imageData.data)
            {
                imView.Add(new ImagesViewModel()
                {
                    cImg = i++,
                    stfAutoId = item.stfAutoId,
                    stfStreamId = item.stfStreamId,
                    TrDocument = TrDocument
                });

            }

            ViewBag.ImagesViewModel = imView;

        }
        else
        {
            _notyfService.Error("No Data");
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    public async Task<IActionResult> SelectImage(int stfAutoId, string TrDocument)
    {


        List<ImagesViewModel> imView = new List<ImagesViewModel>();

        var imageData = await NetworkService.GetImage(TrDocument);

        if (imageData.isSuccess == true)
        {
            var sData = imageData.data.Where(c => c.stfAutoId == stfAutoId);

            foreach (var item in sData)
            {
                imView.Add(new ImagesViewModel()
                {
                    stfAutoId = item.stfAutoId,
                    stfStreamId = item.stfStreamId,
                    TrDocument = TrDocument
                });

            }

        }
        else
        {
            _notyfService.Error("No Data");
            return RedirectToAction(nameof(Index));
        }

        return View(imView);
    }
}

using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using TransportManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models.db;
using TransportManagement.Services;
using TransportManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using TransportManagement.Models.dbIGuard;

namespace TransportManagement.Controllers;
[Authorize]
public class MappingAsDTCController : BaseController
{
    private readonly INotyfService _notyfService;
    private readonly DataIGuardContext _db;

    public MappingAsDTCController(INotyfService notyfService, DataIGuardContext db)
    {
        _db = db;
        _notyfService = notyfService;

    }

    public async Task<IActionResult> Index()
    {
        ErrorViewModel errorViewModel = new ErrorViewModel();
        try
        {
            var iGuards = await (from iGuard in _db.MappingAssetAndDtcs
                                 where iGuard.Madstatus == "Active"
                                 select new MappingViewModel
                                 {
                                     AssetId = iGuard.AssetId,
                                     Madgpsid = iGuard.Madgpsid
                                 }).ToArrayAsync();

            ViewBag.MappingViewModel = iGuards;
        }
        catch (Exception ex)
        {
            string result = ex.Message;
            return RedirectToAction("Index", "Error", new { result = result });
        }

        return View();
    }

    public async Task<IActionResult> Create(string _assetId)
    {
        MappingViewModel mappingViewModel = new MappingViewModel();

        try
        {
            var masterID = await NetworkService.GetMasterAssetID();

            ViewData["MappingList"] = new SelectList
            (masterID.data, "assetId", "assetId");
        }
        catch (Exception ex)
        {
            var result = "DataBase ผิดพลาด " + ex.Message;
            return View(result);
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Insert(string AssetId, string _simNo)
    {
        MappingViewModel map = new MappingViewModel();

        try
        {
            if (AssetId != "กรุณาเลือก AssetID [iGraud]")
            {
                if (!String.IsNullOrEmpty(_simNo))
                {
                    var dataSim = await NetworkService.getVehicleMaster();
                    var selectSim = dataSim.data.Where(c => c.sim_no == _simNo);

                    if (selectSim.Count() != 0)
                    {
                        int i = 0;
                        foreach (var item in dataSim.data)
                        {
                            if (dataSim.data[i].sim_no == _simNo)
                            {
                                var mapdatas = await (from mapdata in _db.MappingAssetAndDtcs
                                                      where AssetId == mapdata.AssetId
                                                      && dataSim.data[i].gps_id == mapdata.Madgpsid
                                                      && mapdata.Madstatus == "Active"
                                                      select mapdata).FirstOrDefaultAsync();
                                if (mapdatas != null)
                                {
                                    // MappingAssetAndDtc m = new MappingAssetAndDtc();
                                    // mapdatas.AssetId = AssetId;
                                    // mapdatas.Madgpsid = dataSim.data[i].gps_id;
                                    // mapdatas.Madstatus = "Active";
                                    // mapdatas.MadeditBy = "Test Insert";
                                    // mapdatas.MadeditDate = DateTime.Now;

                                    _notyfService.Error("รายการนี้มีจับคู่ไว้อยู่แล้วกรุณาตรวจสอบที่หน้า MappingAssetAndDTC");
                                    return RedirectToAction(nameof(Create));
                                }
                                else
                                {
                                    MappingAssetAndDtc m = new MappingAssetAndDtc();
                                    m.AssetId = AssetId;
                                    m.Madgpsid = dataSim.data[i].gps_id;
                                    m.Madstatus = "Active";
                                    m.MadeditBy = User.Identity.Name;
                                    m.MadeditDate = DateTime.Now;

                                    _db.Add(m);
                                    await _db.SaveChangesAsync();

                                    _notyfService.Success("บันทึกรายการสำเร็จ");
                                    return RedirectToAction("Index", "MappingAsDTC");
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        _notyfService.Error("ไม่พบข้อมูลกรุณาตรวจสอบเบอร์โทรศัพท์ที่กรอก");
                        return RedirectToAction(nameof(Create));
                    }
                }
                else
                {
                    _notyfService.Error("กรุณากรอกหมายเลขโทรศัพท์");
                    return RedirectToAction(nameof(Create));
                }
            }
            else
            {
                _notyfService.Error("กรุณาเลือก AssetID [iGraud]");
                return RedirectToAction(nameof(Create));
            }
        }
        catch (Exception ex)
        {
            string result = ex.Message;
            return RedirectToAction("Index", "Error", new { result = result });
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(MappingViewModel data)
    {
        try
        {
            if (data.AssetId != null)
            {
                var del = await (from d in _db.MappingAssetAndDtcs
                                 where d.AssetId == data.AssetId
                                 && d.Madstatus == "Active"
                                 && d.Madgpsid == data.Madgpsid
                                 select d).FirstOrDefaultAsync();

                del.Madstatus = "InActive";

                _db.Update(del);
                await _db.SaveChangesAsync();

                _notyfService.Success("ทำการลบสำเร็จแล้ว");
            }

        }
        catch (Exception ex)
        {
            string result = ex.Message;
            return RedirectToAction("Index", "Error", new { result = result });
        }


        return RedirectToAction("Index", "MappingAsDTC");
    }


}

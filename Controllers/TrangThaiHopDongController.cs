using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class TrangThaiHopDongController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public TrangThaiHopDongController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstTrangThaiHopDong"] = await dbContext.TrangThaiHopDongs.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string trangthai)
  {
    var trangThaiHopDong = await dbContext.TrangThaiHopDongs.FindAsync(id);
    if (trangThaiHopDong != null)
    {
      trangThaiHopDong.TrangThai = trangthai;
      dbContext.Update(trangThaiHopDong);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string trangthai)
  {
    var trangThaiHopDong = new TrangThaiHopDong();
    trangThaiHopDong.TrangThai = trangthai;
    dbContext.Add(trangThaiHopDong);
    dbContext.SaveChanges();
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }


  [HttpPost]
  public async Task<IActionResult> Delete(int id)
  {
    var trangThaiHopDong = await dbContext.TrangThaiHopDongs.FindAsync(id);
    if (trangThaiHopDong != null)
    {
        dbContext.TrangThaiHopDongs.Remove(trangThaiHopDong);
        await dbContext.SaveChangesAsync();
    }
    else
    {
        // Handle the case where the entity was not found in the database
        ModelState.AddModelError("", "Nhân viên không tồn tại.");
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
}

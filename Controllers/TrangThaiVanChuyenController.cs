using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class TrangThaiVanChuyenController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public TrangThaiVanChuyenController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstTrangThaiVanChuyen"] = await dbContext.TrangThaiVanChuyens.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string trangthaivanchuyen)
  {
    var trangThaiVanChuyen = await dbContext.TrangThaiVanChuyens.FindAsync(id);
    if (trangThaiVanChuyen != null)
    {
      trangThaiVanChuyen.TrangThai = trangthaivanchuyen;
      dbContext.Update(trangThaiVanChuyen);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string trangthaivanchuyen)
  {
    var trangThaiVanChuyen = new TrangThaiVanChuyen();
    trangThaiVanChuyen.TrangThai = trangthaivanchuyen;
    dbContext.Add(trangThaiVanChuyen);
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
    var trangThaiVanChuyen = await dbContext.TrangThaiVanChuyens.FindAsync(id);
    if (trangThaiVanChuyen != null)
    {
        dbContext.TrangThaiVanChuyens.Remove(trangThaiVanChuyen);
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

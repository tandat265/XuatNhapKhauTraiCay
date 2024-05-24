using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class TrangThaiPhuongTienController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public TrangThaiPhuongTienController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstTrangThaiPhuongTien"] = await dbContext.TrangThaiPhuongTiens.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string trangthaiphuongtien)
  {
    var trangThaiPhuongTien = await dbContext.TrangThaiPhuongTiens.FindAsync(id);
    if (trangThaiPhuongTien != null)
    {
      trangThaiPhuongTien.TrangThai = trangthaiphuongtien;
      dbContext.Update(trangThaiPhuongTien);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string trangthaiphuongtien)
  {
    var trangThaiPhuongTien = new TrangThaiPhuongTien();
    trangThaiPhuongTien.TrangThai = trangthaiphuongtien;
    dbContext.Add(trangThaiPhuongTien);
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
    var trangThaiPhuongTien = await dbContext.TrangThaiPhuongTiens.FindAsync(id);
    if (trangThaiPhuongTien != null)
    {
        dbContext.TrangThaiPhuongTiens.Remove(trangThaiPhuongTien);
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

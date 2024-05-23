using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class TrangThaiNhanVienController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public TrangThaiNhanVienController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstTrangThaiNhanVien"] = await dbContext.TrangThaiNhanViens.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string trangthai)
  {
    var trangThaiNhanVien = await dbContext.TrangThaiNhanViens.FindAsync(id);
    if (trangThaiNhanVien != null)
    {
      trangThaiNhanVien.TrangThai = trangthai;
      dbContext.Update(trangThaiNhanVien);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string trangThai)
  {
    var trangThaiNhanVien = new TrangThaiNhanVien();
    trangThaiNhanVien.TrangThai = trangThai;
    dbContext.Add(trangThaiNhanVien);
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
    var trangThaiNhanVien = await dbContext.TrangThaiNhanViens.FindAsync(id);
    if (trangThaiNhanVien != null)
    {
        dbContext.TrangThaiNhanViens.Remove(trangThaiNhanVien);
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class LoaiPhuongTienController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public LoaiPhuongTienController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstLoaiPhuongTien"] = await dbContext.LoaiPhuongTiens.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string loaiphuongtien)
  {
    var loaiPhuongTien = await dbContext.LoaiPhuongTiens.FindAsync(id);
    if (loaiPhuongTien != null)
    {
      loaiPhuongTien.LoaiPhuongTien1 = loaiphuongtien;
      dbContext.Update(loaiPhuongTien);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string loaiphuongtien)
  {
    var loaiPhuongTien = new LoaiPhuongTien();
    loaiPhuongTien.LoaiPhuongTien1 = loaiphuongtien;
    dbContext.Add(loaiPhuongTien);
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
    var loaiPhuongTien = await dbContext.LoaiPhuongTiens.FindAsync(id);
    if (loaiPhuongTien != null)
    {
        dbContext.LoaiPhuongTiens.Remove(loaiPhuongTien);
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

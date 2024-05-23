using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class LoaiHopDongController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public LoaiHopDongController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstLoaiHopDong"] = await dbContext.LoaiHopDongs.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string loaihopdong)
  {
    var loaiHopDong = await dbContext.LoaiHopDongs.FindAsync(id);
    if (loaiHopDong != null)
    {
      loaiHopDong.LoaiHopDong1 = loaihopdong;
      dbContext.Update(loaiHopDong);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string loaihopdong)
  {
    var loaiHopDong = new LoaiHopDong();
    loaiHopDong.LoaiHopDong1 = loaihopdong;
    dbContext.Add(loaiHopDong);
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
    var loaiHopDong = await dbContext.LoaiHopDongs.FindAsync(id);
    if (loaiHopDong != null)
    {
        dbContext.LoaiHopDongs.Remove(loaiHopDong);
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

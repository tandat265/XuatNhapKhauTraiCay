using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class LoaiTraiCayController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public LoaiTraiCayController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstLoaiTraiCay"] = await dbContext.LoaiTraiCays.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string loaitraicay)
  {
    var loaiTraiCay = await dbContext.LoaiTraiCays.FindAsync(id);
    if (loaiTraiCay != null)
    {
      loaiTraiCay.LoaiTraiCay1 = loaitraicay;
      dbContext.Update(loaiTraiCay);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string loaitraicay)
  {
    var loaiTraiCay = new LoaiTraiCay();
    loaiTraiCay.LoaiTraiCay1 = loaitraicay;
    dbContext.Add(loaiTraiCay);
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
    var loaiTraiCay = await dbContext.LoaiTraiCays.FindAsync(id);
    if (loaiTraiCay != null)
    {
        dbContext.LoaiTraiCays.Remove(loaiTraiCay);
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

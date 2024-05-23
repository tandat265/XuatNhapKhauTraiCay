using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class ChucVuController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public ChucVuController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstChucVu"] = await dbContext.ChucVus.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string chucvu)
  {
    var chucVu = await dbContext.ChucVus.FindAsync(id);
    if (chucVu != null)
    {
      chucVu.ChucVu1 = chucvu;
      dbContext.Update(chucVu);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string chucvu)
  {
    var chucVu = new ChucVu();
    chucVu.ChucVu1 = chucvu;
    dbContext.Add(chucVu);
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
    var chucVu = await dbContext.ChucVus.FindAsync(id);
    if (chucVu != null)
    {
        dbContext.ChucVus.Remove(chucVu);
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

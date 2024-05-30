using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class DonViTinhController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public DonViTinhController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstDonViTinh"] = await dbContext.DonViTinhs.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string donvitinh)
  {
    var donViTinh = await dbContext.DonViTinhs.FindAsync(id);
    if (donViTinh != null)
    {
      donViTinh.DonViTinh1 = donvitinh;
      dbContext.Update(donViTinh);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string donvitinh)
  {
    var donViTinh = new DonViTinh();
    donViTinh.DonViTinh1 = donvitinh;
    dbContext.Add(donViTinh);
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
    var donViTinh = await dbContext.DonViTinhs.FindAsync(id);
    if (donViTinh != null)
    {
        dbContext.DonViTinhs.Remove(donViTinh);
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class QuocGiaController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public QuocGiaController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstQuocGia"] = await dbContext.QuocGia.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string quocgia)
  {
    var quocGia = await dbContext.QuocGia.FindAsync(id);
    if (quocGia != null)
    {
      quocGia.TenQuocGia = quocgia;
      dbContext.Update(quocGia);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string quocgia)
  {
    var quocGium = new QuocGium();
    quocGium.TenQuocGia = quocgia;
    dbContext.Add(quocGium);
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
    var quocGium = await dbContext.QuocGia.FindAsync(id);
    if (quocGium != null)
    {
        dbContext.QuocGia.Remove(quocGium);
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

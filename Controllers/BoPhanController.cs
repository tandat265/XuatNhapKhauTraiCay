using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class BoPhanController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public BoPhanController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstBoPhan"] = await dbContext.BoPhans.ToListAsync();
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Edit(int id, string bophan)
  {
    var boPhan = await dbContext.BoPhans.FindAsync(id);
    if (boPhan != null)
    {
      boPhan.TenBoPhan = bophan;
      dbContext.Update(boPhan);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public IActionResult Create(string bophan)
  {
    var boPhan = new BoPhan();
    boPhan.TenBoPhan = bophan;
    dbContext.Add(boPhan);
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
    var boPhan = await dbContext.BoPhans.FindAsync(id);
    if (boPhan != null)
    {
        dbContext.BoPhans.Remove(boPhan);
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

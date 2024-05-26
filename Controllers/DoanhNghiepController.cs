using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class DoanhNghiepController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public DoanhNghiepController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstDoanhNghiep"] = await dbContext.DoanhNghieps.ToListAsync();
    ViewData["lstQuocGia"] = await dbContext.QuocGia.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var doanhNghiep = await dbContext.DoanhNghieps.Where(item => item.MaDoanhNghiep == id).FirstOrDefaultAsync();
    ViewData["doanhNghiep"] = doanhNghiep;
    ViewData["quocGia"] = await dbContext.QuocGia.Where(item => item.MaQuocGia == doanhNghiep.MaQuocGia).FirstOrDefaultAsync();
    return View();
  }

  public async Task<IActionResult> Edit(int id)
  {
    var doanhNghiep = await dbContext.DoanhNghieps.Where(item => item.MaDoanhNghiep == id).FirstOrDefaultAsync();
    var quocGia = await dbContext.QuocGia.ToListAsync();
    ViewData["lstQuocGia"] = new SelectList(quocGia, "MaQuocGia", "TenQuocGia", doanhNghiep.MaQuocGia);
    return View(doanhNghiep);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("MaDoanhNghiep,TenDoanhNghiep,DiaChi,Sdt,MaQuocGia")] DoanhNghiep doanhNghiepEdit)
  {
    if (ModelState.IsValid)
    {
        var doanhNghiep = await dbContext.DoanhNghieps.FindAsync(doanhNghiepEdit.MaDoanhNghiep);
        if (doanhNghiep == null)
        {
            return NotFound();
        }
        doanhNghiep.TenDoanhNghiep = doanhNghiepEdit.TenDoanhNghiep;
        doanhNghiep.DiaChi = doanhNghiepEdit.DiaChi;
        doanhNghiep.Sdt = doanhNghiepEdit.Sdt;
        doanhNghiep.MaQuocGia = doanhNghiepEdit.MaQuocGia;
        dbContext.Update(doanhNghiep);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Doanh nghiệp đã được chỉnh sửa thành công.";
        return RedirectToAction("Index");
    }
    return View(doanhNghiepEdit);
  }

  public async Task<IActionResult> Create()
  {
    var quocGia = await dbContext.QuocGia.ToListAsync();
    ViewData["lstQuocGia"] = new SelectList(quocGia, "MaQuocGia", "TenQuocGia");
    return View();
  }

  [HttpPost]
  public IActionResult Create([Bind("MaDoanhNghiep,TenDoanhNghiep,DiaChi,Sdt,MaQuocGia")] DoanhNghiep doanhNghiepCreate)
  {
    if (ModelState.IsValid)
    {
      dbContext.Add(doanhNghiepCreate);
      dbContext.SaveChanges();
      TempData["SuccessMessage"] = "Doanh nghiệp đã được tạo thành công.";
      return RedirectToAction("Index");
    }
    return View(doanhNghiepCreate);
  }

  public async Task<IActionResult> Delete(int id)
  {
    var doanhNghiep = await dbContext.DoanhNghieps.Where(item => item.MaDoanhNghiep == id).FirstOrDefaultAsync();
    ViewData["doanhNghiep"] = doanhNghiep;
    ViewData["quocGia"] = await dbContext.QuocGia.Where(item => item.MaQuocGia == doanhNghiep.MaQuocGia).FirstOrDefaultAsync();
    return View(doanhNghiep);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("TenDoanhNghiep,DiaChi,Sdt,MaQuocGia")] DoanhNghiep doanhNghiepDelete)
  {
    var doanhNghiep = await dbContext.DoanhNghieps.FindAsync(id);
    if (doanhNghiep != null)
    {
        dbContext.DoanhNghieps.Remove(doanhNghiep);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Doanh nghiệp đã được xoá thành công.";
    }
    else
    {
        // Handle the case where the entity was not found in the database
        ModelState.AddModelError("", "Doanh nghiệp không tồn tại.");
    }
    return RedirectToAction("Index");
  }



}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class NhaCungCapController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public NhaCungCapController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstNhaCungCap"] = await dbContext.NhaCungCaps.ToListAsync();
    ViewData["lstTraiCay"] = await dbContext.TraiCays.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var nhaCungCap = await dbContext.NhaCungCaps.Where(item => item.MaNhaCungCap == id).FirstOrDefaultAsync();
    ViewData["nhaCungCap"] = nhaCungCap;
    ViewData["traiCay"] = await dbContext.TraiCays.Where(item => item.MaTraiCay == nhaCungCap.MaTraiCay).FirstOrDefaultAsync();
    return View();
  }

  public async Task<IActionResult> Edit(int id)
  {
    var nhaCungCap = await dbContext.NhaCungCaps.Where(item => item.MaNhaCungCap == id).FirstOrDefaultAsync();
    var traiCay = await dbContext.TraiCays.ToListAsync();
    ViewData["lstTraiCay"] = new SelectList(traiCay, "MaTraiCay", "TenTraiCay");
    return View(nhaCungCap);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("MaNhaCungCap,TenNhaCungCap,DiaChi,Sđt,MaTraiCay")] NhaCungCap nhaCungCapEdit)
  {
    if (ModelState.IsValid)
    {
        var nhaCungCap = await dbContext.NhaCungCaps.FindAsync(id);
        if (nhaCungCapEdit == null)
        {
            return NotFound();
        }
        nhaCungCap.TenNhaCungCap = nhaCungCapEdit.TenNhaCungCap;
        nhaCungCap.DiaChi = nhaCungCapEdit.DiaChi;
        nhaCungCap.Sđt = nhaCungCapEdit.Sđt;
        nhaCungCap.MaTraiCay = nhaCungCapEdit.MaTraiCay;
        dbContext.Update(nhaCungCap);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Nhà cung cấp đã được chỉnh sửa thành công.";
        return RedirectToAction("Index");
    }
    return View(nhaCungCapEdit);
  }

  public async Task<IActionResult> Create()
  {
    var traiCay = await dbContext.TraiCays.ToListAsync();
    ViewData["lstTraiCay"] = new SelectList(traiCay, "MaTraiCay", "TenTraiCay");
    return View();
  }

  [HttpPost]
  public IActionResult Create([Bind("TenNhaCungCap,DiaChi,Sđt,MaTraiCay")] NhaCungCap nhaCungCapCreate)
  {
    if (ModelState.IsValid)
    {
      dbContext.Add(nhaCungCapCreate);
      dbContext.SaveChanges();
      TempData["SuccessMessage"] = "Nhà cung cấp đã được tạo thành công.";
      return RedirectToAction("Index");
    }
    return View(nhaCungCapCreate);
  }

  public async Task<IActionResult> Delete(int id)
  {
    var nhaCungCap = await dbContext.NhaCungCaps.Where(item => item.MaNhaCungCap == id).FirstOrDefaultAsync();
    ViewData["nhaCungCap"] = nhaCungCap;
    ViewData["traiCay"] = await dbContext.TraiCays.Where(item => item.MaTraiCay == nhaCungCap.MaTraiCay).FirstOrDefaultAsync();
    return View(nhaCungCap);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("TenNhaCungCap,DiaChi,Sđt,MaTraiCay")] NhaCungCap nhaCungCapDelete)
  {
    var nhaCungCap = await dbContext.NhaCungCaps.Where(item => item.MaNhaCungCap == id).FirstOrDefaultAsync();
    if (nhaCungCap != null)
    {
        dbContext.NhaCungCaps.Remove(nhaCungCap);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Nhà cung cấp đã được xoá thành công.";
    }
    else
    {
        // Handle the case where the entity was not found in the database
        ModelState.AddModelError("", "Nhà cung cấp không tồn tại.");
    }
    return RedirectToAction("Index");
  }



}

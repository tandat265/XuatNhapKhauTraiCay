using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class PhuongTienController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public PhuongTienController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstPhuongTien"] = await dbContext.PhuongTiens.ToListAsync();
    ViewData["lstLoaiPhuongTien"] = await dbContext.LoaiPhuongTiens.ToListAsync();
    ViewData["lstTrangThai"] = await dbContext.TrangThaiPhuongTiens.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var phuongTien = await dbContext.PhuongTiens.Where(item => item.MaPhuongTien == id).FirstOrDefaultAsync();
    ViewData["phuongTien"] = phuongTien;
    ViewData["loaiPhuongTien"] = await dbContext.LoaiPhuongTiens.FindAsync(phuongTien.IdloaiPhuongTien);
    ViewData["trangThai"] = await dbContext.TrangThaiPhuongTiens.FindAsync(phuongTien.IdtrangThai);
    return View();
  }

  public async Task<IActionResult> Edit(int id)
  {
    var phuongTien = await dbContext.PhuongTiens.FindAsync(id);
    var loaiPhuongTiens = await dbContext.LoaiPhuongTiens.ToListAsync();
    var trangThaiPhuongTiens = await dbContext.TrangThaiPhuongTiens.ToListAsync();
    ViewData["lstLoaiPhuongTien"] = new SelectList(loaiPhuongTiens, "IdloaiPhuongTien", "LoaiPhuongTien1", phuongTien.IdloaiPhuongTien);
    ViewData["lstTrangThai"] = new SelectList(trangThaiPhuongTiens, "IdtrangThai", "TrangThai", phuongTien.IdtrangThai);
    return View(phuongTien);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("MaPhuongTien,TenPhuongTien,IdloaiPhuongTien,IdtrangThai")] PhuongTien phuongTienEdit)
  {
    if (ModelState.IsValid)
    {
        var phuongTien = await dbContext.PhuongTiens.FindAsync(id);
        if (phuongTien == null)
        {
            return NotFound();
        }
        phuongTien.TenPhuongTien = phuongTienEdit.TenPhuongTien;
        phuongTien.IdloaiPhuongTien = phuongTienEdit.IdloaiPhuongTien;
        phuongTien.IdtrangThai = phuongTienEdit.IdtrangThai;
        dbContext.Update(phuongTien);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Phương tiện đã được chỉnh sửa thành công.";
        return RedirectToAction("Index");
    }
    return View(phuongTienEdit);
  }

  public async Task<IActionResult> Create()
  {
    var loaiPhuongTiens = await dbContext.LoaiPhuongTiens.ToListAsync();
    var trangThaiPhuongTiens = await dbContext.TrangThaiPhuongTiens.ToListAsync();
    ViewData["lstLoaiPhuongTien"] = new SelectList(loaiPhuongTiens, "IdloaiPhuongTien", "LoaiPhuongTien1");
    ViewData["lstTrangThai"] = new SelectList(trangThaiPhuongTiens, "IdtrangThai", "TrangThai");
    return View();
  }

  [HttpPost]
  public IActionResult Create([Bind("TenPhuongTien,IdloaiPhuongTien,IdtrangThai")] PhuongTien phuongTienCreate)
  {
    if (ModelState.IsValid)
    {
      dbContext.Add(phuongTienCreate);
      dbContext.SaveChanges();
      TempData["SuccessMessage"] = "Phương tiện đã được tạo thành công.";
      return RedirectToAction("Index");
    }
    return View(phuongTienCreate);
  }

  public async Task<IActionResult> Delete(int id)
  {
    var phuongTien = await dbContext.PhuongTiens.Where(item => item.MaPhuongTien == id).FirstOrDefaultAsync();
    ViewData["phuongTien"] = phuongTien;
    ViewData["loaiPhuongTien"] = await dbContext.LoaiPhuongTiens.FindAsync(phuongTien.IdloaiPhuongTien);
    ViewData["trangThai"] = await dbContext.TrangThaiPhuongTiens.FindAsync(phuongTien.IdtrangThai);
    return View(phuongTien);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("TenPhuongTien,IdloaiPhuongTien,IdtrangThai")] PhuongTien phuongTienDelete)
  {
    var phuongTien = await dbContext.PhuongTiens.FindAsync(id);
    if (phuongTien != null)
    {
        dbContext.PhuongTiens.Remove(phuongTien);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Phương tiện đã được xoá thành công.";
    }
    else
    {
        // Handle the case where the entity was not found in the database
        ModelState.AddModelError("", "Nhà cung cấp không tồn tại.");
    }
    return RedirectToAction("Index");
  }



}

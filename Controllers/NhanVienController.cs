using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class NhanVienController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public NhanVienController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstNhanVien"] = await dbContext.NhanViens.ToListAsync();
    ViewData["lstBoPhan"] = await dbContext.BoPhans.ToListAsync();
    ViewData["lstTrangThai"] = await dbContext.TrangThaiNhanViens.ToListAsync();
    ViewData["lstChucVu"] = await dbContext.ChucVus.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var nhanVien = await dbContext.NhanViens.Where(item => item.MaNhanVien == id).FirstOrDefaultAsync();
    ViewData["nhanVien"] = nhanVien;
    ViewData["chucVu"] = await dbContext.ChucVus.Where(item => item.IdChucVu == nhanVien.IdChucVu).FirstOrDefaultAsync();
    ViewData["boPhan"] = await dbContext.BoPhans.Where(item => item.IdboPhan == nhanVien.IdboPhan).FirstOrDefaultAsync();
    ViewData["trangThai"] = await dbContext.TrangThaiNhanViens.Where(item => item.IdtrangThai == nhanVien.IdtrangThai).FirstOrDefaultAsync();
    return View();
  }

  public async Task<IActionResult> Edit(int id)
  {
    var nhanVien = await dbContext.NhanViens.Where(item => item.MaNhanVien == id).FirstOrDefaultAsync();
    ViewData["nhanVien"] = nhanVien;
    var chucVus = await dbContext.ChucVus.ToListAsync();
    var chucVu = new SelectList(chucVus, "IdChucVu", "ChucVu1", nhanVien.IdChucVu);
    ViewData["lstChucVu"] = chucVu;
    var boPhans = await dbContext.BoPhans.ToListAsync();
    ViewData["lstBoPhan"] = new SelectList(boPhans, "IdboPhan", "TenBoPhan", nhanVien.IdboPhan);
    var trangThais = await dbContext.TrangThaiNhanViens.ToListAsync();
    ViewData["lstTrangThai"] = new SelectList(trangThais, "IdtrangThai", "TrangThai", nhanVien.IdtrangThai);
    return View(nhanVien);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("MaNhanVien,TenNhanVien,IdChucVu,IdboPhan,IdtrangThai,Email,Phone,Cccd,Address")] NhanVien nhanVienEdit)
  {
    if (ModelState.IsValid)
    {
        var nhanVien = await dbContext.NhanViens.FindAsync(nhanVienEdit.MaNhanVien);
        if (nhanVien == null)
        {
            return NotFound();
        }
        nhanVien.TenNhanVien = nhanVienEdit.TenNhanVien;
        nhanVien.IdChucVu = nhanVienEdit.IdChucVu;
        nhanVien.IdboPhan = nhanVienEdit.IdboPhan;
        nhanVien.IdtrangThai = nhanVienEdit.IdtrangThai;
        nhanVien.Email = nhanVienEdit.Email;
        nhanVien.Phone = nhanVienEdit.Phone;
        nhanVien.Cccd = nhanVienEdit.Cccd;
        nhanVien.Address = nhanVienEdit.Address;

        dbContext.Update(nhanVien);
        dbContext.SaveChanges();
        
        return RedirectToAction("Index");
    }
    return View(nhanVienEdit);
  }



}

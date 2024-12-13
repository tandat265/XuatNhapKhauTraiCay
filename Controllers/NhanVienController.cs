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
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Nhân viên đã được chỉnh sửa thành công.";
        return RedirectToAction("Index");
    }
    return View(nhanVienEdit);
  }

  public async Task<IActionResult> Create()
  {
    var chucVus = await dbContext.ChucVus.ToListAsync();
    var chucVu = new SelectList(chucVus, "IdChucVu", "ChucVu1");
    ViewData["lstChucVu"] = chucVu;
    var boPhans = await dbContext.BoPhans.ToListAsync();
    ViewData["lstBoPhan"] = new SelectList(boPhans, "IdboPhan", "TenBoPhan");
    var trangThais = await dbContext.TrangThaiNhanViens.ToListAsync();
    ViewData["lstTrangThai"] = new SelectList(trangThais, "IdtrangThai", "TrangThai");
    return View();
  }

  [HttpPost]
  public IActionResult Create([Bind("MaNhanVien,TenNhanVien,IdChucVu,IdboPhan,IdtrangThai,Email,Phone,Cccd,Address")] NhanVien nhanVienCreate)
  {
    if (ModelState.IsValid)
    {
      dbContext.Add(nhanVienCreate);
      dbContext.SaveChanges();
      TempData["SuccessMessage"] = "Nhân viên đã được tạo thành công.";
      return RedirectToAction("Index");
    }
    return View(nhanVienCreate);
  }

  public async Task<IActionResult> Delete(int id)
  {
    var nhanVien = await dbContext.NhanViens.Where(item => item.MaNhanVien == id).FirstOrDefaultAsync();
    ViewData["nhanVien"] = nhanVien;
    ViewData["chucVu"] = await dbContext.ChucVus.Where(item => item.IdChucVu == nhanVien.IdChucVu).FirstOrDefaultAsync();
    ViewData["boPhan"] = await dbContext.BoPhans.Where(item => item.IdboPhan == nhanVien.IdboPhan).FirstOrDefaultAsync();
    ViewData["trangThai"] = await dbContext.TrangThaiNhanViens.Where(item => item.IdtrangThai == nhanVien.IdtrangThai).FirstOrDefaultAsync();
    return View(nhanVien);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("MaNhanVien,TenNhanVien,IdChucVu,IdboPhan,IdtrangThai,Email,Phone,Cccd,Address")] NhanVien nhanVienDelete)
  {
    if (ModelState.IsValid)
    {
        var nhanVien = await dbContext.NhanViens.FindAsync(id);
        if (nhanVien != null)
        {
            dbContext.NhanViens.Remove(nhanVien);
            await dbContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Nhân viên đã được xoá thành công.";
        }
        else
        {
            // Handle the case where the entity was not found in the database
            ModelState.AddModelError("", "Nhân viên không tồn tại.");
        }
        return RedirectToAction("Index");
    }
    return View(nhanVienDelete);
  }



}

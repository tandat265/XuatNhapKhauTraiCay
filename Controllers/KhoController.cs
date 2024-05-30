using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class KhoController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public KhoController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstKho"] = await dbContext.Khos.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var kho = await dbContext.Khos.FindAsync(id);
    ViewData["kho"] = kho;
    var lstTraiCay_Kho = await dbContext.ViewChiTietKhos.Where(item => item.MaKho == id).ToListAsync();
    ViewData["lstChiTietKho"] = lstTraiCay_Kho;
    var lstTraiCay = await dbContext.TraiCays.ToListAsync();
    var lstDonViTinh = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstTraiCay"] = lstTraiCay;
    ViewData["lstDonViTinh"] = lstDonViTinh;
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> EditKho(int id, string tenkho, string diachi)
  {
    var kho = await dbContext.Khos.FindAsync(id);
    kho.TenKho = tenkho;
    kho.DiaChi = diachi;
    dbContext.Update(kho);
    await dbContext.SaveChangesAsync();
    TempData["SuccessMessage"] = "Kho đã được chỉnh sửa thành công.";
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }
  [HttpPost]
  public async Task<IActionResult> CreateKho(string tenkho, string diachi)
  {
    Kho newKho = new Kho();
    newKho.TenKho = tenkho;
    newKho.DiaChi = diachi;
    dbContext.Khos.Add(newKho);
    await dbContext.SaveChangesAsync();
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }

  [HttpPost]
  public async Task<IActionResult> CreateChiTietKho(int makho,int matraicay,int donvitinh,int soluong)
  {
    ChiTietKho newChiTietKho = new ChiTietKho();
    newChiTietKho.MaKho = makho;
    newChiTietKho.MaTraiCay = matraicay;
    newChiTietKho.SoLuong = soluong;
    newChiTietKho.IdDonViTinh = donvitinh;
    dbContext.ChiTietKhos.Add(newChiTietKho);
    await dbContext.SaveChangesAsync();
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }

  public async Task<IActionResult> Delete(int id)
  {
    var kho = await dbContext.Khos.FindAsync(id);
    var lstChiTietKho = await dbContext.ViewChiTietKhos.Where(item => item.MaKho == id).ToListAsync();
    ViewData["kho"] = kho;
    ViewData["lstChiTietKho"] = lstChiTietKho;
    return View(kho);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("TenKho,DiaChi")] Kho khoDelete)
  {
    var kho = await dbContext.Khos.FindAsync(id);
    var chiTietKho = await dbContext.ChiTietKhos.Where(item => item.MaKho == id).ToListAsync();
    if (kho != null)
    {
        dbContext.Khos.Remove(kho);
        dbContext.ChiTietKhos.RemoveRange(chiTietKho);
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

  [HttpPost]
  public async Task<IActionResult> DeleteChiTietKho(int id)
  {
    var chiTietKho = await dbContext.ChiTietKhos.FindAsync(id);
    if (chiTietKho != null)
    {
        dbContext.ChiTietKhos.Remove(chiTietKho);
        await dbContext.SaveChangesAsync();
    }
    else
    {
        // Handle the case where the entity was not found in the database
        ModelState.AddModelError("", "Trái cây không tồn tại.");
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }

  [HttpPost]
  public async Task<IActionResult> EditChiTietKho(int id, int maTraiCay,int soLuong,int idDonViTinh)
  {
    var chiTietKho = await dbContext.ChiTietKhos.FindAsync(id);
    if (chiTietKho != null)
    {
      chiTietKho.SoLuong = soLuong;
      chiTietKho.MaTraiCay = maTraiCay;
      chiTietKho.IdDonViTinh = idDonViTinh;
      dbContext.Update(chiTietKho);
      await dbContext.SaveChangesAsync();
    }
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }

}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class TraiCayController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public TraiCayController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstTraiCay"] = await dbContext.TraiCays.ToListAsync();
    ViewData["dicLoaiTraiCay"] = await dbContext.LoaiTraiCays.ToListAsync();
    var dicGiaTraiCay = await dbContext.GiaTraiCays.OrderByDescending(item => item.NgayCapNhat.Value).ToListAsync();
    var gbGiaTraiCay = dicGiaTraiCay.GroupBy(item => item.MaTraiCay).Select(item => item.ToList()).ToList();
    var lstGiaTraiCay = new List<GiaTraiCay>();
    foreach (var giaTraiCay in gbGiaTraiCay)
    {
      lstGiaTraiCay.Add(giaTraiCay[0]);
    }
    ViewData["dicGiaTraiCay"] = lstGiaTraiCay;
    ViewData["dicDonViTinh"] = await dbContext.DonViTinhs.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var traiCay = await dbContext.TraiCays.FindAsync(id);
    ViewData["traiCay"] = traiCay;
    ViewData["loaiTraiCay"] = await dbContext.LoaiTraiCays.FindAsync(traiCay.IdloaiTraiCay);
    var lstGiaTraiCay = await dbContext.GiaTraiCays.OrderByDescending(item => item.NgayCapNhat.Value).Where(c => c.MaTraiCay ==  traiCay.MaTraiCay).ToListAsync();
    ViewData["lstGiaTraiCay"] = lstGiaTraiCay;
    ViewData["lstDonViTinh"] = await dbContext.DonViTinhs.ToDictionaryAsync(c => c.IdDonViTinh, c => c.DonViTinh1);

    return View();
  }

  public async Task<IActionResult> Edit(int id)
  {
    var traiCay = await dbContext.TraiCays.FindAsync(id);
    ViewData["traiCay"] = traiCay;
    var giaTraiCay = await dbContext.GiaTraiCays.OrderByDescending(item => item.NgayCapNhat.Value).Where(i => i.MaTraiCay == id).FirstOrDefaultAsync();
    ViewData["giaTraiCay"] = giaTraiCay;
    var lstLoaiTraiCay = await dbContext.LoaiTraiCays.ToListAsync();
    ViewData["lstLoaiTraiCay"] = new SelectList(lstLoaiTraiCay, "IdloaiTraiCay", "LoaiTraiCay1", traiCay.IdloaiTraiCay);
    var lstDonViTinh = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstDonViTinh"] = new SelectList(lstDonViTinh, "IdDonViTinh", "DonViTinh1", giaTraiCay != null ? giaTraiCay.IdDonViTinh : "");
    return View();
  }

  public async Task<IActionResult> Create()
  {
    var lstLoaiTraiCay = await dbContext.LoaiTraiCays.ToListAsync();
    ViewData["lstLoaiTraiCay"] = new SelectList(lstLoaiTraiCay, "IdloaiTraiCay", "LoaiTraiCay1");
    var lstDonViTinh = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstDonViTinh"] = new SelectList(lstDonViTinh, "IdDonViTinh", "DonViTinh1");
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> SaveEdit(int idtraicay,string tentraicay,int loaitraicay,int giatien, int soluong, int donvitinh, string mota)
  {
    var traiCay = await dbContext.TraiCays.FindAsync(idtraicay);
    traiCay.TenTraiCay = tentraicay;
    traiCay.MoTa = mota;
    traiCay.IdloaiTraiCay = loaitraicay;
    dbContext.Update(traiCay);
    var giaTraiCay = await dbContext.GiaTraiCays.Where(c => c.MaTraiCay == idtraicay).OrderByDescending(c => c.NgayCapNhat).FirstOrDefaultAsync();
    if (giaTraiCay == null || giaTraiCay.GiaTien != giatien || giaTraiCay.IdDonViTinh != donvitinh || giaTraiCay.SoLuong != soluong)
    {
      var giaTraiCayNew = new GiaTraiCay();
      giaTraiCayNew.MaTraiCay = idtraicay;
      giaTraiCayNew.NgayCapNhat = DateTime.Now;
      giaTraiCayNew.GiaTien = giatien;
      giaTraiCayNew.IdDonViTinh = donvitinh;
      giaTraiCayNew.SoLuong = soluong;
      dbContext.Add(giaTraiCayNew);
    }
    await dbContext.SaveChangesAsync();
    var responseData = new
    {
        message = "Thành công",
    };
    return RedirectToAction("Detail", new { id = idtraicay });
  }

  [HttpPost]
  public async Task<IActionResult> SaveCreate(string tentraicay,int loaitraicay,int giatien, int soluong, int donvitinh, string mota)
  {
    var traiCay = new TraiCay();
    traiCay.TenTraiCay = tentraicay;
    traiCay.MoTa = mota;
    traiCay.IdloaiTraiCay = loaitraicay;
    dbContext.Add(traiCay);
    await dbContext.SaveChangesAsync();
    var giaTraiCayNew = new GiaTraiCay();
    giaTraiCayNew.MaTraiCay = traiCay.MaTraiCay;
    giaTraiCayNew.NgayCapNhat = DateTime.Now;
    giaTraiCayNew.GiaTien = giatien;
    giaTraiCayNew.IdDonViTinh = donvitinh;
    giaTraiCayNew.SoLuong = soluong;
    dbContext.Add(giaTraiCayNew);

    await dbContext.SaveChangesAsync();
    var responseData = new
    {
        message = "Thành công",
    };
    return RedirectToAction("Index");
  }

  public async Task<IActionResult> Delete(int id)
  {
    var traiCay = await dbContext.TraiCays.FindAsync(id);
    ViewData["traiCay"] = traiCay;
    ViewData["loaiTraiCay"] = await dbContext.LoaiTraiCays.FindAsync(traiCay.IdloaiTraiCay);
    var giaTraiCay = await dbContext.GiaTraiCays.OrderByDescending(item => item.NgayCapNhat.Value).Where(c => c.MaTraiCay ==  traiCay.MaTraiCay).FirstOrDefaultAsync();
    ViewData["giaTraiCay"] = giaTraiCay;
    ViewData["lstDonViTinh"] = await dbContext.DonViTinhs.ToDictionaryAsync(c => c.IdDonViTinh, c => c.DonViTinh1);
    return View(traiCay);
  }


  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("TenTraiCay,IdloaiTraiCay,MoTa")] TraiCay traiCayDelete)
  {
    var traiCay = await dbContext.TraiCays.FindAsync(id);
    var giaTraiCay = await dbContext.GiaTraiCays.Where(item => item.MaTraiCay == id).ToListAsync();
    if (traiCay != null)
    {
        dbContext.TraiCays.Remove(traiCay);
        dbContext.GiaTraiCays.RemoveRange(giaTraiCay);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Trái cây đã được xoá thành công.";
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

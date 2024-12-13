using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Controllers;

public class HopDongController : Controller
{
  DbXuatNhapKhauContext dbContext;

  public HopDongController(DbXuatNhapKhauContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public async Task<IActionResult> Index()
  {
    ViewData["lstHopDong"] = await dbContext.HopDongs.ToListAsync();
    ViewData["lstNhanVien"] = await dbContext.NhanViens.ToListAsync();
    ViewData["lstDoanhNghiep"] = await dbContext.DoanhNghieps.ToListAsync();
    ViewData["lstNhaCungCap"] = await dbContext.NhaCungCaps.ToListAsync();
    ViewData["lstTrangThai"] = await dbContext.TrangThaiHopDongs.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var hopDong = await dbContext.HopDongs.FindAsync(id);
    ViewData["hopDong"] = hopDong;
    var loaiHopDong = await dbContext.LoaiHopDongs.FindAsync(hopDong.IdloaiHopDong);
    ViewData["loaiHopDong"] = loaiHopDong;
    var nhanVien = await dbContext.NhanViens.FindAsync(hopDong.MaNhanVien);
    ViewData["nhanVien"] = nhanVien;
    ViewData["lstDoanhNghiep"] = await dbContext.DoanhNghieps.ToListAsync();
    ViewData["lstNhaCungCap"] = await dbContext.NhaCungCaps.ToListAsync();
    ViewData["lstTrangThai"] = await dbContext.TrangThaiHopDongs.ToListAsync();
    ViewData["lstLoHang"] = await dbContext.LoHangs.Where(item => item.MaHopDong == id).ToListAsync();
    ViewData["lstKho"] = await dbContext.Khos.ToListAsync();
    ViewData["lstPhuongTien"] = await dbContext.PhuongTiens.ToListAsync();
    ViewData["lstDonViTinh"] = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstTraiCay"] = await dbContext.TraiCays.ToListAsync();
    return View();
  }

  public async Task<IActionResult> Edit(int id)
  {
    var hopDong = await dbContext.HopDongs.FindAsync(id);
    ViewData["hopDong"] = hopDong;
    var lstLoaiHopDong = await dbContext.LoaiHopDongs.ToListAsync();
    ViewData["lstLoaiHopDong"] = new SelectList(lstLoaiHopDong, "IdloaiHopDong", "LoaiHopDong1", hopDong?.IdloaiHopDong);
    var lstNhanVien = await dbContext.NhanViens.ToListAsync();
    ViewData["lstNhanVien"] = new SelectList(lstNhanVien, "MaNhanVien", "TenNhanVien", hopDong?.MaNhanVien);
    ViewData["lstDoanhNghiep"] = await dbContext.DoanhNghieps.ToListAsync();
    ViewData["lstNhaCungCap"] = await dbContext.NhaCungCaps.ToListAsync();
    var lstTrangThai = await dbContext.TrangThaiHopDongs.ToListAsync();
    ViewData["lstTrangThai"] = lstTrangThai;
    ViewData["lstTrangThaiSelectList"] = new SelectList(lstTrangThai, "IdtrangThai", "TrangThai", hopDong?.IdtrangThai);
    ViewData["lstLoHang"] = await dbContext.LoHangs.Where(item => item.MaHopDong == id).ToListAsync();
    ViewData["lstKho"] = await dbContext.Khos.ToListAsync();
    ViewData["lstPhuongTien"] = await dbContext.PhuongTiens.ToListAsync();
    ViewData["lstDonViTinh"] = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstTraiCay"] = await dbContext.TraiCays.ToListAsync();
    return View(hopDong);
  }

  public async Task<IActionResult> EditLoHang(int id)
  {
    var loHang = await dbContext.LoHangs.FindAsync(id);
    ViewData["loHang"] = loHang;
    var lstTrangThai = await dbContext.TrangThaiHopDongs.ToListAsync();
    ViewData["lstTrangThai"] = new SelectList(lstTrangThai, "IdtrangThai", "TrangThai", loHang?.IdtrangThai);
    var lstKho = await dbContext.Khos.ToListAsync();
    ViewData["lstKho"] = new SelectList(lstKho, "MaKho", "TenKho", loHang?.MaKho);
    var lstPhuongTien = await dbContext.PhuongTiens.ToListAsync();
    ViewData["lstPhuongTien"] = new SelectList(lstPhuongTien, "MaPhuongTien", "TenPhuongTien", loHang?.MaPhuongTien);
    var lstDonViTinh = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstDonViTinh"] = new SelectList(lstDonViTinh, "IdDonViTinh", "DonViTinh1", loHang?.IdDonViTinh);
    var lstTraiCay = await dbContext.TraiCays.ToListAsync();
    ViewData["lstTraiCay"] = new SelectList(lstTraiCay, "MaTraiCay", "TenTraiCay", loHang?.IdDonViTinh);
    return View(loHang);
  }
  [HttpPost]
  public async Task<IActionResult> EditLoHang(int id, [Bind("MaTraiCay,SoLuong,DonGia,MaKho,IdDonViTinh,MaPhuongTien,IdtrangThai")] LoHang loHangEdit)
  {
    var loHang = await dbContext.LoHangs.FindAsync(id);
    var hopDong = await dbContext.HopDongs.FindAsync(loHang.MaHopDong);
    if (hopDong.TongGia != null)
    {
      var giaCu = loHang.DonGia != null ? loHang.DonGia : 0;
      var giaMoi = loHangEdit.DonGia != null ? loHangEdit.DonGia : 0;
      hopDong.TongGia = hopDong.TongGia - giaCu + giaMoi;
    }
    else
    {
      var giaMoi = loHangEdit.DonGia != null ? loHangEdit.DonGia : 0;
      hopDong.TongGia = giaMoi;
    }
    if (loHang != null)
    {
      loHang.MaTraiCay = loHangEdit.MaTraiCay;
      loHang.SoLuong = loHangEdit.SoLuong;
      loHang.MaKho = loHangEdit.MaKho;
      loHang.IdDonViTinh = loHangEdit.IdDonViTinh;
      loHang.DonGia = loHangEdit.DonGia;
      loHang.MaPhuongTien = loHangEdit.MaPhuongTien;
      loHang.IdtrangThai = loHangEdit.IdtrangThai;
      dbContext.Update(loHang);
      dbContext.Update(hopDong);
      await dbContext.SaveChangesAsync();
    }
    return RedirectToAction("Edit", new {id = loHang.MaHopDong});
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("TenHopDong,MaNhanVien,MaDoiTac,NgayKy,TongGia,IdloaiHopDong,IdtrangThai")] HopDong hopDongEdit)
  {
    var hopDong = await dbContext.HopDongs.FindAsync(id);
    if (hopDong != null)
    {
      hopDong.TenHopDong = hopDongEdit.TenHopDong;
      hopDong.MaNhanVien = hopDongEdit.MaNhanVien;
      hopDong.MaDoiTac = hopDongEdit.MaDoiTac;
      hopDong.NgayKy = hopDongEdit.NgayKy;
      hopDong.TongGia = hopDongEdit.TongGia;
      hopDong.IdloaiHopDong = hopDongEdit.IdloaiHopDong;
      hopDong.IdtrangThai = hopDongEdit.IdtrangThai;
      dbContext.Update(hopDong);
      if (hopDong.IdtrangThai == 1)
      {
        var lstLoHang = await dbContext.LoHangs.Where(c => c.MaHopDong == id && c.IdtrangThai != 1).ToListAsync();
        foreach (var loHang in lstLoHang)
        {
          loHang.IdtrangThai = 1;
          dbContext.Update(loHang);
        }
      }
      await dbContext.SaveChangesAsync();
    }
    return RedirectToAction("Detail", new {id = id});
  }

  [HttpGet]
  public async Task<IActionResult> GetDoiTacByLoaiHopDong(int loaiHopDongId)
  {
    var lstDoanhNghiep = await dbContext.DoanhNghieps.ToListAsync();
    var lstNhaCungCap = await dbContext.NhaCungCaps.ToListAsync();
    if (loaiHopDongId == 1)
    {
        var doiTacs = lstNhaCungCap.Select(ncc => new { id = ncc.MaNhaCungCap, ten = ncc.TenNhaCungCap }).ToList();
        return Json(doiTacs);
    }
    else
    {
        var doiTacs = lstDoanhNghiep.Select(dn => new { id = dn.MaDoanhNghiep, ten = dn.TenDoanhNghiep }).ToList();
        return Json(doiTacs);
    }
  }
  [HttpPost]
  public async Task<IActionResult> Create([Bind("TenHopDong,MaNhanVien,MaDoiTac,NgayKy,TongGia,IdloaiHopDong,IdtrangThai")] HopDong hopDongCreate)
  {
    var hopDong = new HopDong();
    hopDong.TenHopDong = hopDongCreate.TenHopDong;
    hopDong.MaNhanVien = hopDongCreate.MaNhanVien;
    hopDong.MaDoiTac = hopDongCreate.MaDoiTac;
    hopDong.NgayKy = hopDongCreate.NgayKy;
    hopDong.TongGia = 0;
    hopDong.IdloaiHopDong = hopDongCreate.IdloaiHopDong;
    hopDong.IdtrangThai = hopDongCreate.IdtrangThai;
    dbContext.Add(hopDong);
    await dbContext.SaveChangesAsync();
    return RedirectToAction("Edit", new {id = hopDong.MaHopDong});
  }
  public async Task<IActionResult> Create()
  {
    var lstLoaiHopDong = await dbContext.LoaiHopDongs.ToListAsync();
    ViewData["lstLoaiHopDong"] = new SelectList(lstLoaiHopDong, "IdloaiHopDong", "LoaiHopDong1");
    var lstNhanVien = await dbContext.NhanViens.ToListAsync();
    ViewData["lstNhanVien"] = new SelectList(lstNhanVien, "MaNhanVien", "TenNhanVien");
    ViewData["lstDoanhNghiep"] = await dbContext.DoanhNghieps.ToListAsync();
    ViewData["lstNhaCungCap"] = await dbContext.NhaCungCaps.ToListAsync();
    var lstTrangThai = await dbContext.TrangThaiHopDongs.ToListAsync();
    ViewData["lstTrangThai"] = lstTrangThai;
    ViewData["lstTrangThaiSelectList"] = new SelectList(lstTrangThai, "IdtrangThai", "TrangThai");
    return View();
  }
  public async Task<IActionResult> CreateLoHang(int id)
  {
    ViewData["hopDong"] = await dbContext.HopDongs.FindAsync(id);
    var lstTrangThai = await dbContext.TrangThaiHopDongs.ToListAsync();
    ViewData["lstTrangThai"] = new SelectList(lstTrangThai, "IdtrangThai", "TrangThai");
    var lstKho = await dbContext.Khos.ToListAsync();
    ViewData["lstKho"] = new SelectList(lstKho, "MaKho", "TenKho");
    var lstPhuongTien = await dbContext.PhuongTiens.ToListAsync();
    ViewData["lstPhuongTien"] = new SelectList(lstPhuongTien, "MaPhuongTien", "TenPhuongTien");
    var lstDonViTinh = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstDonViTinh"] = new SelectList(lstDonViTinh, "IdDonViTinh", "DonViTinh1");
    var lstTraiCay = await dbContext.TraiCays.ToListAsync();
    ViewData["lstTraiCay"] = new SelectList(lstTraiCay, "MaTraiCay", "TenTraiCay");
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> CreateLoHang([Bind("MaTraiCay,SoLuong,DonGia,MaHopDong,MaKho,IdDonViTinh,MaPhuongTien,IdtrangThai")] LoHang loHangCreate)
  {
    var loHang = new LoHang();
    if (loHang != null)
    {
      loHang.MaTraiCay = loHangCreate.MaTraiCay;
      loHang.SoLuong = loHangCreate.SoLuong;
      loHang.MaKho = loHangCreate.MaKho;
      loHang.IdDonViTinh = loHangCreate.IdDonViTinh;
      loHang.DonGia = loHangCreate.DonGia;
      loHang.MaPhuongTien = loHangCreate.MaPhuongTien;
      loHang.IdtrangThai = loHangCreate.IdtrangThai;
      loHang.MaHopDong = loHangCreate.MaHopDong;
      dbContext.Add(loHang);
      var hopDong = await dbContext.HopDongs.FindAsync(loHang.MaHopDong);
      if (hopDong.TongGia != null)
      {
        var giaMoi = loHang.DonGia != null ? loHang.DonGia : 0;
        hopDong.TongGia = hopDong.TongGia + giaMoi;
      }
      else
      {
        var giaMoi = loHang.DonGia != null ? loHang.DonGia : 0;
        hopDong.TongGia = giaMoi;
      }
      dbContext.Update(hopDong);
      await dbContext.SaveChangesAsync();
    }
    return RedirectToAction("Edit", new {id = loHang.MaHopDong});
  }
  [HttpPost]
  public async Task<IActionResult> DeleteLoHang(int id)
  {
    var loHang = await dbContext.LoHangs.FindAsync(id);
    dbContext.LoHangs.Remove(loHang);
    await dbContext.SaveChangesAsync();
    var responseData = new
    {
        message = "Thành công",
    };
    return Json(responseData);
  }

  public async Task<IActionResult> Delete(int id)
  {
    var hopDong = await dbContext.HopDongs.FindAsync(id);
    ViewData["hopDong"] = hopDong;
    var loaiHopDong = await dbContext.LoaiHopDongs.FindAsync(hopDong.IdloaiHopDong);
    ViewData["loaiHopDong"] = loaiHopDong;
    var nhanVien = await dbContext.NhanViens.FindAsync(hopDong.MaNhanVien);
    ViewData["nhanVien"] = nhanVien;
    ViewData["lstDoanhNghiep"] = await dbContext.DoanhNghieps.ToListAsync();
    ViewData["lstNhaCungCap"] = await dbContext.NhaCungCaps.ToListAsync();
    ViewData["lstTrangThai"] = await dbContext.TrangThaiHopDongs.ToListAsync();
    ViewData["lstLoHang"] = await dbContext.LoHangs.Where(item => item.MaHopDong == id).ToListAsync();
    ViewData["lstKho"] = await dbContext.Khos.ToListAsync();
    ViewData["lstPhuongTien"] = await dbContext.PhuongTiens.ToListAsync();
    ViewData["lstDonViTinh"] = await dbContext.DonViTinhs.ToListAsync();
    ViewData["lstTraiCay"] = await dbContext.TraiCays.ToListAsync();
    return View(hopDong);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id, [Bind("TenHopDong, NgayKy")] HopDong hopDongDelete)
  {
    var hopDong = await dbContext.HopDongs.FindAsync(id);
    var loHang = await dbContext.LoHangs.Where(item => item.MaHopDong == id).ToListAsync();
    if (hopDong != null)
    {
        dbContext.HopDongs.Remove(hopDong);
        dbContext.LoHangs.RemoveRange(loHang);
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

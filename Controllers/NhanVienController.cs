using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;

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

    return View();
  }

  public async Task<IActionResult> Detail(int id)
  {
    var nhanVien = await dbContext.NhanViens.Where(item => item.MaNhanVien == id).FirstOrDefaultAsync();
    ViewData["nhanVien"] = nhanVien;
    ViewData["boPhan"] = await dbContext.BoPhans.Where(item => item.IdboPhan == nhanVien.IdboPhan).FirstOrDefaultAsync();
    ViewData["trangThai"] = await dbContext.TrangThaiNhanViens.Where(item => item.IdtrangThai == nhanVien.IdtrangThai).FirstOrDefaultAsync();
    return View();
  }


}

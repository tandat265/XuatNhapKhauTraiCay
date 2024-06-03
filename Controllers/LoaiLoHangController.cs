// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using AspnetCoreMvcFull.Models;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;

// namespace AspnetCoreMvcFull.Controllers;

// public class LoaiLoHangController : Controller
// {
//   DbXuatNhapKhauContext dbContext;

//   public LoaiLoHangController(DbXuatNhapKhauContext dbContext)
//   {
//     this.dbContext = dbContext;
//   }
//   public async Task<IActionResult> Index()
//   {
//     ViewData["lstLoaiLoHang"] = await dbContext.LoaiLoHangs.ToListAsync();
//     return View();
//   }


//   [HttpPost]
//   public async Task<IActionResult> Edit(int id, string loailohang)
//   {
//     var loaiLoHang = await dbContext.LoaiLoHangs.FindAsync(id);
//     if (loaiLoHang != null)
//     {
//       loaiLoHang.LoaiLoHang1 = loailohang;
//       dbContext.Update(loaiLoHang);
//       await dbContext.SaveChangesAsync();
//     }
//     var responseData = new
//     {
//         message = "Thành công",
//     };
//     return Json(responseData);
//   }
//   [HttpPost]
//   public IActionResult Create(string loailohang)
//   {
//     var loaiLoHang = new LoaiLoHang();
//     loaiLoHang.LoaiLoHang1 = loailohang;
//     dbContext.Add(loaiLoHang);
//     dbContext.SaveChanges();
//     var responseData = new
//     {
//         message = "Thành công",
//     };
//     return Json(responseData);
//   }


//   [HttpPost]
//   public async Task<IActionResult> Delete(int id)
//   {
//     var loaiLoHang = await dbContext.LoaiLoHangs.FindAsync(id);
//     if (loaiLoHang != null)
//     {
//         dbContext.LoaiLoHangs.Remove(loaiLoHang);
//         await dbContext.SaveChangesAsync();
//     }
//     else
//     {
//         // Handle the case where the entity was not found in the database
//         ModelState.AddModelError("", "Nhân viên không tồn tại.");
//     }
//     var responseData = new
//     {
//         message = "Thành công",
//     };
//     return Json(responseData);
//   }
// }

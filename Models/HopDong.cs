using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class HopDong
{
    public int MaHopDong { get; set; }

    public string? TenHopDong { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaDoiTac { get; set; }

    public DateTime? NgayKy { get; set; }

    public double? TongGia { get; set; }

    public int? IdloaiHopDong { get; set; }

    public int? IdtrangThai { get; set; }

    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    public virtual LoaiHopDong? IdloaiHopDongNavigation { get; set; }

    public virtual TrangThaiHopDong? IdtrangThaiNavigation { get; set; }

    public virtual NhaCungCap? MaDoiTac1 { get; set; }

    public virtual DoanhNghiep? MaDoiTacNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}

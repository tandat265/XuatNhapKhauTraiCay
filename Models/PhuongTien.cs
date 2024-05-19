using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class PhuongTien
{
    public int MaPhuongTien { get; set; }

    public string? TenPhuongTien { get; set; }

    public int? IdloaiPhuongTien { get; set; }

    public int? IdtrangThai { get; set; }

    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    public virtual ICollection<DoanhNghiepPhuongTien> DoanhNghiepPhuongTiens { get; set; } = new List<DoanhNghiepPhuongTien>();

    public virtual LoaiPhuongTien? IdloaiPhuongTienNavigation { get; set; }

    public virtual TrangThaiPhuongTien? IdtrangThaiNavigation { get; set; }

    public virtual ICollection<KhoPhuongTien> KhoPhuongTiens { get; set; } = new List<KhoPhuongTien>();
}

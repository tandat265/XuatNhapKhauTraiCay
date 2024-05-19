using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class LoHang
{
    public int MaLoHang { get; set; }

    public int? MaTraiCay { get; set; }

    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public int? IdloaiLoHang { get; set; }

    public int? MaKho { get; set; }

    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    public virtual LoaiLoHang? IdloaiLoHangNavigation { get; set; }

    public virtual Kho? MaKhoNavigation { get; set; }

    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

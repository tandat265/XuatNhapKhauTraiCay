using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class ChiTietHopDong
{
    public int MaChiTietHopDong { get; set; }

    public int? MaHopDong { get; set; }

    public int? MaLoHang { get; set; }

    public int? MaPhuongTien { get; set; }

    public int? IdtrangThai { get; set; }

    public virtual TrangThaiHopDong? IdtrangThaiNavigation { get; set; }

    public virtual HopDong? MaHopDongNavigation { get; set; }

    public virtual LoHang? MaLoHangNavigation { get; set; }

    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }
}

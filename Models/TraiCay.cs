using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class TraiCay
{
    public int MaTraiCay { get; set; }

    public string? TenTraiCay { get; set; }

    public int? IdloaiTraiCay { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<ChiTietKho> ChiTietKhos { get; set; } = new List<ChiTietKho>();

    public virtual ICollection<GiaTraiCay> GiaTraiCays { get; set; } = new List<GiaTraiCay>();

    public virtual LoaiTraiCay? IdloaiTraiCayNavigation { get; set; }

    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();

    public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; } = new List<NhaCungCap>();
}

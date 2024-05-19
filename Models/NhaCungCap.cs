using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class NhaCungCap
{
    public int MaNhaCungCap { get; set; }

    public string? TenNhaCungCap { get; set; }

    public int? MaTraiCay { get; set; }

    public string? DiaChi { get; set; }

    public string? Sđt { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

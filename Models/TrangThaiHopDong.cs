using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class TrangThaiHopDong
{
    public int IdtrangThai { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();
}

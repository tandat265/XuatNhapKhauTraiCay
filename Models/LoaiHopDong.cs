using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class LoaiHopDong
{
    public int IdloaiHopDong { get; set; }

    public string? LoaiHopDong1 { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();
}

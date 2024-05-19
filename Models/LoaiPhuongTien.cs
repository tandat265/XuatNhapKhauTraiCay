using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class LoaiPhuongTien
{
    public int IdloaiPhuongTien { get; set; }

    public string? LoaiPhuongTien1 { get; set; }

    public virtual ICollection<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();
}

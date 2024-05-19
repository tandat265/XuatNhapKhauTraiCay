using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class TrangThaiPhuongTien
{
    public int IdtrangThai { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();
}

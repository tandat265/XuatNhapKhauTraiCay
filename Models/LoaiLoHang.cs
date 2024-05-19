using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class LoaiLoHang
{
    public int IdloaiLoHang { get; set; }

    public string? LoaiLoHang1 { get; set; }

    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();
}

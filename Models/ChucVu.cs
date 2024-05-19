using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class ChucVu
{
    public int IdChucVu { get; set; }

    public string? ChucVu1 { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}

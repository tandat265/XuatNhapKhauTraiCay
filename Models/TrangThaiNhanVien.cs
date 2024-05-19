using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class TrangThaiNhanVien
{
    public int IdtrangThai { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}

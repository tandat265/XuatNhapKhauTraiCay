using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class TrangThaiVanChuyen
{
    public int IdtrangThai { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<DoanhNghiepPhuongTien> DoanhNghiepPhuongTiens { get; set; } = new List<DoanhNghiepPhuongTien>();

    public virtual ICollection<KhoPhuongTien> KhoPhuongTiens { get; set; } = new List<KhoPhuongTien>();
}

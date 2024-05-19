using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class Kho
{
    public int MaKho { get; set; }

    public string? TenKho { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<ChiTietKho> ChiTietKhos { get; set; } = new List<ChiTietKho>();

    public virtual ICollection<KhoPhuongTien> KhoPhuongTiens { get; set; } = new List<KhoPhuongTien>();

    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();
}

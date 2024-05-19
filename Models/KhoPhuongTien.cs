using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class KhoPhuongTien
{
    public int IdkhoPhuongTien { get; set; }

    public int? MaKho { get; set; }

    public int? MaPhuongTien { get; set; }

    public int? IdtrangThai { get; set; }

    public virtual TrangThaiVanChuyen? IdtrangThaiNavigation { get; set; }

    public virtual Kho? MaKhoNavigation { get; set; }

    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }
}

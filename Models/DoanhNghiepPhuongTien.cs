using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class DoanhNghiepPhuongTien
{
    public int IddoanhNghiepPhuongTien { get; set; }

    public int? MaDoanhNghiep { get; set; }

    public int? MaPhuongTien { get; set; }

    public int? IdtrangThai { get; set; }

    public virtual TrangThaiVanChuyen? IdtrangThaiNavigation { get; set; }

    public virtual DoanhNghiep? MaDoanhNghiepNavigation { get; set; }

    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }
}

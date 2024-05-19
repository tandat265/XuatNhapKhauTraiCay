using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class GiaTraiCay
{
    public int MaGia { get; set; }

    public int? MaTraiCay { get; set; }

    public double? GiaTien { get; set; }

    public int? SoLuong { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

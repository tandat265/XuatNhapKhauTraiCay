using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class ChiTietKho
{
    public int MaChiTietKho { get; set; }

    public int? MaKho { get; set; }

    public int? MaTraiCay { get; set; }

    public int? SoLuong { get; set; }

    public virtual Kho? MaKhoNavigation { get; set; }

    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class DoanhNghiep
{
    public int MaDoanhNghiep { get; set; }

    public string? TenDoanhNghiep { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public int? MaQuocGia { get; set; }

    public virtual ICollection<DoanhNghiepPhuongTien> DoanhNghiepPhuongTiens { get; set; } = new List<DoanhNghiepPhuongTien>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual QuocGium? MaQuocGiaNavigation { get; set; }
}

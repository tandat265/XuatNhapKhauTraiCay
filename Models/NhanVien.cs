using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string? TenNhanVien { get; set; }

    public int? IdChucVu { get; set; }

    public int? IdboPhan { get; set; }

    public int? IdtrangThai { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Cccd { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ChucVu? IdChucVuNavigation { get; set; }

    public virtual BoPhan? IdboPhanNavigation { get; set; }

    public virtual TrangThaiNhanVien? IdtrangThaiNavigation { get; set; }
}

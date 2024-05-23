using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("NhanVien")]
public partial class NhanVien
{
    [Key]
    public int MaNhanVien { get; set; }

    [StringLength(50)]
    public string? TenNhanVien { get; set; }

    public int? IdChucVu { get; set; }

    [Column("IDBoPhan")]
    public int? IdboPhan { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("CCCD")]
    [StringLength(20)]
    public string? Cccd { get; set; }

    [StringLength(50)]
    public string? Address { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    [ForeignKey("IdChucVu")]
    [InverseProperty("NhanViens")]
    public virtual ChucVu? IdChucVuNavigation { get; set; }

    [ForeignKey("IdboPhan")]
    [InverseProperty("NhanViens")]
    public virtual BoPhan? IdboPhanNavigation { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("NhanViens")]
    public virtual TrangThaiNhanVien? IdtrangThaiNavigation { get; set; }
}

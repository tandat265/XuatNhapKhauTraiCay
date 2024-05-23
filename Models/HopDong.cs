using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("HopDong")]
public partial class HopDong
{
    [Key]
    public int MaHopDong { get; set; }

    [StringLength(50)]
    public string? TenHopDong { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaDoiTac { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayKy { get; set; }

    public double? TongGia { get; set; }

    [Column("IDLoaiHopDong")]
    public int? IdloaiHopDong { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [InverseProperty("MaHopDongNavigation")]
    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    [ForeignKey("IdloaiHopDong")]
    [InverseProperty("HopDongs")]
    public virtual LoaiHopDong? IdloaiHopDongNavigation { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("HopDongs")]
    public virtual TrangThaiHopDong? IdtrangThaiNavigation { get; set; }

    [ForeignKey("MaDoiTac")]
    [InverseProperty("HopDongs")]
    public virtual NhaCungCap? MaDoiTac1 { get; set; }

    [ForeignKey("MaDoiTac")]
    [InverseProperty("HopDongs")]
    public virtual DoanhNghiep? MaDoiTacNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("HopDongs")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}

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

    [ForeignKey("IdloaiHopDong")]
    [InverseProperty("HopDongs")]
    public virtual LoaiHopDong? IdloaiHopDongNavigation { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("HopDongs")]
    public virtual TrangThaiHopDong? IdtrangThaiNavigation { get; set; }

    [InverseProperty("MaHopDongNavigation")]
    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();

    [ForeignKey("MaNhanVien")]
    [InverseProperty("HopDongs")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}

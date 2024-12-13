using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("LoHang")]
public partial class LoHang
{
    [Key]
    public int MaLoHang { get; set; }

    public int? MaTraiCay { get; set; }

    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public int? MaKho { get; set; }

    public int? IdDonViTinh { get; set; }

    public int? MaHopDong { get; set; }

    public int? MaPhuongTien { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [ForeignKey("IdDonViTinh")]
    [InverseProperty("LoHangs")]
    public virtual DonViTinh? IdDonViTinhNavigation { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("LoHangs")]
    public virtual TrangThaiHopDong? IdtrangThaiNavigation { get; set; }

    [ForeignKey("MaHopDong")]
    [InverseProperty("LoHangs")]
    public virtual HopDong? MaHopDongNavigation { get; set; }

    [ForeignKey("MaKho")]
    [InverseProperty("LoHangs")]
    public virtual Kho? MaKhoNavigation { get; set; }

    [ForeignKey("MaPhuongTien")]
    [InverseProperty("LoHangs")]
    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }

    [ForeignKey("MaTraiCay")]
    [InverseProperty("LoHangs")]
    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

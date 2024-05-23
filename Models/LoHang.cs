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

    [Column("IDLoaiLoHang")]
    public int? IdloaiLoHang { get; set; }

    public int? MaKho { get; set; }

    [InverseProperty("MaLoHangNavigation")]
    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    [ForeignKey("IdloaiLoHang")]
    [InverseProperty("LoHangs")]
    public virtual LoaiLoHang? IdloaiLoHangNavigation { get; set; }

    [ForeignKey("MaKho")]
    [InverseProperty("LoHangs")]
    public virtual Kho? MaKhoNavigation { get; set; }

    [ForeignKey("MaTraiCay")]
    [InverseProperty("LoHangs")]
    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

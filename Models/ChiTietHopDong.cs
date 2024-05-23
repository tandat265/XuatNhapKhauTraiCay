using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("ChiTietHopDong")]
public partial class ChiTietHopDong
{
    [Key]
    public int MaChiTietHopDong { get; set; }

    public int? MaHopDong { get; set; }

    public int? MaLoHang { get; set; }

    public int? MaPhuongTien { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("ChiTietHopDongs")]
    public virtual TrangThaiHopDong? IdtrangThaiNavigation { get; set; }

    [ForeignKey("MaHopDong")]
    [InverseProperty("ChiTietHopDongs")]
    public virtual HopDong? MaHopDongNavigation { get; set; }

    [ForeignKey("MaLoHang")]
    [InverseProperty("ChiTietHopDongs")]
    public virtual LoHang? MaLoHangNavigation { get; set; }

    [ForeignKey("MaPhuongTien")]
    [InverseProperty("ChiTietHopDongs")]
    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }
}

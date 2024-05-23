using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("PhuongTien")]
public partial class PhuongTien
{
    [Key]
    public int MaPhuongTien { get; set; }

    [StringLength(50)]
    public string? TenPhuongTien { get; set; }

    [Column("IDLoaiPhuongTien")]
    public int? IdloaiPhuongTien { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [InverseProperty("MaPhuongTienNavigation")]
    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    [InverseProperty("MaPhuongTienNavigation")]
    public virtual ICollection<DoanhNghiepPhuongTien> DoanhNghiepPhuongTiens { get; set; } = new List<DoanhNghiepPhuongTien>();

    [ForeignKey("IdloaiPhuongTien")]
    [InverseProperty("PhuongTiens")]
    public virtual LoaiPhuongTien? IdloaiPhuongTienNavigation { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("PhuongTiens")]
    public virtual TrangThaiPhuongTien? IdtrangThaiNavigation { get; set; }

    [InverseProperty("MaPhuongTienNavigation")]
    public virtual ICollection<KhoPhuongTien> KhoPhuongTiens { get; set; } = new List<KhoPhuongTien>();
}

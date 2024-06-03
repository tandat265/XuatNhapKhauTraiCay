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

    [ForeignKey("IdloaiPhuongTien")]
    [InverseProperty("PhuongTiens")]
    public virtual LoaiPhuongTien? IdloaiPhuongTienNavigation { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("PhuongTiens")]
    public virtual TrangThaiPhuongTien? IdtrangThaiNavigation { get; set; }

    [InverseProperty("MaPhuongTienNavigation")]
    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();
}

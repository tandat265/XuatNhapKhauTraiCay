using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("TraiCay")]
public partial class TraiCay
{
    [Key]
    public int MaTraiCay { get; set; }

    [StringLength(50)]
    public string? TenTraiCay { get; set; }

    [Column("IDLoaiTraiCay")]
    public int? IdloaiTraiCay { get; set; }

    public string? MoTa { get; set; }

    [InverseProperty("MaTraiCayNavigation")]
    public virtual ICollection<ChiTietKho> ChiTietKhos { get; set; } = new List<ChiTietKho>();

    [InverseProperty("MaTraiCayNavigation")]
    public virtual ICollection<GiaTraiCay> GiaTraiCays { get; set; } = new List<GiaTraiCay>();

    [ForeignKey("IdloaiTraiCay")]
    [InverseProperty("TraiCays")]
    public virtual LoaiTraiCay? IdloaiTraiCayNavigation { get; set; }

    [InverseProperty("MaTraiCayNavigation")]
    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();

    [InverseProperty("MaTraiCayNavigation")]
    public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; } = new List<NhaCungCap>();
}

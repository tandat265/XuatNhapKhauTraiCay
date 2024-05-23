using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("TrangThaiHopDong")]
public partial class TrangThaiHopDong
{
    [Key]
    [Column("IDTrangThai")]
    public int IdtrangThai { get; set; }

    [StringLength(20)]
    public string? TrangThai { get; set; }

    [InverseProperty("IdtrangThaiNavigation")]
    public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; } = new List<ChiTietHopDong>();

    [InverseProperty("IdtrangThaiNavigation")]
    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();
}

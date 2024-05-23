using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("LoaiHopDong")]
public partial class LoaiHopDong
{
    [Key]
    [Column("IDLoaiHopDong")]
    public int IdloaiHopDong { get; set; }

    [Column("LoaiHopDong")]
    [StringLength(50)]
    public string? LoaiHopDong1 { get; set; }

    [InverseProperty("IdloaiHopDongNavigation")]
    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();
}

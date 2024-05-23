using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("LoaiTraiCay")]
public partial class LoaiTraiCay
{
    [Key]
    [Column("IDLoaiTraiCay")]
    public int IdloaiTraiCay { get; set; }

    [Column("LoaiTraiCay")]
    [StringLength(50)]
    public string? LoaiTraiCay1 { get; set; }

    [InverseProperty("IdloaiTraiCayNavigation")]
    public virtual ICollection<TraiCay> TraiCays { get; set; } = new List<TraiCay>();
}

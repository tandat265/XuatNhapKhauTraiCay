using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("LoaiPhuongTien")]
public partial class LoaiPhuongTien
{
    [Key]
    [Column("IDLoaiPhuongTien")]
    public int IdloaiPhuongTien { get; set; }

    [Column("LoaiPhuongTien")]
    [StringLength(50)]
    public string? LoaiPhuongTien1 { get; set; }

    [InverseProperty("IdloaiPhuongTienNavigation")]
    public virtual ICollection<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();
}

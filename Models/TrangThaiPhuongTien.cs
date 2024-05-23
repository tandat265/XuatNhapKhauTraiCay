using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("TrangThaiPhuongTien")]
public partial class TrangThaiPhuongTien
{
    [Key]
    [Column("IDTrangThai")]
    public int IdtrangThai { get; set; }

    [StringLength(20)]
    public string? TrangThai { get; set; }

    [InverseProperty("IdtrangThaiNavigation")]
    public virtual ICollection<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();
}

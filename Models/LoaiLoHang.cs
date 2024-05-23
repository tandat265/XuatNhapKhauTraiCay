using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("LoaiLoHang")]
public partial class LoaiLoHang
{
    [Key]
    [Column("IDLoaiLoHang")]
    public int IdloaiLoHang { get; set; }

    [Column("LoaiLoHang")]
    [StringLength(50)]
    public string? LoaiLoHang1 { get; set; }

    [InverseProperty("IdloaiLoHangNavigation")]
    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();
}

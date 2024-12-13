using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("NhaCungCap")]
public partial class NhaCungCap
{
    [Key]
    public int MaNhaCungCap { get; set; }

    [StringLength(50)]
    public string? TenNhaCungCap { get; set; }

    public int? MaTraiCay { get; set; }

    public string? DiaChi { get; set; }

    [Column("SĐT")]
    [StringLength(20)]
    public string? Sđt { get; set; }

    [ForeignKey("MaTraiCay")]
    [InverseProperty("NhaCungCaps")]
    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

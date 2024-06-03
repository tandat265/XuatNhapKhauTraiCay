using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("Kho")]
public partial class Kho
{
    [Key]
    public int MaKho { get; set; }

    [StringLength(50)]
    public string? TenKho { get; set; }

    public string? DiaChi { get; set; }

    [InverseProperty("MaKhoNavigation")]
    public virtual ICollection<ChiTietKho> ChiTietKhos { get; set; } = new List<ChiTietKho>();

    [InverseProperty("MaKhoNavigation")]
    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();
}

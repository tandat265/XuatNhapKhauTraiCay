using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("DonViTinh")]
public partial class DonViTinh
{
    [Key]
    public int IdDonViTinh { get; set; }

    [Column("DonViTinh")]
    [StringLength(20)]
    public string? DonViTinh1 { get; set; }

    [InverseProperty("IdDonViTinhNavigation")]
    public virtual ICollection<ChiTietKho> ChiTietKhos { get; set; } = new List<ChiTietKho>();

    [InverseProperty("IdDonViTinhNavigation")]
    public virtual ICollection<GiaTraiCay> GiaTraiCays { get; set; } = new List<GiaTraiCay>();

    [InverseProperty("IdDonViTinhNavigation")]
    public virtual ICollection<LoHang> LoHangs { get; set; } = new List<LoHang>();
}

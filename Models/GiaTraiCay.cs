using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("GiaTraiCay")]
public partial class GiaTraiCay
{
    [Key]
    public int MaGia { get; set; }

    public int? MaTraiCay { get; set; }

    public double? GiaTien { get; set; }

    public int? SoLuong { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayCapNhat { get; set; }

    public int? IdDonViTinh { get; set; }

    [ForeignKey("IdDonViTinh")]
    [InverseProperty("GiaTraiCays")]
    public virtual DonViTinh? IdDonViTinhNavigation { get; set; }

    [ForeignKey("MaTraiCay")]
    [InverseProperty("GiaTraiCays")]
    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

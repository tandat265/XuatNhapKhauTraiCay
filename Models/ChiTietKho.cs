using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("ChiTietKho")]
public partial class ChiTietKho
{
    [Key]
    public int MaChiTietKho { get; set; }

    public int? MaKho { get; set; }

    public int? MaTraiCay { get; set; }

    public int? SoLuong { get; set; }

    [ForeignKey("MaKho")]
    [InverseProperty("ChiTietKhos")]
    public virtual Kho? MaKhoNavigation { get; set; }

    [ForeignKey("MaTraiCay")]
    [InverseProperty("ChiTietKhos")]
    public virtual TraiCay? MaTraiCayNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("ChucVu")]
public partial class ChucVu
{
    [Key]
    public int IdChucVu { get; set; }

    [Column("ChucVu")]
    [StringLength(50)]
    public string? ChucVu1 { get; set; }

    [InverseProperty("IdChucVuNavigation")]
    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}

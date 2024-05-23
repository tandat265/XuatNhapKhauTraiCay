using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("TrangThaiNhanVien")]
public partial class TrangThaiNhanVien
{
    [Key]
    [Column("IDTrangThai")]
    public int IdtrangThai { get; set; }

    [StringLength(50)]
    public string? TrangThai { get; set; }

    [InverseProperty("IdtrangThaiNavigation")]
    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}

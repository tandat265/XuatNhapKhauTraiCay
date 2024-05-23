using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("TrangThaiVanChuyen")]
public partial class TrangThaiVanChuyen
{
    [Key]
    [Column("IDTrangThai")]
    public int IdtrangThai { get; set; }

    [StringLength(50)]
    public string? TrangThai { get; set; }

    [InverseProperty("IdtrangThaiNavigation")]
    public virtual ICollection<DoanhNghiepPhuongTien> DoanhNghiepPhuongTiens { get; set; } = new List<DoanhNghiepPhuongTien>();

    [InverseProperty("IdtrangThaiNavigation")]
    public virtual ICollection<KhoPhuongTien> KhoPhuongTiens { get; set; } = new List<KhoPhuongTien>();
}

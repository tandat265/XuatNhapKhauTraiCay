using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("DoanhNghiep_PhuongTien")]
public partial class DoanhNghiepPhuongTien
{
    [Key]
    [Column("IDDoanhNghiep_PhuongTien")]
    public int IddoanhNghiepPhuongTien { get; set; }

    public int? MaDoanhNghiep { get; set; }

    public int? MaPhuongTien { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("DoanhNghiepPhuongTiens")]
    public virtual TrangThaiVanChuyen? IdtrangThaiNavigation { get; set; }

    [ForeignKey("MaDoanhNghiep")]
    [InverseProperty("DoanhNghiepPhuongTiens")]
    public virtual DoanhNghiep? MaDoanhNghiepNavigation { get; set; }

    [ForeignKey("MaPhuongTien")]
    [InverseProperty("DoanhNghiepPhuongTiens")]
    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }
}

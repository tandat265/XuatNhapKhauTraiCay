using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("Kho_PhuongTien")]
public partial class KhoPhuongTien
{
    [Key]
    [Column("IDKho_PhuongTien")]
    public int IdkhoPhuongTien { get; set; }

    public int? MaKho { get; set; }

    public int? MaPhuongTien { get; set; }

    [Column("IDTrangThai")]
    public int? IdtrangThai { get; set; }

    [ForeignKey("IdtrangThai")]
    [InverseProperty("KhoPhuongTiens")]
    public virtual TrangThaiVanChuyen? IdtrangThaiNavigation { get; set; }

    [ForeignKey("MaKho")]
    [InverseProperty("KhoPhuongTiens")]
    public virtual Kho? MaKhoNavigation { get; set; }

    [ForeignKey("MaPhuongTien")]
    [InverseProperty("KhoPhuongTiens")]
    public virtual PhuongTien? MaPhuongTienNavigation { get; set; }
}

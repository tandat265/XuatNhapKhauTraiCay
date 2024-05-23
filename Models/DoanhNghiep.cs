using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("DoanhNghiep")]
public partial class DoanhNghiep
{
    [Key]
    public int MaDoanhNghiep { get; set; }

    [StringLength(50)]
    public string? TenDoanhNghiep { get; set; }

    public string? DiaChi { get; set; }

    [Column("SDT")]
    [StringLength(20)]
    public string? Sdt { get; set; }

    public int? MaQuocGia { get; set; }

    [InverseProperty("MaDoanhNghiepNavigation")]
    public virtual ICollection<DoanhNghiepPhuongTien> DoanhNghiepPhuongTiens { get; set; } = new List<DoanhNghiepPhuongTien>();

    [InverseProperty("MaDoiTacNavigation")]
    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    [ForeignKey("MaQuocGia")]
    [InverseProperty("DoanhNghieps")]
    public virtual QuocGium? MaQuocGiaNavigation { get; set; }
}

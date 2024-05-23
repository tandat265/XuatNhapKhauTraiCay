using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

public partial class QuocGium
{
    [Key]
    public int MaQuocGia { get; set; }

    [StringLength(50)]
    public string? TenQuocGia { get; set; }

    [InverseProperty("MaQuocGiaNavigation")]
    public virtual ICollection<DoanhNghiep> DoanhNghieps { get; set; } = new List<DoanhNghiep>();
}

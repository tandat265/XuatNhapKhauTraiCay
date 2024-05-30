using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Keyless]
public partial class ViewChiTietKho
{
    [StringLength(203)]
    public string ViewPrimaryKey { get; set; } = null!;

    [StringLength(50)]
    public string? TenKho { get; set; }

    public string? DiaChi { get; set; }

    [StringLength(20)]
    public string? DonViTinh { get; set; }

    public int MaChiTietKho { get; set; }

    public int MaKho { get; set; }

    public int IdDonViTinh { get; set; }

    public int MaTraiCay { get; set; }

    [StringLength(50)]
    public string? TenTraiCay { get; set; }

    public int? SoLuong { get; set; }
}

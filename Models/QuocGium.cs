using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class QuocGium
{
    public int MaQuocGia { get; set; }

    public string? TenQuocGia { get; set; }

    public virtual ICollection<DoanhNghiep> DoanhNghieps { get; set; } = new List<DoanhNghiep>();
}

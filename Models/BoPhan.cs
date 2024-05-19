using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class BoPhan
{
    public int IdboPhan { get; set; }

    public string? TenBoPhan { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}

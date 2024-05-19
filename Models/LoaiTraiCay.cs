using System;
using System.Collections.Generic;

namespace AspnetCoreMvcFull.Models;

public partial class LoaiTraiCay
{
    public int IdloaiTraiCay { get; set; }

    public string? LoaiTraiCay1 { get; set; }

    public virtual ICollection<TraiCay> TraiCays { get; set; } = new List<TraiCay>();
}

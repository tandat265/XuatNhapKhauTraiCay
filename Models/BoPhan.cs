using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Models;

[Table("BoPhan")]
public partial class BoPhan
{
    [Key]
    [Column("IDBoPhan")]
    public int IdboPhan { get; set; }

    [StringLength(50)]
    public string? TenBoPhan { get; set; }

    [InverseProperty("IdboPhanNavigation")]
    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}

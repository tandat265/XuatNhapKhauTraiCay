// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;

// namespace AspnetCoreMvcFull.Models;

// public partial class BaseDbContext : DbContext
// {
//   public BaseDbContext()
//   {
//   }

//   public BaseDbContext(DbContextOptions<DbContext> options)
//       : base(options)
//   {
//   }

//     public virtual DbSet<BoPhan> BoPhans { get; set; }

//     public virtual DbSet<ChiTietKho> ChiTietKhos { get; set; }

//     public virtual DbSet<ChucVu> ChucVus { get; set; }

//     public virtual DbSet<DoanhNghiep> DoanhNghieps { get; set; }

//     public virtual DbSet<GiaTraiCay> GiaTraiCays { get; set; }

//     public virtual DbSet<HopDong> HopDongs { get; set; }

//     public virtual DbSet<Kho> Khos { get; set; }

//     public virtual DbSet<LoHang> LoHangs { get; set; }

//     public virtual DbSet<LoaiHopDong> LoaiHopDongs { get; set; }

//     public virtual DbSet<LoaiPhuongTien> LoaiPhuongTiens { get; set; }

//     public virtual DbSet<LoaiTraiCay> LoaiTraiCays { get; set; }

//     public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

//     public virtual DbSet<NhanVien> NhanViens { get; set; }

//     public virtual DbSet<PhuongTien> PhuongTiens { get; set; }

//     public virtual DbSet<QuocGium> QuocGia { get; set; }

//     public virtual DbSet<TraiCay> TraiCays { get; set; }

//     public virtual DbSet<TrangThaiHopDong> TrangThaiHopDongs { get; set; }

//     public virtual DbSet<TrangThaiNhanVien> TrangThaiNhanViens { get; set; }

//     public virtual DbSet<TrangThaiPhuongTien> TrangThaiPhuongTiens { get; set; }


//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=DESKTOP-1A0DHPA;Database=dbXuatNhapKhau;Persist Security Info=False;user id=test1;password=@Abc123; Encrypt=False");

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<BoPhan>(entity =>
//         {
//             entity.HasKey(e => e.IdboPhan).HasName("PK__BoPhan__0E503FF5B251FB90");

//             entity.ToTable("BoPhan");

//             entity.Property(e => e.IdboPhan).HasColumnName("IDBoPhan");
//             entity.Property(e => e.TenBoPhan).HasMaxLength(50);
//         });

//         modelBuilder.Entity<ChiTietHopDong>(entity =>
//         {
//             entity.HasKey(e => e.MaChiTietHopDong).HasName("PK__ChiTietH__0DA24B73CD4ACACF");

//             entity.ToTable("ChiTietHopDong");

//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");

//             entity.HasOne(d => d.IdtrangThaiNavigation).WithMany(p => p.ChiTietHopDongs)
//                 .HasForeignKey(d => d.IdtrangThai)
//                 .HasConstraintName("FK_ChiTietHopDong_TrangThaiHopDong");

//             entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.ChiTietHopDongs)
//                 .HasForeignKey(d => d.MaHopDong)
//                 .HasConstraintName("FK_ChiTietHopDong_HopDong");

//             entity.HasOne(d => d.MaLoHangNavigation).WithMany(p => p.ChiTietHopDongs)
//                 .HasForeignKey(d => d.MaLoHang)
//                 .HasConstraintName("FK_ChiTietHopDong_LoHang");

//             entity.HasOne(d => d.MaPhuongTienNavigation).WithMany(p => p.ChiTietHopDongs)
//                 .HasForeignKey(d => d.MaPhuongTien)
//                 .HasConstraintName("FK_ChiTietHopDong_PhuongTien");
//         });

//         modelBuilder.Entity<ChiTietKho>(entity =>
//         {
//             entity.HasKey(e => e.MaChiTietKho).HasName("PK__ChiTietK__CE8258691EEA90BB");

//             entity.ToTable("ChiTietKho");

//             entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.ChiTietKhos)
//                 .HasForeignKey(d => d.MaKho)
//                 .HasConstraintName("FK_ChiTietKho_Kho");

//             entity.HasOne(d => d.MaTraiCayNavigation).WithMany(p => p.ChiTietKhos)
//                 .HasForeignKey(d => d.MaTraiCay)
//                 .HasConstraintName("FK_ChiTietKho_TraiCay");
//         });

//         modelBuilder.Entity<ChucVu>(entity =>
//         {
//             entity.HasKey(e => e.IdChucVu);

//             entity.ToTable("ChucVu");

//             entity.Property(e => e.IdChucVu).ValueGeneratedNever();
//             entity.Property(e => e.ChucVu1)
//                 .HasMaxLength(50)
//                 .IsFixedLength()
//                 .HasColumnName("ChucVu");
//         });

//         modelBuilder.Entity<DoanhNghiep>(entity =>
//         {
//             entity.HasKey(e => e.MaDoanhNghiep).HasName("PK__DoanhNgh__4D184EF6AE6A84B7");

//             entity.ToTable("DoanhNghiep");

//             entity.Property(e => e.Sdt)
//                 .HasMaxLength(20)
//                 .HasColumnName("SDT");
//             entity.Property(e => e.TenDoanhNghiep).HasMaxLength(50);

//             entity.HasOne(d => d.MaQuocGiaNavigation).WithMany(p => p.DoanhNghieps)
//                 .HasForeignKey(d => d.MaQuocGia)
//                 .HasConstraintName("FK_DoanhNghiep_QuocGia");
//         });

//         modelBuilder.Entity<DoanhNghiepPhuongTien>(entity =>
//         {
//             entity.HasKey(e => e.IddoanhNghiepPhuongTien);

//             entity.ToTable("DoanhNghiep_PhuongTien");

//             entity.Property(e => e.IddoanhNghiepPhuongTien).HasColumnName("IDDoanhNghiep_PhuongTien");
//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");

//             entity.HasOne(d => d.IdtrangThaiNavigation).WithMany(p => p.DoanhNghiepPhuongTiens)
//                 .HasForeignKey(d => d.IdtrangThai)
//                 .HasConstraintName("FK_DoanhNghiep_PhuongTien_TrangThaiVanChuyen");

//             entity.HasOne(d => d.MaDoanhNghiepNavigation).WithMany(p => p.DoanhNghiepPhuongTiens)
//                 .HasForeignKey(d => d.MaDoanhNghiep)
//                 .HasConstraintName("FK_DoanhNghiep_PhuongTien_DoanhNghiep");

//             entity.HasOne(d => d.MaPhuongTienNavigation).WithMany(p => p.DoanhNghiepPhuongTiens)
//                 .HasForeignKey(d => d.MaPhuongTien)
//                 .HasConstraintName("FK_DoanhNghiep_PhuongTien_PhuongTien");
//         });

//         modelBuilder.Entity<GiaTraiCay>(entity =>
//         {
//             entity.HasKey(e => e.MaGia).HasName("PK__tbGiaTra__3CD3DE5E63B5CA82");

//             entity.ToTable("GiaTraiCay");

//             entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

//             entity.HasOne(d => d.MaTraiCayNavigation).WithMany(p => p.GiaTraiCays)
//                 .HasForeignKey(d => d.MaTraiCay)
//                 .HasConstraintName("FK_GiaTraiCay_TraiCay");
//         });

//         modelBuilder.Entity<HopDong>(entity =>
//         {
//             entity.HasKey(e => e.MaHopDong).HasName("PK__HopDong__36DD434222A7A746");

//             entity.ToTable("HopDong");

//             entity.Property(e => e.IdloaiHopDong).HasColumnName("IDLoaiHopDong");
//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.NgayKy).HasColumnType("datetime");
//             entity.Property(e => e.TenHopDong).HasMaxLength(50);

//             entity.HasOne(d => d.IdloaiHopDongNavigation).WithMany(p => p.HopDongs)
//                 .HasForeignKey(d => d.IdloaiHopDong)
//                 .HasConstraintName("FK_HopDong_LoaiHopDong");

//             entity.HasOne(d => d.IdtrangThaiNavigation).WithMany(p => p.HopDongs)
//                 .HasForeignKey(d => d.IdtrangThai)
//                 .HasConstraintName("FK_HopDong_TrangThaiHopDong");

//             entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.HopDongs)
//                 .HasForeignKey(d => d.MaDoiTac)
//                 .HasConstraintName("FK_HopDong_DoanhNghiep");

//             entity.HasOne(d => d.MaDoiTac1).WithMany(p => p.HopDongs)
//                 .HasForeignKey(d => d.MaDoiTac)
//                 .HasConstraintName("FK_HopDong_NhaCungCap");

//             entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HopDongs)
//                 .HasForeignKey(d => d.MaNhanVien)
//                 .HasConstraintName("FK_HopDong_NhanVien");
//         });

//         modelBuilder.Entity<Kho>(entity =>
//         {
//             entity.HasKey(e => e.MaKho).HasName("PK__Kho__3BDA93503DC9AB2D");

//             entity.ToTable("Kho");

//             entity.Property(e => e.TenKho).HasMaxLength(50);
//         });

//         modelBuilder.Entity<KhoPhuongTien>(entity =>
//         {
//             entity.HasKey(e => e.IdkhoPhuongTien);

//             entity.ToTable("Kho_PhuongTien");

//             entity.Property(e => e.IdkhoPhuongTien).HasColumnName("IDKho_PhuongTien");
//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");

//             entity.HasOne(d => d.IdtrangThaiNavigation).WithMany(p => p.KhoPhuongTiens)
//                 .HasForeignKey(d => d.IdtrangThai)
//                 .HasConstraintName("FK_Kho_PhuongTien_TrangThaiVanChuyen");

//             entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.KhoPhuongTiens)
//                 .HasForeignKey(d => d.MaKho)
//                 .HasConstraintName("FK_Kho_PhuongTien_Kho");

//             entity.HasOne(d => d.MaPhuongTienNavigation).WithMany(p => p.KhoPhuongTiens)
//                 .HasForeignKey(d => d.MaPhuongTien)
//                 .HasConstraintName("FK_Kho_PhuongTien_PhuongTien");
//         });

//         modelBuilder.Entity<LoHang>(entity =>
//         {
//             entity.HasKey(e => e.MaLoHang).HasName("PK__tbLoHang__E81C10B22CE99985");

//             entity.ToTable("LoHang");

//             entity.Property(e => e.IdloaiLoHang).HasColumnName("IDLoaiLoHang");

//             entity.HasOne(d => d.IdloaiLoHangNavigation).WithMany(p => p.LoHangs)
//                 .HasForeignKey(d => d.IdloaiLoHang)
//                 .HasConstraintName("FK_LoHang_LoaiLoHang");

//             entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.LoHangs)
//                 .HasForeignKey(d => d.MaKho)
//                 .HasConstraintName("FK_LoHang_Kho");

//             entity.HasOne(d => d.MaTraiCayNavigation).WithMany(p => p.LoHangs)
//                 .HasForeignKey(d => d.MaTraiCay)
//                 .HasConstraintName("FK_LoHang_TraiCay");
//         });

//         modelBuilder.Entity<LoaiHopDong>(entity =>
//         {
//             entity.HasKey(e => e.IdloaiHopDong).HasName("PK__LoaiHopD__6C2A0CFF78795BF3");

//             entity.ToTable("LoaiHopDong");

//             entity.Property(e => e.IdloaiHopDong).HasColumnName("IDLoaiHopDong");
//             entity.Property(e => e.LoaiHopDong1)
//                 .HasMaxLength(50)
//                 .HasColumnName("LoaiHopDong");
//         });

//         modelBuilder.Entity<LoaiLoHang>(entity =>
//         {
//             entity.HasKey(e => e.IdloaiLoHang).HasName("PK__LoaiLoHa__FF67698FC02BA55C");

//             entity.ToTable("LoaiLoHang");

//             entity.Property(e => e.IdloaiLoHang).HasColumnName("IDLoaiLoHang");
//             entity.Property(e => e.LoaiLoHang1)
//                 .HasMaxLength(50)
//                 .HasColumnName("LoaiLoHang");
//         });

//         modelBuilder.Entity<LoaiPhuongTien>(entity =>
//         {
//             entity.HasKey(e => e.IdloaiPhuongTien).HasName("PK__LoaiPhuo__DE3BD94816B8F0CB");

//             entity.ToTable("LoaiPhuongTien");

//             entity.Property(e => e.IdloaiPhuongTien).HasColumnName("IDLoaiPhuongTien");
//             entity.Property(e => e.LoaiPhuongTien1)
//                 .HasMaxLength(50)
//                 .HasColumnName("LoaiPhuongTien");
//         });

//         modelBuilder.Entity<LoaiTraiCay>(entity =>
//         {
//             entity.HasKey(e => e.IdloaiTraiCay).HasName("PK_tbLoaiTraiCay");

//             entity.ToTable("LoaiTraiCay");

//             entity.Property(e => e.IdloaiTraiCay).HasColumnName("IDLoaiTraiCay");
//             entity.Property(e => e.LoaiTraiCay1)
//                 .HasMaxLength(50)
//                 .HasColumnName("LoaiTraiCay");
//         });

//         modelBuilder.Entity<NhaCungCap>(entity =>
//         {
//             entity.HasKey(e => e.MaNhaCungCap).HasName("PK__tbNhaCun__53DA9205F1817270");

//             entity.ToTable("NhaCungCap");

//             entity.Property(e => e.Sđt)
//                 .HasMaxLength(20)
//                 .HasColumnName("SĐT");
//             entity.Property(e => e.TenNhaCungCap).HasMaxLength(50);

//             entity.HasOne(d => d.MaTraiCayNavigation).WithMany(p => p.NhaCungCaps)
//                 .HasForeignKey(d => d.MaTraiCay)
//                 .HasConstraintName("FK_NhaCungCap_TraiCay");
//         });

//         modelBuilder.Entity<NhanVien>(entity =>
//         {
//             entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47FC631E71");

//             entity.ToTable("NhanVien");

//             entity.Property(e => e.Address).HasMaxLength(50);
//             entity.Property(e => e.Cccd)
//                 .HasMaxLength(20)
//                 .IsFixedLength()
//                 .HasColumnName("CCCD");
//             entity.Property(e => e.Email).HasMaxLength(50);
//             entity.Property(e => e.IdboPhan).HasColumnName("IDBoPhan");
//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.Phone)
//                 .HasMaxLength(20)
//                 .IsFixedLength();
//             entity.Property(e => e.TenNhanVien).HasMaxLength(50);

//             entity.HasOne(d => d.IdChucVuNavigation).WithMany(p => p.NhanViens)
//                 .HasForeignKey(d => d.IdChucVu)
//                 .HasConstraintName("FK_NhanVien_ChucVu");

//             entity.HasOne(d => d.IdboPhanNavigation).WithMany(p => p.NhanViens)
//                 .HasForeignKey(d => d.IdboPhan)
//                 .HasConstraintName("FK_NhanVien_BoPhan");

//             entity.HasOne(d => d.IdtrangThaiNavigation).WithMany(p => p.NhanViens)
//                 .HasForeignKey(d => d.IdtrangThai)
//                 .HasConstraintName("FK_NhanVien_TrangThaiNhanVien");
//         });

//         modelBuilder.Entity<PhuongTien>(entity =>
//         {
//             entity.HasKey(e => e.MaPhuongTien).HasName("PK__PhuongTi__35B6C8B05D44C42F");

//             entity.ToTable("PhuongTien");

//             entity.Property(e => e.IdloaiPhuongTien).HasColumnName("IDLoaiPhuongTien");
//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.TenPhuongTien).HasMaxLength(50);

//             entity.HasOne(d => d.IdloaiPhuongTienNavigation).WithMany(p => p.PhuongTiens)
//                 .HasForeignKey(d => d.IdloaiPhuongTien)
//                 .HasConstraintName("FK_PhuongTien_LoaiPhuongTien");

//             entity.HasOne(d => d.IdtrangThaiNavigation).WithMany(p => p.PhuongTiens)
//                 .HasForeignKey(d => d.IdtrangThai)
//                 .HasConstraintName("FK_PhuongTien_TrangThaiPhuongTien");
//         });

//         modelBuilder.Entity<QuocGium>(entity =>
//         {
//             entity.HasKey(e => e.MaQuocGia).HasName("PK__QuocGia__30D69ACB5D4E9DF4");

//             entity.Property(e => e.TenQuocGia).HasMaxLength(50);
//         });

//         modelBuilder.Entity<TraiCay>(entity =>
//         {
//             entity.HasKey(e => e.MaTraiCay).HasName("PK_tbTraiCay");

//             entity.ToTable("TraiCay");

//             entity.Property(e => e.IdloaiTraiCay).HasColumnName("IDLoaiTraiCay");
//             entity.Property(e => e.TenTraiCay).HasMaxLength(50);

//             entity.HasOne(d => d.IdloaiTraiCayNavigation).WithMany(p => p.TraiCays)
//                 .HasForeignKey(d => d.IdloaiTraiCay)
//                 .HasConstraintName("FK_TraiCay_LoaiTraiCay");
//         });

//         modelBuilder.Entity<TrangThaiHopDong>(entity =>
//         {
//             entity.HasKey(e => e.IdtrangThai).HasName("PK__TrangTha__556586008AD2E149");

//             entity.ToTable("TrangThaiHopDong");

//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.TrangThai).HasMaxLength(20);
//         });

//         modelBuilder.Entity<TrangThaiNhanVien>(entity =>
//         {
//             entity.HasKey(e => e.IdtrangThai);

//             entity.ToTable("TrangThaiNhanVien");

//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.TrangThai).HasMaxLength(50);
//         });

//         modelBuilder.Entity<TrangThaiPhuongTien>(entity =>
//         {
//             entity.HasKey(e => e.IdtrangThai).HasName("PK__TrangTha__55658600F9E73C5A");

//             entity.ToTable("TrangThaiPhuongTien");

//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.TrangThai).HasMaxLength(20);
//         });

//         modelBuilder.Entity<TrangThaiVanChuyen>(entity =>
//         {
//             entity.HasKey(e => e.IdtrangThai);

//             entity.ToTable("TrangThaiVanChuyen");

//             entity.Property(e => e.IdtrangThai).HasColumnName("IDTrangThai");
//             entity.Property(e => e.TrangThai)
//                 .HasMaxLength(50)
//                 .IsFixedLength();
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }

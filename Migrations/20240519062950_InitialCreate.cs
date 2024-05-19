using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcFull.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoPhan",
                columns: table => new
                {
                    IDBoPhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoPhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BoPhan__0E503FF5B251FB90", x => x.IDBoPhan);
                });

            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    MaKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kho__3BDA93503DC9AB2D", x => x.MaKho);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHopDong",
                columns: table => new
                {
                    IDLoaiHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiHopDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiHopD__6C2A0CFF78795BF3", x => x.IDLoaiHopDong);
                });

            migrationBuilder.CreateTable(
                name: "LoaiLoHang",
                columns: table => new
                {
                    IDLoaiLoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiLoHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiLoHa__FF67698FC02BA55C", x => x.IDLoaiLoHang);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhuongTien",
                columns: table => new
                {
                    IDLoaiPhuongTien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhuongTien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiPhuo__DE3BD94816B8F0CB", x => x.IDLoaiPhuongTien);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTraiCay",
                columns: table => new
                {
                    IDLoaiTraiCay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiTraiCay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLoaiTraiCay", x => x.IDLoaiTraiCay);
                });

            migrationBuilder.CreateTable(
                name: "QuocGia",
                columns: table => new
                {
                    MaQuocGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuocGia__30D69ACB5D4E9DF4", x => x.MaQuocGia);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiHopDong",
                columns: table => new
                {
                    IDTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TrangTha__556586008AD2E149", x => x.IDTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiNhanVien",
                columns: table => new
                {
                    IDTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiNhanVien", x => x.IDTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiPhuongTien",
                columns: table => new
                {
                    IDTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TrangTha__55658600F9E73C5A", x => x.IDTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiVanChuyen",
                columns: table => new
                {
                    IDTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiVanChuyen", x => x.IDTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "TraiCay",
                columns: table => new
                {
                    MaTraiCay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTraiCay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDLoaiTraiCay = table.Column<int>(type: "int", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTraiCay", x => x.MaTraiCay);
                    table.ForeignKey(
                        name: "FK_TraiCay_LoaiTraiCay",
                        column: x => x.IDLoaiTraiCay,
                        principalTable: "LoaiTraiCay",
                        principalColumn: "IDLoaiTraiCay");
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghiep",
                columns: table => new
                {
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoanhNghiep = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaQuocGia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DoanhNgh__4D184EF6AE6A84B7", x => x.MaDoanhNghiep);
                    table.ForeignKey(
                        name: "FK_DoanhNghiep_QuocGia",
                        column: x => x.MaQuocGia,
                        principalTable: "QuocGia",
                        principalColumn: "MaQuocGia");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IDBoPhan = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA47FC631E71", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_BoPhan",
                        column: x => x.IDBoPhan,
                        principalTable: "BoPhan",
                        principalColumn: "IDBoPhan");
                    table.ForeignKey(
                        name: "FK_NhanVien_TrangThaiNhanVien",
                        column: x => x.IDTrangThai,
                        principalTable: "TrangThaiNhanVien",
                        principalColumn: "IDTrangThai");
                });

            migrationBuilder.CreateTable(
                name: "PhuongTien",
                columns: table => new
                {
                    MaPhuongTien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhuongTien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDLoaiPhuongTien = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhuongTi__35B6C8B05D44C42F", x => x.MaPhuongTien);
                    table.ForeignKey(
                        name: "FK_PhuongTien_LoaiPhuongTien",
                        column: x => x.IDLoaiPhuongTien,
                        principalTable: "LoaiPhuongTien",
                        principalColumn: "IDLoaiPhuongTien");
                    table.ForeignKey(
                        name: "FK_PhuongTien_TrangThaiPhuongTien",
                        column: x => x.IDTrangThai,
                        principalTable: "TrangThaiPhuongTien",
                        principalColumn: "IDTrangThai");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKho",
                columns: table => new
                {
                    MaChiTietKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    MaTraiCay = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietK__CE8258691EEA90BB", x => x.MaChiTietKho);
                    table.ForeignKey(
                        name: "FK_ChiTietKho_Kho",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho");
                    table.ForeignKey(
                        name: "FK_ChiTietKho_TraiCay",
                        column: x => x.MaTraiCay,
                        principalTable: "TraiCay",
                        principalColumn: "MaTraiCay");
                });

            migrationBuilder.CreateTable(
                name: "GiaTraiCay",
                columns: table => new
                {
                    MaGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTraiCay = table.Column<int>(type: "int", nullable: true),
                    GiaTien = table.Column<double>(type: "float", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbGiaTra__3CD3DE5E63B5CA82", x => x.MaGia);
                    table.ForeignKey(
                        name: "FK_GiaTraiCay_TraiCay",
                        column: x => x.MaTraiCay,
                        principalTable: "TraiCay",
                        principalColumn: "MaTraiCay");
                });

            migrationBuilder.CreateTable(
                name: "LoHang",
                columns: table => new
                {
                    MaLoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTraiCay = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    IDLoaiLoHang = table.Column<int>(type: "int", nullable: true),
                    MaKho = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbLoHang__E81C10B22CE99985", x => x.MaLoHang);
                    table.ForeignKey(
                        name: "FK_LoHang_Kho",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho");
                    table.ForeignKey(
                        name: "FK_LoHang_LoaiLoHang",
                        column: x => x.IDLoaiLoHang,
                        principalTable: "LoaiLoHang",
                        principalColumn: "IDLoaiLoHang");
                    table.ForeignKey(
                        name: "FK_LoHang_TraiCay",
                        column: x => x.MaTraiCay,
                        principalTable: "TraiCay",
                        principalColumn: "MaTraiCay");
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    MaNhaCungCap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaTraiCay = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SĐT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbNhaCun__53DA9205F1817270", x => x.MaNhaCungCap);
                    table.ForeignKey(
                        name: "FK_NhaCungCap_TraiCay",
                        column: x => x.MaTraiCay,
                        principalTable: "TraiCay",
                        principalColumn: "MaTraiCay");
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghiep_PhuongTien",
                columns: table => new
                {
                    IDDoanhNghiep_PhuongTien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: true),
                    MaPhuongTien = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiep_PhuongTien", x => x.IDDoanhNghiep_PhuongTien);
                    table.ForeignKey(
                        name: "FK_DoanhNghiep_PhuongTien_DoanhNghiep",
                        column: x => x.MaDoanhNghiep,
                        principalTable: "DoanhNghiep",
                        principalColumn: "MaDoanhNghiep");
                    table.ForeignKey(
                        name: "FK_DoanhNghiep_PhuongTien_PhuongTien",
                        column: x => x.MaPhuongTien,
                        principalTable: "PhuongTien",
                        principalColumn: "MaPhuongTien");
                    table.ForeignKey(
                        name: "FK_DoanhNghiep_PhuongTien_TrangThaiVanChuyen",
                        column: x => x.IDTrangThai,
                        principalTable: "TrangThaiVanChuyen",
                        principalColumn: "IDTrangThai");
                });

            migrationBuilder.CreateTable(
                name: "Kho_PhuongTien",
                columns: table => new
                {
                    IDKho_PhuongTien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    MaPhuongTien = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kho_PhuongTien", x => x.IDKho_PhuongTien);
                    table.ForeignKey(
                        name: "FK_Kho_PhuongTien_Kho",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho");
                    table.ForeignKey(
                        name: "FK_Kho_PhuongTien_PhuongTien",
                        column: x => x.MaPhuongTien,
                        principalTable: "PhuongTien",
                        principalColumn: "MaPhuongTien");
                    table.ForeignKey(
                        name: "FK_Kho_PhuongTien_TrangThaiVanChuyen",
                        column: x => x.IDTrangThai,
                        principalTable: "TrangThaiVanChuyen",
                        principalColumn: "IDTrangThai");
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    MaHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHopDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    MaDoiTac = table.Column<int>(type: "int", nullable: true),
                    NgayKy = table.Column<DateTime>(type: "datetime", nullable: true),
                    TongGia = table.Column<double>(type: "float", nullable: true),
                    IDLoaiHopDong = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HopDong__36DD434222A7A746", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK_HopDong_DoanhNghiep",
                        column: x => x.MaDoiTac,
                        principalTable: "DoanhNghiep",
                        principalColumn: "MaDoanhNghiep");
                    table.ForeignKey(
                        name: "FK_HopDong_LoaiHopDong",
                        column: x => x.IDLoaiHopDong,
                        principalTable: "LoaiHopDong",
                        principalColumn: "IDLoaiHopDong");
                    table.ForeignKey(
                        name: "FK_HopDong_NhaCungCap",
                        column: x => x.MaDoiTac,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNhaCungCap");
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                    table.ForeignKey(
                        name: "FK_HopDong_TrangThaiHopDong",
                        column: x => x.IDTrangThai,
                        principalTable: "TrangThaiHopDong",
                        principalColumn: "IDTrangThai");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHopDong",
                columns: table => new
                {
                    MaChiTietHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHopDong = table.Column<int>(type: "int", nullable: true),
                    MaLoHang = table.Column<int>(type: "int", nullable: true),
                    MaPhuongTien = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietH__0DA24B73CD4ACACF", x => x.MaChiTietHopDong);
                    table.ForeignKey(
                        name: "FK_ChiTietHopDong_HopDong",
                        column: x => x.MaHopDong,
                        principalTable: "HopDong",
                        principalColumn: "MaHopDong");
                    table.ForeignKey(
                        name: "FK_ChiTietHopDong_LoHang",
                        column: x => x.MaLoHang,
                        principalTable: "LoHang",
                        principalColumn: "MaLoHang");
                    table.ForeignKey(
                        name: "FK_ChiTietHopDong_PhuongTien",
                        column: x => x.MaPhuongTien,
                        principalTable: "PhuongTien",
                        principalColumn: "MaPhuongTien");
                    table.ForeignKey(
                        name: "FK_ChiTietHopDong_TrangThaiHopDong",
                        column: x => x.IDTrangThai,
                        principalTable: "TrangThaiHopDong",
                        principalColumn: "IDTrangThai");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHopDong_IDTrangThai",
                table: "ChiTietHopDong",
                column: "IDTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHopDong_MaHopDong",
                table: "ChiTietHopDong",
                column: "MaHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHopDong_MaLoHang",
                table: "ChiTietHopDong",
                column: "MaLoHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHopDong_MaPhuongTien",
                table: "ChiTietHopDong",
                column: "MaPhuongTien");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKho_MaKho",
                table: "ChiTietKho",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKho_MaTraiCay",
                table: "ChiTietKho",
                column: "MaTraiCay");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_MaQuocGia",
                table: "DoanhNghiep",
                column: "MaQuocGia");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_PhuongTien_IDTrangThai",
                table: "DoanhNghiep_PhuongTien",
                column: "IDTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_PhuongTien_MaDoanhNghiep",
                table: "DoanhNghiep_PhuongTien",
                column: "MaDoanhNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_PhuongTien_MaPhuongTien",
                table: "DoanhNghiep_PhuongTien",
                column: "MaPhuongTien");

            migrationBuilder.CreateIndex(
                name: "IX_GiaTraiCay_MaTraiCay",
                table: "GiaTraiCay",
                column: "MaTraiCay");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_IDLoaiHopDong",
                table: "HopDong",
                column: "IDLoaiHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_IDTrangThai",
                table: "HopDong",
                column: "IDTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_MaDoiTac",
                table: "HopDong",
                column: "MaDoiTac");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_MaNhanVien",
                table: "HopDong",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_PhuongTien_IDTrangThai",
                table: "Kho_PhuongTien",
                column: "IDTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_PhuongTien_MaKho",
                table: "Kho_PhuongTien",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_PhuongTien_MaPhuongTien",
                table: "Kho_PhuongTien",
                column: "MaPhuongTien");

            migrationBuilder.CreateIndex(
                name: "IX_LoHang_IDLoaiLoHang",
                table: "LoHang",
                column: "IDLoaiLoHang");

            migrationBuilder.CreateIndex(
                name: "IX_LoHang_MaKho",
                table: "LoHang",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_LoHang_MaTraiCay",
                table: "LoHang",
                column: "MaTraiCay");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_MaTraiCay",
                table: "NhaCungCap",
                column: "MaTraiCay");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDBoPhan",
                table: "NhanVien",
                column: "IDBoPhan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDTrangThai",
                table: "NhanVien",
                column: "IDTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_IDLoaiPhuongTien",
                table: "PhuongTien",
                column: "IDLoaiPhuongTien");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_IDTrangThai",
                table: "PhuongTien",
                column: "IDTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_TraiCay_IDLoaiTraiCay",
                table: "TraiCay",
                column: "IDLoaiTraiCay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHopDong");

            migrationBuilder.DropTable(
                name: "ChiTietKho");

            migrationBuilder.DropTable(
                name: "DoanhNghiep_PhuongTien");

            migrationBuilder.DropTable(
                name: "GiaTraiCay");

            migrationBuilder.DropTable(
                name: "Kho_PhuongTien");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "LoHang");

            migrationBuilder.DropTable(
                name: "PhuongTien");

            migrationBuilder.DropTable(
                name: "TrangThaiVanChuyen");

            migrationBuilder.DropTable(
                name: "DoanhNghiep");

            migrationBuilder.DropTable(
                name: "LoaiHopDong");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "TrangThaiHopDong");

            migrationBuilder.DropTable(
                name: "Kho");

            migrationBuilder.DropTable(
                name: "LoaiLoHang");

            migrationBuilder.DropTable(
                name: "LoaiPhuongTien");

            migrationBuilder.DropTable(
                name: "TrangThaiPhuongTien");

            migrationBuilder.DropTable(
                name: "QuocGia");

            migrationBuilder.DropTable(
                name: "TraiCay");

            migrationBuilder.DropTable(
                name: "BoPhan");

            migrationBuilder.DropTable(
                name: "TrangThaiNhanVien");

            migrationBuilder.DropTable(
                name: "LoaiTraiCay");
        }
    }
}

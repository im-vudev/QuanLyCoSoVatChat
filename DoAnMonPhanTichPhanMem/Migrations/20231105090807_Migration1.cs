using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnMonPhanTichPhanMem.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loaiCoSoVatChat",
                columns: table => new
                {
                    maLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiCoSoVatChat", x => x.maLoai);
                });

            migrationBuilder.CreateTable(
                name: "nguoiMuon",
                columns: table => new
                {
                    maNguoiMuon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiMuon", x => x.maNguoiMuon);
                });

            migrationBuilder.CreateTable(
                name: "nhaCungCap",
                columns: table => new
                {
                    maNhaCungCap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNhaCungCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaCungCap", x => x.maNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    maNguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNguoiDung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gioiTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    vaiTro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    soDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.maNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "thongTinCoSoVatChat",
                columns: table => new
                {
                    maThietBi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maLoai = table.Column<int>(type: "int", nullable: false),
                    maNhaCungCap = table.Column<int>(type: "int", nullable: false),
                    tenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thongSo = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ngayNhap = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongTinCoSoVatChat", x => x.maThietBi);
                    table.ForeignKey(
                        name: "FK_ThongTinCoSoVatChat_LoaiCoSoVatChat",
                        column: x => x.maLoai,
                        principalTable: "loaiCoSoVatChat",
                        principalColumn: "maLoai");
                    table.ForeignKey(
                        name: "FK_ThongTinCoSoVatChat_NhaCungCap",
                        column: x => x.maNhaCungCap,
                        principalTable: "nhaCungCap",
                        principalColumn: "maNhaCungCap");
                });

            migrationBuilder.CreateTable(
                name: "donMuon",
                columns: table => new
                {
                    maDonMuon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNguoiDung = table.Column<int>(type: "int", nullable: false),
                    maNguoiMuon = table.Column<int>(type: "int", nullable: false),
                    hoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mucDich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chucNang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donMuon", x => x.maDonMuon);
                    table.ForeignKey(
                        name: "FK_DonMuon_NguoiMuon",
                        column: x => x.maNguoiMuon,
                        principalTable: "nguoiMuon",
                        principalColumn: "maNguoiMuon");
                    table.ForeignKey(
                        name: "FK_DonMuon_Users",
                        column: x => x.maNguoiDung,
                        principalTable: "users",
                        principalColumn: "maNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "phongBan",
                columns: table => new
                {
                    maPhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNguoiDung = table.Column<int>(type: "int", nullable: false),
                    tenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phongBan", x => x.maPhongBan);
                    table.ForeignKey(
                        name: "FK_PhongBan_Users",
                        column: x => x.maNguoiDung,
                        principalTable: "users",
                        principalColumn: "maNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "taiKhoan",
                columns: table => new
                {
                    maTaKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNguoiDung = table.Column<int>(type: "int", nullable: false),
                    hinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    matKhau = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoan", x => x.maTaKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_Users",
                        column: x => x.maNguoiDung,
                        principalTable: "users",
                        principalColumn: "maNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "chiTietDonMuon",
                columns: table => new
                {
                    maChiTietDonMuon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maDonMuon = table.Column<int>(type: "int", nullable: false),
                    maThietBi = table.Column<int>(type: "int", nullable: false),
                    soLuongMuon = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    ngayTraDuKien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayTraThucTe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietDonMuon", x => x.maChiTietDonMuon);
                    table.ForeignKey(
                        name: "FK_ChiTietDonMuon_DonMuon",
                        column: x => x.maDonMuon,
                        principalTable: "donMuon",
                        principalColumn: "maDonMuon");
                    table.ForeignKey(
                        name: "FK_ChiTietDonMuon_ThongTinCoSoVatChat",
                        column: x => x.maThietBi,
                        principalTable: "thongTinCoSoVatChat",
                        principalColumn: "maThietBi");
                });

            migrationBuilder.CreateTable(
                name: "donTra",
                columns: table => new
                {
                    maDonTra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNguoiMuon = table.Column<int>(type: "int", nullable: false),
                    maNguoiDung = table.Column<int>(type: "int", nullable: false),
                    hoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chucNang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donTra", x => x.maDonTra);
                    table.ForeignKey(
                        name: "FK_DonTra_NguoiMuon",
                        column: x => x.maNguoiMuon,
                        principalTable: "nguoiMuon",
                        principalColumn: "maNguoiMuon");
                    table.ForeignKey(
                        name: "FK_DonTra_Users",
                        column: x => x.maNguoiDung,
                        principalTable: "users",
                        principalColumn: "maNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "danhSachThietBi",
                columns: table => new
                {
                    maDanhSachThietBi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maPhongBan = table.Column<int>(type: "int", nullable: false),
                    maThietBi = table.Column<int>(type: "int", nullable: false),
                    viTri = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhSachThietBi", x => x.maDanhSachThietBi);
                    table.ForeignKey(
                        name: "FK_DanhSachThietBi_PhongBan",
                        column: x => x.maPhongBan,
                        principalTable: "phongBan",
                        principalColumn: "maPhongBan");
                    table.ForeignKey(
                        name: "FK_DanhSachThietBi_ThongTinCoSoVatChat",
                        column: x => x.maThietBi,
                        principalTable: "thongTinCoSoVatChat",
                        principalColumn: "maThietBi");
                });

            migrationBuilder.CreateTable(
                name: "chiTietDonTra",
                columns: table => new
                {
                    maChiTietDonTra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maDonTra = table.Column<int>(type: "int", nullable: false),
                    maThietBi = table.Column<int>(type: "int", nullable: false),
                    soLuongTra = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    tenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietDonTra", x => x.maChiTietDonTra);
                    table.ForeignKey(
                        name: "FK_ChiTietDonTra_DonTra",
                        column: x => x.maDonTra,
                        principalTable: "donTra",
                        principalColumn: "maDonTra");
                    table.ForeignKey(
                        name: "FK_ChiTietDonTra_ThongTinCoSoVatChat",
                        column: x => x.maThietBi,
                        principalTable: "thongTinCoSoVatChat",
                        principalColumn: "maThietBi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDonMuon_maDonMuon",
                table: "chiTietDonMuon",
                column: "maDonMuon");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDonMuon_maThietBi",
                table: "chiTietDonMuon",
                column: "maThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDonTra_maDonTra",
                table: "chiTietDonTra",
                column: "maDonTra");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDonTra_maThietBi",
                table: "chiTietDonTra",
                column: "maThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_danhSachThietBi_maPhongBan",
                table: "danhSachThietBi",
                column: "maPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_danhSachThietBi_maThietBi",
                table: "danhSachThietBi",
                column: "maThietBi");

            migrationBuilder.CreateIndex(
                name: "IX_donMuon_maNguoiDung",
                table: "donMuon",
                column: "maNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_donMuon_maNguoiMuon",
                table: "donMuon",
                column: "maNguoiMuon");

            migrationBuilder.CreateIndex(
              name: "IX_donTra_maNguoiMuon",
              table: "donTra",
              column: "maNguoiMuon");

            migrationBuilder.CreateIndex(
                name: "IX_donTra_maNguoiDung",
                table: "donTra",
                column: "maNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_phongBan_maNguoiDung",
                table: "phongBan",
                column: "maNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_taiKhoan_maNguoiDung",
                table: "taiKhoan",
                column: "maNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinCoSoVatChat_maLoai",
                table: "thongTinCoSoVatChat",
                column: "maLoai");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinCoSoVatChat_maNhaCungCap",
                table: "thongTinCoSoVatChat",
                column: "maNhaCungCap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietDonMuon");

            migrationBuilder.DropTable(
                name: "chiTietDonTra");

            migrationBuilder.DropTable(
                name: "danhSachThietBi");

            migrationBuilder.DropTable(
                name: "taiKhoan");

            migrationBuilder.DropTable(
                name: "donTra");

            migrationBuilder.DropTable(
                name: "phongBan");

            migrationBuilder.DropTable(
                name: "thongTinCoSoVatChat");

            migrationBuilder.DropTable(
                name: "donMuon");

            migrationBuilder.DropTable(
                name: "loaiCoSoVatChat");

            migrationBuilder.DropTable(
                name: "nhaCungCap");

            migrationBuilder.DropTable(
                name: "nguoiMuon");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

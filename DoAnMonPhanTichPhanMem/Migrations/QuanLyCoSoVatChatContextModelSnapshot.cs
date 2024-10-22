﻿// <auto-generated />
using System;
using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnMonPhanTichPhanMem.Migrations
{
    [DbContext(typeof(QuanLyCoSoVatChatContext))]
    partial class QuanLyCoSoVatChatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ChiTietDonMuon", b =>
                {
                    b.Property<int>("maChiTietDonMuon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maChiTietDonMuon"));

                    b.Property<int>("maDonMuon")
                        .HasColumnType("int");

                    b.Property<int>("maThietBi")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngayTraDuKien")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ngayTraThucTe")
                        .HasColumnType("datetime2");

                    b.Property<int>("soLuongMuon")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("trangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maChiTietDonMuon");

                    b.HasIndex("maDonMuon");

                    b.HasIndex("maThietBi");

                    b.ToTable("chiTietDonMuon");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ChiTietDonTra", b =>
                {
                    b.Property<int>("maChiTietDonTra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maChiTietDonTra"));

                    b.Property<int>("maDonTra")
                        .HasColumnType("int");

                    b.Property<int>("maThietBi")
                        .HasColumnType("int");

                    b.Property<string>("moTa")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soLuongTra")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("tenThietBi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maChiTietDonTra");

                    b.HasIndex("maDonTra");

                    b.HasIndex("maThietBi");

                    b.ToTable("chiTietDonTra");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DanhSachThietBi", b =>
                {
                    b.Property<int>("maDanhSachThietBi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maDanhSachThietBi"));

                    b.Property<int>("maPhongBan")
                        .HasColumnType("int");

                    b.Property<int>("maThietBi")
                        .HasColumnType("int");

                    b.Property<string>("viTri")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maDanhSachThietBi");

                    b.HasIndex("maPhongBan");

                    b.HasIndex("maThietBi");

                    b.ToTable("danhSachThietBi");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonMuon", b =>
                {
                    b.Property<int>("maDonMuon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maDonMuon"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hoVaTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("maNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("maNguoiMuon")
                        .HasColumnType("int");

                    b.Property<string>("mucDich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngayMuon")
                        .HasColumnType("datetime2");

                    b.Property<string>("soDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("chucNang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maDonMuon");

                    b.HasIndex("maNguoiDung");

                    b.HasIndex("maNguoiMuon");

                    b.ToTable("donMuon");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonTra", b =>
                {
                    b.Property<int>("maDonTra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maDonTra"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hoVaTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("maNguoiMuon")
                        .HasColumnType("int");

                    b.Property<int>("maNguoiDung")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngayTra")
                        .HasColumnType("datetime2");

                    b.Property<string>("soDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("chucNang")
                     .IsRequired()
                     .HasColumnType("nvarchar(max)");

                    b.HasKey("maDonTra");

                    b.HasIndex("maNguoiMuon");

                    b.HasIndex("maNguoiDung");

                    b.ToTable("donTra");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.LoaiCoSoVatChat", b =>
                {
                    b.Property<int>("maLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maLoai"));

                    b.Property<string>("moTa")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenLoai")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maLoai");

                    b.ToTable("loaiCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NguoiMuon", b =>
                {
                    b.Property<int>("maNguoiMuon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maNguoiMuon"));

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hoVaTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ngayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<string>("soDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maNguoiMuon");

                    b.ToTable("nguoiMuon");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NhaCungCap", b =>
                {
                    b.Property<int>("maNhaCungCap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maNhaCungCap"));

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenNhaCungCap")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maNhaCungCap");

                    b.ToTable("nhaCungCap");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.PhongBan", b =>
                {
                    b.Property<int>("maPhongBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maPhongBan"));

                    b.Property<int>("maNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("tenPhongBan")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maPhongBan");

                    b.HasIndex("maNguoiDung");

                    b.ToTable("phongBan");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.TaiKhoan", b =>
                {
                    b.Property<int>("maTaKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maTaKhoan"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("hinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("matKhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("maTaKhoan");

                    b.HasIndex("maNguoiDung");

                    b.ToTable("taiKhoan");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ThongTinCoSoVatChat", b =>
                {
                    b.Property<int>("maThietBi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maThietBi"));

                    b.Property<string>("hinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maLoai")
                        .HasColumnType("int");

                    b.Property<int>("maNhaCungCap")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int>("soLuong")
                        .HasColumnType("int");

                    b.Property<string>("tenThietBi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("thongSo")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maThietBi");

                    b.HasIndex("maLoai");

                    b.HasIndex("maNhaCungCap");

                    b.ToTable("thongTinCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.Users", b =>
                {
                    b.Property<int>("maNguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maNguoiDung"));

                    b.Property<string>("CMND_CCCD")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("gioiTinh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ngaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("soDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenNguoiDung")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("vaiTro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maNguoiDung");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ChiTietDonMuon", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonMuon", "donMuon")
                        .WithMany("chiTietDonMuon")
                        .HasForeignKey("maDonMuon")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietDonMuon_DonMuon");

                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ThongTinCoSoVatChat", "thongTinCoSoVatChat")
                        .WithMany("chiTietDonMuon")
                        .HasForeignKey("maThietBi")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietDonMuon_ThongTinCoSoVatChat");

                    b.Navigation("donMuon");

                    b.Navigation("thongTinCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ChiTietDonTra", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonTra", "donTra")
                        .WithMany("chiTietDonTra")
                        .HasForeignKey("maDonTra")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietDonTra_DonTra");

                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ThongTinCoSoVatChat", "thongTinCoSoVatChat")
                        .WithMany("chiTietDonTra")
                        .HasForeignKey("maThietBi")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietDonTra_ThongTinCoSoVatChat");

                    b.Navigation("donTra");

                    b.Navigation("thongTinCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DanhSachThietBi", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.PhongBan", "phongBan")
                        .WithMany("danhSachThietBi")
                        .HasForeignKey("maPhongBan")
                        .IsRequired()
                        .HasConstraintName("FK_DanhSachThietBi_PhongBan");

                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ThongTinCoSoVatChat", "thongTinCoSoVatChat")
                        .WithMany("danhSachThietBi")
                        .HasForeignKey("maThietBi")
                        .IsRequired()
                        .HasConstraintName("FK_DanhSachThietBi_ThongTinCoSoVatChat");

                    b.Navigation("phongBan");

                    b.Navigation("thongTinCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonMuon", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.Users", "users")
                        .WithMany("donMuon")
                        .HasForeignKey("maNguoiDung")
                        .IsRequired()
                        .HasConstraintName("FK_DonMuon_Users");

                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NguoiMuon", "nguoiMuon")
                        .WithMany("donMuon")
                        .HasForeignKey("maNguoiMuon")
                        .IsRequired()
                        .HasConstraintName("FK_DonMuon_NguoiMuon");

                    b.Navigation("nguoiMuon");

                    b.Navigation("users");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonTra", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NguoiMuon", "nguoiMuon")
                        .WithMany("donTra")
                        .HasForeignKey("maNguoiMuon")
                        .IsRequired()
                        .HasConstraintName("FK_DonTra_NguoiMuon");

                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.Users", "users")
                        .WithMany("donTra")
                        .HasForeignKey("maNguoiDung")
                        .IsRequired()
                        .HasConstraintName("FK_DonTra_Users");

                    b.Navigation("nguoiMuon");

                    b.Navigation("users");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.PhongBan", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.Users", "users")
                        .WithMany("phongBan")
                        .HasForeignKey("maNguoiDung")
                        .IsRequired()
                        .HasConstraintName("FK_PhongBan_Users");

                    b.Navigation("users");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.TaiKhoan", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.Users", "users")
                        .WithMany("taiKhoan")
                        .HasForeignKey("maNguoiDung")
                        .IsRequired()
                        .HasConstraintName("FK_TaiKhoan_Users");

                    b.Navigation("users");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ThongTinCoSoVatChat", b =>
                {
                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.LoaiCoSoVatChat", "loaiCoSoVatChat")
                        .WithMany("thongTinCoSoVatChat")
                        .HasForeignKey("maLoai")
                        .IsRequired()
                        .HasConstraintName("FK_ThongTinCoSoVatChat_LoaiCoSoVatChat");

                    b.HasOne("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NhaCungCap", "nhaCungCap")
                        .WithMany("thongTinCoSoVatChat")
                        .HasForeignKey("maNhaCungCap")
                        .IsRequired()
                        .HasConstraintName("FK_ThongTinCoSoVatChat_NhaCungCap");

                    b.Navigation("loaiCoSoVatChat");

                    b.Navigation("nhaCungCap");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonMuon", b =>
                {
                    b.Navigation("chiTietDonMuon");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.DonTra", b =>
                {
                    b.Navigation("chiTietDonTra");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.LoaiCoSoVatChat", b =>
                {
                    b.Navigation("thongTinCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NguoiMuon", b =>
                {
                    b.Navigation("donMuon");

                    b.Navigation("donTra");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.NhaCungCap", b =>
                {
                    b.Navigation("thongTinCoSoVatChat");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.PhongBan", b =>
                {
                    b.Navigation("danhSachThietBi");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.ThongTinCoSoVatChat", b =>
                {
                    b.Navigation("chiTietDonMuon");

                    b.Navigation("chiTietDonTra");

                    b.Navigation("danhSachThietBi");
                });

            modelBuilder.Entity("DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models.Users", b =>
                {
                    b.Navigation("donMuon");

                    b.Navigation("donTra");

                    b.Navigation("phongBan");

                    b.Navigation("taiKhoan");
                });
#pragma warning restore 612, 618
        }
    }
}

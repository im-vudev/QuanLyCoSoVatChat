using Microsoft.EntityFrameworkCore;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class QuanLyCoSoVatChatContext : DbContext
	{
		public QuanLyCoSoVatChatContext(DbContextOptions<QuanLyCoSoVatChatContext> options) : base(options)
		{

		}
		public DbSet<ChiTietDonMuon> chiTietDonMuon { get; set; }
		public DbSet<ChiTietDonTra> chiTietDonTra { get; set; }
		public DbSet<DanhSachThietBi> danhSachThietBi { get; set; }
		public DbSet<DonMuon> donMuon { get; set; }
		public DbSet<DonTra> donTra { get; set; }
		public DbSet<LoaiCoSoVatChat> loaiCoSoVatChat { get; set; }
		public DbSet<NguoiMuon> nguoiMuon { get; set; }
		public DbSet<NhaCungCap> nhaCungCap { get; set; }
		public DbSet<PhongBan> phongBan { get; set; }
		public DbSet<TaiKhoan> taiKhoan { get; set; }
		public DbSet<ThongTinCoSoVatChat> thongTinCoSoVatChat { get; set; }
		public DbSet<Users> users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ChiTietDonMuon>(entity =>
			{
				entity.HasKey(e => e.maChiTietDonMuon);
				entity.Property(e => e.soLuongMuon)
				   .IsRequired()
				   .HasMaxLength(100);
				entity.Property(e => e.ngayTraDuKien)
				   .IsRequired();
				entity.Property(e => e.ngayTraThucTe)
				   .IsRequired();
				entity.Property(e => e.trangThai)
				   .IsRequired();
                entity.HasOne(d => d.donMuon)
					.WithMany(b => b.chiTietDonMuon)
					.HasForeignKey(d => d.maDonMuon)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ChiTietDonMuon_DonMuon");
				entity.HasOne(d => d.thongTinCoSoVatChat)
					.WithMany(b => b.chiTietDonMuon)
					.HasForeignKey(d => d.maThietBi)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ChiTietDonMuon_ThongTinCoSoVatChat");
			});
			modelBuilder.Entity<ChiTietDonTra>(entity =>
			{
				entity.HasKey(e => e.maChiTietDonTra);
				entity.Property(e => e.soLuongTra)
				   .IsRequired()
				   .HasMaxLength(100);
				entity.Property(e => e.tenThietBi)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.moTa)
                   .IsRequired()
				   .HasMaxLength(int.MaxValue)
                   .IsUnicode(true);
                entity.HasOne(d => d.donTra)
				   .WithMany(b => b.chiTietDonTra)
				   .HasForeignKey(d => d.maDonTra)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_ChiTietDonTra_DonTra");
				entity.HasOne(d => d.thongTinCoSoVatChat)
				   .WithMany(b => b.chiTietDonTra)
				   .HasForeignKey(d => d.maThietBi)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_ChiTietDonTra_ThongTinCoSoVatChat");
			});
			modelBuilder.Entity<DanhSachThietBi>(entity =>
			{
				entity.HasKey(e => e.maDanhSachThietBi);
				entity.Property(e => e.viTri)
                   .IsRequired()
                   .HasMaxLength(int.MaxValue)
                   .IsUnicode(true);
                entity.HasOne(d => d.phongBan)
				   .WithMany(b => b.danhSachThietBi)
				   .HasForeignKey(d => d.maPhongBan)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_DanhSachThietBi_PhongBan");
				entity.HasOne(d => d.thongTinCoSoVatChat)
				   .WithMany(b => b.danhSachThietBi)
				   .HasForeignKey(d => d.maThietBi)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_DanhSachThietBi_ThongTinCoSoVatChat");
			});
			modelBuilder.Entity<DonMuon>(entity =>
			{
				entity.HasKey(e => e.maDonMuon);
				entity.Property(e => e.hoVaTen)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.soDienThoai)
				   .IsRequired();
				entity.Property(e => e.email)
				   .IsRequired()
				   .HasMaxLength(100);
				entity.Property(e => e.ngayMuon)
				   .IsRequired();
				entity.Property(e => e.mucDich)
				   .IsRequired();
                entity.Property(e => e.chucNang)
                   .IsRequired();
                entity.HasOne(d => d.users)
				   .WithMany(b => b.donMuon)
				   .HasForeignKey(d => d.maNguoiDung)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_DonMuon_Users");
				entity.HasOne(d => d.nguoiMuon)
				   .WithMany(b => b.donMuon)
				   .HasForeignKey(d => d.maNguoiMuon)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_DonMuon_NguoiMuon");
			});
			modelBuilder.Entity<DonTra>(entity =>
			{
				entity.HasKey(e => e.maDonTra);
				entity.Property(e => e.hoVaTen)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.soDienThoai)
				   .IsRequired();
				entity.Property(e => e.email)
				   .IsRequired()
				   .HasMaxLength(100);
				entity.Property(e => e.ngayTra)
				   .IsRequired();
				entity.Property(e => e.trangThai)
				   .IsRequired();
                entity.Property(e => e.chucNang)
                  .IsRequired();
                entity.HasOne(d => d.users)
				   .WithMany(b => b.donTra)
				   .HasForeignKey(d => d.maNguoiDung)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_DonTra_Users");
                entity.HasOne(d => d.nguoiMuon)
                   .WithMany(b => b.donTra)
                   .HasForeignKey(d => d.maNguoiMuon)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_DonTra_NguoiMuon");
            });
			modelBuilder.Entity<LoaiCoSoVatChat>(entity =>
			{
				entity.HasKey(e => e.maLoai);
				entity.Property(e => e.tenLoai)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.moTa)
                  .IsRequired()
				  .HasMaxLength(int.MaxValue)
				  .IsUnicode(true);
            });
			modelBuilder.Entity<NguoiMuon>(entity =>
			{
				entity.HasKey(e => e.maNguoiMuon);
				entity.Property(e => e.hoVaTen)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.soDienThoai)
				   .IsRequired();
				entity.Property(e => e.diaChi)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.ngayDangKy)
				   .IsRequired();
			});
			modelBuilder.Entity<NhaCungCap>(entity =>
			{
				entity.HasKey(e => e.maNhaCungCap);
				entity.Property(e => e.tenNhaCungCap)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.soDienThoai)
				   .IsRequired();
				entity.Property(e => e.diaChi)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.email)
				   .IsRequired();
			});
			modelBuilder.Entity<PhongBan>(entity =>
			{
				entity.HasKey(e => e.maPhongBan);
				entity.Property(e => e.tenPhongBan)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.HasOne(d => d.users)
				   .WithMany(b => b.phongBan)
				   .HasForeignKey(d => d.maNguoiDung)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK_PhongBan_Users");
			});
			modelBuilder.Entity<TaiKhoan>(entity =>
			{
				entity.HasKey(e => e.maTaKhoan);
				entity.Property(e => e.hinhAnh)
				   .IsRequired();
				entity.Property(e => e.email)
				   .IsRequired() 
				   .HasMaxLength(100)
				   .IsUnicode(false);
				entity.Property(e => e.matKhau) 
				   .IsRequired()
				   .HasMaxLength(255)
				   .IsUnicode(false);
				entity.HasOne(e => e.users)
					.WithMany(u => u.taiKhoan)
					.HasForeignKey(e => e.maNguoiDung)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_TaiKhoan_Users");
			});
			modelBuilder.Entity<ThongTinCoSoVatChat>(entity =>
			{
				entity.HasKey(e => e.maThietBi);
				entity.Property(e => e.tenThietBi)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.hinhAnh)
				   .IsRequired();
				entity.Property(e => e.soLuong)
				   .IsRequired();
				entity.Property(e => e.trangThai)
				   .IsRequired();
				entity.Property(e => e.thongSo)
                   .IsRequired()
				   .HasMaxLength(int.MaxValue)
				   .IsUnicode(true);
                entity.Property(e => e.ngayNhap)
				   .IsRequired();
				entity.HasOne(e => e.loaiCoSoVatChat)
					.WithMany(u => u.thongTinCoSoVatChat)
					.HasForeignKey(e => e.maLoai)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ThongTinCoSoVatChat_LoaiCoSoVatChat");
				entity.HasOne(e => e.nhaCungCap)
					.WithMany(u => u.thongTinCoSoVatChat)
					.HasForeignKey(e => e.maNhaCungCap)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ThongTinCoSoVatChat_NhaCungCap");
			});
			modelBuilder.Entity<Users>(entity =>
			{
				entity.HasKey(e => e.maNguoiDung);
				entity.Property(e => e.tenNguoiDung)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.gioiTinh)
				   .IsRequired()
				   .HasMaxLength(50);
                entity.Property(e => e.ngaySinh)
                  .IsRequired();
                entity.Property(e => e.CMND_CCCD)
                   .IsRequired()
                   .HasMaxLength(100);
                entity.Property(e => e.vaiTro)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(true);
				entity.Property(e => e.diaChi)
				   .IsRequired()
				   .HasMaxLength(50)
				   .IsUnicode(true);
				entity.Property(e => e.soDienThoai)
				   .IsRequired();
				entity.Property(e => e.email)
				   .IsRequired()
				   .HasMaxLength(100);
			});
		}
	}
}

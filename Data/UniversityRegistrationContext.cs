using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Text;
using UniversityRegistration.Models;

namespace UniversityRegistration.Data;

public class UniversityRegistrationContext : DbContext
{
    public UniversityRegistrationContext(DbContextOptions<UniversityRegistrationContext> options)
        : base(options)
    {
    }

    public DbSet<Khoa> DanhSachKhoa => Set<Khoa>();

    public DbSet<KhoaDaoTao> DanhSachKhoaDaoTao => Set<KhoaDaoTao>();

    public DbSet<ChuongTrinhHoc> DanhSachChuongTrinhHoc => Set<ChuongTrinhHoc>();

    public DbSet<LopDanhNghia> DanhSachLopDanhNghia => Set<LopDanhNghia>();

    public DbSet<SinhVien> DanhSachSinhVien => Set<SinhVien>();

    public DbSet<GiangVien> DanhSachGiangVien => Set<GiangVien>();

    public DbSet<MonHoc> DanhSachMonHoc => Set<MonHoc>();

    public DbSet<MonHocGiangVien> DanhSachMonHocGiangVien => Set<MonHocGiangVien>();

    public DbSet<HocKy> DanhSachHocKy => Set<HocKy>();

    public DbSet<LopHocPhan> DanhSachLopHocPhan => Set<LopHocPhan>();

    public DbSet<NhomThucHanh> DanhSachNhomThucHanh => Set<NhomThucHanh>();

    public DbSet<PhongHoc> DanhSachPhongHoc => Set<PhongHoc>();

    public DbSet<LichHocPhan> DanhSachLichHocPhan => Set<LichHocPhan>();

    public DbSet<DangKyHocPhan> DanhSachDangKyHocPhan => Set<DangKyHocPhan>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MonHocGiangVien>()
            .HasKey(mg => new { mg.MonHocId, mg.GiangVienId });

        modelBuilder.Entity<Khoa>()
            .HasMany(k => k.DanhSachKhoaDaoTao)
            .WithOne(kdt => kdt.Khoa)
            .HasForeignKey(kdt => kdt.KhoaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Khoa>()
            .HasMany(k => k.DanhSachGiangVien)
            .WithOne(gv => gv.Khoa)
            .HasForeignKey(gv => gv.KhoaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Khoa>()
            .HasMany(k => k.DanhSachMonHoc)
            .WithOne(mh => mh.Khoa)
            .HasForeignKey(mh => mh.KhoaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<KhoaDaoTao>()
            .HasMany(kdt => kdt.DanhSachLopDanhNghia)
            .WithOne(ldn => ldn.KhoaDaoTao)
            .HasForeignKey(ldn => ldn.KhoaDaoTaoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ChuongTrinhHoc>()
            .HasMany(cth => cth.DanhSachMonHoc)
            .WithOne(mh => mh.ChuongTrinhHoc)
            .HasForeignKey(mh => mh.ChuongTrinhHocId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<LopDanhNghia>()
            .HasMany(ldn => ldn.DanhSachSinhVien)
            .WithOne(sv => sv.LopDanhNghia)
            .HasForeignKey(sv => sv.LopDanhNghiaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MonHoc>()
            .HasMany(mh => mh.DanhSachLopHocPhan)
            .WithOne(lhp => lhp.MonHoc)
            .HasForeignKey(lhp => lhp.MonHocId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HocKy>()
            .HasMany(hk => hk.DanhSachLopHocPhan)
            .WithOne(lhp => lhp.HocKy)
            .HasForeignKey(lhp => lhp.HocKyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GiangVien>()
            .HasMany(gv => gv.DanhSachLopHocPhanLT)
            .WithOne(lhp => lhp.GiangVienLT)
            .HasForeignKey(lhp => lhp.GiangVienLTId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GiangVien>()
            .HasMany(gv => gv.DanhSachNhomThucHanhTH)
            .WithOne(nth => nth.GiangVienTH)
            .HasForeignKey(nth => nth.GiangVienTHId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MonHocGiangVien>()
            .HasOne(mg => mg.MonHoc)
            .WithMany(mh => mh.DanhSachMonHocGiangVien)
            .HasForeignKey(mg => mg.MonHocId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MonHocGiangVien>()
            .HasOne(mg => mg.GiangVien)
            .WithMany(gv => gv.DanhSachMonHocGiangVien)
            .HasForeignKey(mg => mg.GiangVienId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LopHocPhan>()
            .HasMany(lhp => lhp.DanhSachNhomThucHanh)
            .WithOne(nth => nth.LopHocPhan)
            .HasForeignKey(nth => nth.LopHocPhanId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LopHocPhan>()
            .HasMany(lhp => lhp.DanhSachLichHocPhan)
            .WithOne(lhpDetail => lhpDetail.LopHocPhan)
            .HasForeignKey(lhpDetail => lhpDetail.LopHocPhanId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LopHocPhan>()
            .HasMany(lhp => lhp.DanhSachDangKyHocPhan)
            .WithOne(dkhp => dkhp.LopHocPhan)
            .HasForeignKey(dkhp => dkhp.LopHocPhanId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NhomThucHanh>()
            .HasMany(nth => nth.DanhSachLichHocPhan)
            .WithOne(lhpDetail => lhpDetail.NhomThucHanh)
            .HasForeignKey(lhpDetail => lhpDetail.NhomThucHanhId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<NhomThucHanh>()
            .HasMany(nth => nth.DanhSachDangKyHocPhan)
            .WithOne(dkhp => dkhp.NhomThucHanh)
            .HasForeignKey(dkhp => dkhp.NhomThucHanhId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SinhVien>()
            .HasMany(sv => sv.DanhSachDangKyHocPhan)
            .WithOne(dkhp => dkhp.SinhVien)
            .HasForeignKey(dkhp => dkhp.SinhVienId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PhongHoc>()
            .HasMany(ph => ph.DanhSachLichHocPhan)
            .WithOne(lhp => lhp.PhongHoc)
            .HasForeignKey(lhp => lhp.PhongHocId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PhongHoc>()
            .Property(ph => ph.LoaiPhong)
            .HasConversion<string>()
            .HasMaxLength(20);

        ApplySnakeCaseNaming(modelBuilder);
    }

    private static void ApplySnakeCaseNaming(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                entity.SetTableName(NormalizeTableName(tableName));
            }

            foreach (var property in entity.GetProperties())
            {
                var columnName = property.Name;
                property.SetColumnName(ToSnakeCase(columnName));
            }

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrWhiteSpace(keyName))
                {
                    key.SetName(ToSnakeCase(keyName));
                }
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (!string.IsNullOrWhiteSpace(indexName))
                {
                    index.SetDatabaseName(ToSnakeCase(indexName));
                }
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var constraintName = foreignKey.GetConstraintName();
                if (!string.IsNullOrWhiteSpace(constraintName))
                {
                    foreignKey.SetConstraintName(ToSnakeCase(constraintName));
                }
            }
        }
    }

    private const string DanhSachPrefix = "DanhSach";

    private static string NormalizeTableName(string tableName)
    {
        var trimmedName = tableName;

        if (trimmedName.StartsWith(DanhSachPrefix, StringComparison.Ordinal))
        {
            trimmedName = trimmedName[DanhSachPrefix.Length..];
        }

        if (trimmedName.EndsWith("s", StringComparison.Ordinal) && trimmedName.Length > 1)
        {
            trimmedName = trimmedName[..^1];
        }

        return ToSnakeCase(trimmedName);
    }

    private static string ToSnakeCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var builder = new StringBuilder(value.Length + 10);

        for (int i = 0; i < value.Length; i++)
        {
            var current = value[i];

            if (current == '.')
            {
                builder.Append('_');
                continue;
            }

            if (char.IsUpper(current))
            {
                var hasPrior = i > 0;
                var priorIsLower = hasPrior && char.IsLetterOrDigit(value[i - 1]) && !char.IsUpper(value[i - 1]);
                var nextIsLower = i + 1 < value.Length && char.IsLetterOrDigit(value[i + 1]) && !char.IsUpper(value[i + 1]);

                if (hasPrior && (priorIsLower || nextIsLower))
                {
                    builder.Append('_');
                }

                builder.Append(char.ToLowerInvariant(current));
            }
            else
            {
                builder.Append(char.ToLowerInvariant(current));
            }
        }

        return builder.ToString();
    }
}

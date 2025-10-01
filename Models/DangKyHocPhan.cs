using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class DangKyHocPhan
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string SinhVienId { get; set; } = string.Empty;
    public SinhVien SinhVien { get; set; } = null!;

    [MaxLength(10)]
    public string LopHocPhanId { get; set; } = string.Empty;
    public LopHocPhan LopHocPhan { get; set; } = null!;

    [MaxLength(10)]
    public string? NhomThucHanhId { get; set; }
    public NhomThucHanh? NhomThucHanh { get; set; }

    public DateTime NgayDangKy { get; set; } = DateTime.Now;
}

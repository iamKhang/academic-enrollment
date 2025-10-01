using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class SinhVien
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(10)]
    public string MaSV { get; set; } = string.Empty;
    [MaxLength(50)]
    public string HoTen { get; set; } = string.Empty;

    [MaxLength(10)]
    public string LopDanhNghiaId { get; set; } = string.Empty;
    public LopDanhNghia LopDanhNghia { get; set; } = null!;

    public ICollection<DangKyHocPhan> DanhSachDangKyHocPhan { get; set; } = new List<DangKyHocPhan>();
}

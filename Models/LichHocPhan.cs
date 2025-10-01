using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class LichHocPhan
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? LopHocPhanId { get; set; }
    public LopHocPhan? LopHocPhan { get; set; }

    [MaxLength(10)]
    public string? NhomThucHanhId { get; set; }
    public NhomThucHanh? NhomThucHanh { get; set; }

    public DayOfWeek Thu { get; set; }
    public int TietBatDau { get; set; }
    public int TietKetThuc { get; set; }

    [MaxLength(10)]
    public string PhongHocId { get; set; } = string.Empty;
    public PhongHoc PhongHoc { get; set; } = null!;
}

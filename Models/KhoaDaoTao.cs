using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class KhoaDaoTao
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string TenKhoaDaoTao { get; set; } = string.Empty;

    public DateTime NgayBatDau { get; set; }
    public DateTime NgayKetThuc { get; set; }

    [MaxLength(10)]
    public string KhoaId { get; set; } = string.Empty;
    public Khoa Khoa { get; set; } = null!;

    [MaxLength(10)]
    public string ChuongTrinhHocId { get; set; } = string.Empty;
    public ChuongTrinhHoc ChuongTrinhHoc { get; set; } = null!;

    public ICollection<LopDanhNghia> DanhSachLopDanhNghia { get; set; } = new List<LopDanhNghia>();
}

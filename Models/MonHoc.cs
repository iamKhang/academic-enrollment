using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class MonHoc
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string TenMonHoc { get; set; } = string.Empty;
    public int TinChiLT { get; set; }
    public int TinChiTH { get; set; }

    [MaxLength(10)]
    public string KhoaId { get; set; } = string.Empty;
    public Khoa Khoa { get; set; } = null!;

    [MaxLength(10)]
    public string? ChuongTrinhHocId { get; set; }
    public ChuongTrinhHoc? ChuongTrinhHoc { get; set; }

    public ICollection<LopHocPhan> DanhSachLopHocPhan { get; set; } = new List<LopHocPhan>();

    public ICollection<MonHocGiangVien> DanhSachMonHocGiangVien { get; set; } = new List<MonHocGiangVien>();
}

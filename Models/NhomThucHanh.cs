using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class NhomThucHanh
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string LopHocPhanId { get; set; } = string.Empty;
    public LopHocPhan LopHocPhan { get; set; } = null!;

    [MaxLength(50)]
    public string TenNhom { get; set; } = string.Empty;
    public int SoLuongToiDa { get; set; }
    public int SoLuongHienTai { get; set; }

    [MaxLength(10)]
    public string GiangVienTHId { get; set; } = string.Empty;
    public GiangVien GiangVienTH { get; set; } = null!;

    public ICollection<LichHocPhan> DanhSachLichHocPhan { get; set; } = new List<LichHocPhan>();

    public ICollection<DangKyHocPhan> DanhSachDangKyHocPhan { get; set; } = new List<DangKyHocPhan>();
}

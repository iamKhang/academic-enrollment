using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class LopHocPhan
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string MonHocId { get; set; } = string.Empty;
    public MonHoc MonHoc { get; set; } = null!;

    [MaxLength(10)]
    public string HocKyId { get; set; } = string.Empty;
    public HocKy HocKy { get; set; } = null!;

    [MaxLength(10)]
    public string GiangVienLTId { get; set; } = string.Empty;
    public GiangVien GiangVienLT { get; set; } = null!;

    public int SoLuongToiDaLT { get; set; }
    public int SoLuongHienTaiLT { get; set; }

    public TrangThaiLopHocPhan TrangThai { get; set; } = TrangThaiLopHocPhan.DangChoMo;

    public ICollection<NhomThucHanh> DanhSachNhomThucHanh { get; set; } = new List<NhomThucHanh>();

    public ICollection<LichHocPhan> DanhSachLichHocPhan { get; set; } = new List<LichHocPhan>();

    public ICollection<DangKyHocPhan> DanhSachDangKyHocPhan { get; set; } = new List<DangKyHocPhan>();
}

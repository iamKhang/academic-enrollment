using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class GiangVien
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(10)]
    public string MaGV { get; set; } = string.Empty;
    [MaxLength(50)]
    public string HoTen { get; set; } = string.Empty;

    [MaxLength(10)]
    public string KhoaId { get; set; } = string.Empty;
    public Khoa Khoa { get; set; } = null!;

    public ICollection<MonHocGiangVien> DanhSachMonHocGiangVien { get; set; } = new List<MonHocGiangVien>();

    public ICollection<LopHocPhan> DanhSachLopHocPhanLT { get; set; } = new List<LopHocPhan>();

    public ICollection<NhomThucHanh> DanhSachNhomThucHanhTH { get; set; } = new List<NhomThucHanh>();
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Khoa
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string TenKhoa { get; set; } = string.Empty;

    public ICollection<KhoaDaoTao> DanhSachKhoaDaoTao { get; set; } = new List<KhoaDaoTao>();

    public ICollection<GiangVien> DanhSachGiangVien { get; set; } = new List<GiangVien>();

    public ICollection<MonHoc> DanhSachMonHoc { get; set; } = new List<MonHoc>();
}

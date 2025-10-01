using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class LopDanhNghia
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string TenLop { get; set; } = string.Empty;

    [MaxLength(10)]
    public string KhoaDaoTaoId { get; set; } = string.Empty;
    public KhoaDaoTao KhoaDaoTao { get; set; } = null!;

    public ICollection<SinhVien> DanhSachSinhVien { get; set; } = new List<SinhVien>();
}

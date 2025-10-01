using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class MonHocGiangVien
{
    [MaxLength(10)]
    public string MonHocId { get; set; } = string.Empty;
    public MonHoc MonHoc { get; set; } = null!;

    [MaxLength(10)]
    public string GiangVienId { get; set; } = string.Empty;
    public GiangVien GiangVien { get; set; } = null!;
}

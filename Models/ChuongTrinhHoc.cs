using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class ChuongTrinhHoc
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string TenChuongTrinh { get; set; } = string.Empty;

    public ICollection<MonHoc> DanhSachMonHoc { get; set; } = new List<MonHoc>();
}

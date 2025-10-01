using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class PhongHoc
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string TenPhong { get; set; } = string.Empty;
    public int SucChua { get; set; }
    public LoaiPhong LoaiPhong { get; set; } = LoaiPhong.Khac;
    [MaxLength(150)]
    public string DiaDiem { get; set; } = string.Empty;

    public ICollection<LichHocPhan> DanhSachLichHocPhan { get; set; } = new List<LichHocPhan>();
}

public enum LoaiPhong
{
    LyThuyet = 1,         // Phòng học lý thuyết tiêu chuẩn
    ThucHanhMayTinh = 2,  // Phòng thực hành máy tính
    ThiNghiem = 3,        // Phòng thí nghiệm (Lý/Hóa/Sinh)
    HoiTruong = 4,        // Hội trường / phòng lớn
    ThuVien = 5,          // Phòng thư viện / tự học
    ChuyenDe = 6,         // Phòng chuyên đề / seminar
    NgoaiNgu = 7,         // Phòng ngoại ngữ (thiết bị nghe nói)
    ThucTapMoPhong = 8,   // Phòng thực tập mô phỏng (y tế, điều dưỡng...)
    ThucHanhCoKhi = 9,    // Xưởng cơ khí, thực hành máy móc
    Khac = 99             // Loại phòng khác
}

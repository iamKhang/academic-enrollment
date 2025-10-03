namespace UniversityRegistration.Models.Enums;

public enum ClassStatus
{
    Pending = 0,              // Đang chờ mở lớp (mới được đề xuất, chưa cho đăng ký)
    OpenForRegistration = 1,  // Chờ sinh viên đăng ký (lớp mở để SV ghi danh) => Có thể đăng ký và hủy
    Approved = 2,             // Chấp nhận mở lớp (đủ điều kiện, lớp sẽ được tổ chức) => Có thể đăng ký nhưng không thể tự hủy
    RegistrationClosed = 3,   // Đã khóa đăng ký (không nhận thêm SV, nhưng lớp vẫn tồn tại/diễn ra) => Không thể đăng ký và không thể hủy
    Cancelled = 4             // Đã hủy lớp (không còn tổ chức lớp này)
}

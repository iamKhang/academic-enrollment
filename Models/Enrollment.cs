using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Enrollment
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string StudentId { get; set; } = string.Empty;
    public Student Student { get; set; } = null!;

    [MaxLength(10)]
    public string CourseClassId { get; set; } = string.Empty;
    public CourseClass CourseClass { get; set; } = null!;

    [MaxLength(10)]
    public string? PracticeGroupId { get; set; }
    public PracticeGroup? PracticeGroup { get; set; }

    // (Khuyến nghị) Quy đổi nhóm khi SV đăng ký môn tự chọn
    [MaxLength(10)]
    public string? AttributedElectiveGroupId { get; set; }
    public ElectiveGroup? AttributedElectiveGroup { get; set; }

    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
}

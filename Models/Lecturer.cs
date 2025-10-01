using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Lecturer
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(10)]
    public string LecturerCode { get; set; } = string.Empty;
    [MaxLength(50)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(10)]
    public string DepartmentId { get; set; } = string.Empty;
    public Department Department { get; set; } = null!;

    public ICollection<SubjectLecturer> SubjectLecturers { get; set; } = new List<SubjectLecturer>();

    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();

    public ICollection<PracticeGroup> PracticeGroups { get; set; } = new List<PracticeGroup>();
}

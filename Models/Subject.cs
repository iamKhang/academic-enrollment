using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Subject
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public int TheoryCredits { get; set; }
    public int PracticeCredits { get; set; }
    public int TotalCredits => TheoryCredits + PracticeCredits;

    [MaxLength(10)]
    public string DepartmentId { get; set; } = string.Empty;
    public Department Department { get; set; } = null!;

    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();

    public ICollection<SubjectLecturer> SubjectLecturers { get; set; } = new List<SubjectLecturer>();
}

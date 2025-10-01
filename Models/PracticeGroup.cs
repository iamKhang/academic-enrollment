using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class PracticeGroup
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string CourseClassId { get; set; } = string.Empty;
    public CourseClass CourseClass { get; set; } = null!;

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }

    [MaxLength(10)]
    public string LecturerId { get; set; } = string.Empty;
    public Lecturer Lecturer { get; set; } = null!;

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

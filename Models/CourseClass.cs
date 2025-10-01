using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models.Enums;

namespace UniversityRegistration.Models;

public class CourseClass
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string SubjectId { get; set; } = string.Empty;
    public Subject Subject { get; set; } = null!;

    [MaxLength(10)]
    public string SemesterId { get; set; } = string.Empty;
    public Semester Semester { get; set; } = null!;

    [MaxLength(10)]
    public string LecturerId { get; set; } = string.Empty;
    public Lecturer Lecturer { get; set; } = null!;

    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }

    public ClassStatus Status { get; set; } = ClassStatus.Pending;

    public ICollection<PracticeGroup> PracticeGroups { get; set; } = new List<PracticeGroup>();

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

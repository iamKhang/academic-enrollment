using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models.Enums;

namespace UniversityRegistration.Models;

public class SubjectCurriculum
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string CurriculumId { get; set; } = string.Empty;
    public Curriculum Curriculum { get; set; } = null!;

    [MaxLength(10)]
    public string SubjectId { get; set; } = string.Empty;
    public Subject Subject { get; set; } = null!;

    public int Semester { get; set; }
    public CourseType CourseType { get; set; }  // Required / Elective

    // Môn này có thể được tính cho những nhóm nào của HỌC KỲ NÀY
    public ICollection<SubjectCurriculumElectiveGroup> ElectiveGroups { get; set; }
        = new List<SubjectCurriculumElectiveGroup>();

    // ====== Prerequisite / Co-requisite relationships ======

    // Prerequisites (must pass before)
    public ICollection<SubjectCurriculum> Prerequisites { get; set; } = new List<SubjectCurriculum>();

    // Corequisites (must take before, no pass requirement)
    public ICollection<SubjectCurriculum> Corequisites { get; set; } = new List<SubjectCurriculum>();

    // Concurrent courses (can register in same semester)
    public ICollection<SubjectCurriculum> ConcurrentCourses { get; set; } = new List<SubjectCurriculum>();
}

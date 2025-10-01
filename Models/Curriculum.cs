using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Curriculum
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<SubjectCurriculum> SubjectCurriculums { get; set; } = new List<SubjectCurriculum>();
    public ICollection<ElectiveGroup> ElectiveGroups { get; set; } = new List<ElectiveGroup>();
}

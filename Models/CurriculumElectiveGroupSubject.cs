using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models;

namespace UniversityRegistration.Models;

public class CurriculumElectiveGroupSubject
{
    [MaxLength(10)]
    public string ElectiveGroupId { get; set; } = string.Empty;
    public CurriculumElectiveGroup ElectiveGroup { get; set; } = null!;

    [MaxLength(10)]
    public string SubjectId { get; set; } = string.Empty;
    public Subject Subject { get; set; } = null!;
}

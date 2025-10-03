using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models;

namespace UniversityRegistration.Models;

public class CurriculumTermSubject
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string CurriculumTermId { get; set; } = string.Empty;
    public CurriculumTerm CurriculumTerm { get; set; } = null!;

    [MaxLength(10)]
    public string SubjectId { get; set; } = string.Empty;
    public Subject Subject { get; set; } = null!;
}

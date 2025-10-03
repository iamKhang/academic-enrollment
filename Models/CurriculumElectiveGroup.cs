using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models;

namespace UniversityRegistration.Models;

public class CurriculumElectiveGroup
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string CurriculumTermId { get; set; } = string.Empty;
    public CurriculumTerm CurriculumTerm { get; set; } = null!;

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int MinCredits { get; set; } // Ví dụ: tối thiểu 4 tín chỉ

    public ICollection<CurriculumElectiveGroupSubject> Subjects { get; set; } 
        = new List<CurriculumElectiveGroupSubject>();
}

using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models;

namespace UniversityRegistration.Models;

public class CurriculumTerm
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string CurriculumId { get; set; } = string.Empty;
    public Curriculum Curriculum { get; set; } = null!;

    public int TermOrder { get; set; } // Ví dụ: 1, 2, 3...

    // Môn bắt buộc trong kỳ
    public ICollection<CurriculumTermSubject> RequiredSubjects { get; set; } 
        = new List<CurriculumTermSubject>();

    // Nhóm tự chọn trong kỳ
    public ICollection<CurriculumElectiveGroup> ElectiveGroups { get; set; } 
        = new List<CurriculumElectiveGroup>();
}

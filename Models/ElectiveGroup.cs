using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class ElectiveGroup
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string CurriculumId { get; set; } = string.Empty;
    public Curriculum Curriculum { get; set; } = null!;

    public int Semester { get; set; }               // ← NEW: nhóm này áp dụng cho học kỳ nào

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int RequiredCredits { get; set; }        // nếu chỉ kiểm theo kỳ, có thể để 0

    public ICollection<SubjectCurriculumElectiveGroup> SubjectCurricula { get; set; }
        = new List<SubjectCurriculumElectiveGroup>();
}

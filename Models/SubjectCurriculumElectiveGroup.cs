using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

// Bảng nối m-n
public class SubjectCurriculumElectiveGroup
{
    [MaxLength(10)]
    public string SubjectCurriculumId { get; set; } = string.Empty;
    public SubjectCurriculum SubjectCurriculum { get; set; } = null!;

    [MaxLength(10)]
    public string ElectiveGroupId { get; set; } = string.Empty;
    public ElectiveGroup ElectiveGroup { get; set; } = null!;
}

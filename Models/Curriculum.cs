using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Curriculum
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    // Mỗi chương trình khung có nhiều kỳ học
    public ICollection<CurriculumTerm> Terms { get; set; } = new List<CurriculumTerm>();
}

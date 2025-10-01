using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class ProgramCohort
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [MaxLength(10)]
    public string DepartmentId { get; set; } = string.Empty;
    public Department Department { get; set; } = null!;

    [MaxLength(10)]
    public string CurriculumId { get; set; } = string.Empty;
    public Curriculum Curriculum { get; set; } = null!;

    public ICollection<Class> Classes { get; set; } = new List<Class>();
}

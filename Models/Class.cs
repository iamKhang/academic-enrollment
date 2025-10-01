using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Class
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(10)]
    public string ProgramCohortId { get; set; } = string.Empty;
    public ProgramCohort ProgramCohort { get; set; } = null!;

    public ICollection<Student> Students { get; set; } = new List<Student>();
}

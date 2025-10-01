using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Department
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<ProgramCohort> ProgramCohorts { get; set; } = new List<ProgramCohort>();

    public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

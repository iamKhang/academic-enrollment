using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Student
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(10)]
    public string StudentCode { get; set; } = string.Empty;
    [MaxLength(50)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(10)]
    public string ClassId { get; set; } = string.Empty;
    public Class Class { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Semester
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();
}

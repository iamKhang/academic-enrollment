using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class SubjectLecturer
{
    [MaxLength(10)]
    public string SubjectId { get; set; } = string.Empty;
    public Subject Subject { get; set; } = null!;

    [MaxLength(10)]
    public string LecturerId { get; set; } = string.Empty;
    public Lecturer Lecturer { get; set; } = null!;
}

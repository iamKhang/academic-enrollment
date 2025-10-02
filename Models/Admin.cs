using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Admin
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastLoginAt { get; set; }
    public bool IsActive { get; set; } = true;
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Building
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty; // e.g., "A", "B"

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty; // e.g., "Tòa A"

    [MaxLength(10)]
    public string CampusId { get; set; } = string.Empty;

    public Campus? Campus { get; set; }

    public ICollection<Floor> Floors { get; set; } = new List<Floor>();
}



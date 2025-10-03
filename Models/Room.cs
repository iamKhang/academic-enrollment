using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models.Enums;

namespace UniversityRegistration.Models;

public class Room
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public RoomType RoomType { get; set; } = RoomType.Other;
    [MaxLength(150)]
    public string Location { get; set; } = string.Empty;

    // Hierarchy: Campus -> Building -> Floor -> Room
    [MaxLength(100)]
    public string Campus { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Building { get; set; } = string.Empty;

    public int Floor { get; set; }

    // Optional foreign keys to hierarchical entities
    [MaxLength(10)]
    public string? CampusId { get; set; }

    [MaxLength(10)]
    public string? BuildingId { get; set; }

    [MaxLength(20)]
    public string? FloorId { get; set; }

    // Navigation properties (named *Ref to avoid clashing with scalar fields)
    public Campus? CampusRef { get; set; }
    public Building? BuildingRef { get; set; }
    public Floor? FloorRef { get; set; }

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}

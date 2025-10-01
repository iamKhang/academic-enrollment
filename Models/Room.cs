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

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}

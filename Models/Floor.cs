using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistration.Models;

public class Floor
{
    [MaxLength(20)]
    public string Id { get; set; } = string.Empty; // e.g., "A-1@CS1"

    public int Number { get; set; }

    [MaxLength(10)]
    public string BuildingId { get; set; } = string.Empty;

    public Building? Building { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}





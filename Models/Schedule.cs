using System;
using System.ComponentModel.DataAnnotations;
using UniversityRegistration.Models.Enums;

namespace UniversityRegistration.Models;

public class Schedule
{
    [MaxLength(10)]
    public string Id { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? CourseClassId { get; set; }
    public CourseClass? CourseClass { get; set; }

    [MaxLength(10)]
    public string? PracticeGroupId { get; set; }
    public PracticeGroup? PracticeGroup { get; set; }

    public WeekDay DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }

    [MaxLength(10)]
    public string RoomId { get; set; } = string.Empty;
    public Room Room { get; set; } = null!;
}

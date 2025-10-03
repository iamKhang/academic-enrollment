using UniversityRegistration.Models.Enums;

namespace UniversityRegistration.Models;

public class GradeDetail
{
    public int Id { get; set; }
    public int GradeId { get; set; }
    public Grade Grade { get; set; } = null!;

    public GradeComponentType ComponentType { get; set; }
    public string Name { get; set; } = string.Empty;  
    public decimal Score { get; set; }              
}

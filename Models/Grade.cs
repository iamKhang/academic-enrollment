namespace UniversityRegistration.Models;

public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ClassId { get; set; }

    public decimal? MidtermScore { get; set; }
    public decimal? FinalScore { get; set; }
    public decimal? TotalScore10 { get; set; }
    public decimal? TotalScore4 { get; set; }
    public string? LetterGrade { get; set; }

    public ICollection<GradeDetail> GradeDetails { get; set; } = new List<GradeDetail>();
}

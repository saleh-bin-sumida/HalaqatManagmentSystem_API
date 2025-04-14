namespace HalaqatManagmentSystem_API.Dtos;


public record class TeachingAssingmentDto
{
    public int Id { get; set; }
    public Guid TeacherId { get; set; }
    public string? TeacherFirstName { get; set; }
    public int Halaqa_Id { get; set; }
    public string? HalaqaName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }
}

namespace HalaqatManagmentSystem_API.Dtos;

public record class StudentEnrollmentDto
{
    public int Id { get; set; }
    public Guid StudentId { get; set; }
    public int HalaqaId { get; set; }
    public string? FullName { get; set; }
    public string? EnrolledToHalaqa { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }

}

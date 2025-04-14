namespace HalaqatManagmentSystem_API.Entities;

public class StudentAttendance
{
    public int Id { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public int HalaqaId { get; set; }
    public Halaqa Halaqa { get; set; }
    public DateOnly AttendanceDate { get; set; }
    public AttendanceStatus Status { get; set; }
    public string? Remarks { get; set; }
}



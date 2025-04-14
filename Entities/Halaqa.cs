
namespace HalaqatManagmentSystem_API.Entities;

public class Halaqa
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guid? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }

    public ICollection<Student>? Students { get; set; }
    public ICollection<StudentHalaqaEnrollment> EnrollmentsHistories { get; set; }
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; }
    public ICollection<StudentAttendance> StudentAttendances { get; set; }

}

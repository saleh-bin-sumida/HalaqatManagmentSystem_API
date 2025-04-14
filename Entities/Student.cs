
namespace HalaqatManagmentSystem_API.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool Gender { get; set; } = true;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }

    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public Surah LastMemorizedSurah { get; set; }
    public QuranicNarration QuranicNarration { get; set; }
    public SchoolGrade SchoolGrade { get; set; }
    public int SerialNumber { get; set; }

    public int? HalaqaId { get; set; }
    public Halaqa? Halaqa { get; set; }
    public Guid? GuardianId { get; set; }
    public Guardian? Guardian { get; set; }
    public GuardianKinship? GuardianKinship { get; set; }

    public ICollection<StudentHalaqaEnrollment> EnrollmentsHistories { get; set; } = new List<StudentHalaqaEnrollment>();
    public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

}


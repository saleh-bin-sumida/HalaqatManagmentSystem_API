
namespace HalaqatManagmentSystem_API.Dtos;


public record class GetStudentNameDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

}




public record class GetStudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; }

    public int Age { get; set; }

    public string? HalaqaName { get; set; }

    public SchoolGrade SchoolGrade { get; set; }
    public int? HalaqaId { get; set; }
}

public class GetStudentFullInfoDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SerialNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; }

    public string? PhoneNumber { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }

    public Guid? GuardianId { get; set; }
    public string GuardianFullName { get; set; }
    public string GuardianPhoneNumber { get; set; }

    public GuardianKinship? GuardianKinship { get; set; }
    public int? HalaqaId { get; set; }
    public string? HalaqaName { get; set; }
    public Surah LastMemorizedSurah { get; set; }
    public SchoolGrade SchoolGrade { get; set; }
}


public class AddStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; } = true;
    [Phone]
    public string? PhoneNumber { get; set; }
    public string Neighborhood { get; set; }
    public string? City { get; set; }

    public Guid GuardianId { get; set; }
    public GuardianKinship GuardianKinship { get; set; }
    //public int? HalaqaId { get; set; }
    public Surah LastMemorizedSurah { get; set; }
    public SchoolGrade SchoolGrade { get; set; }
}

public class UpdateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; } = true;
    [Phone]

    public string? PhoneNumber { get; set; }
    public string Neighborhood { get; set; }
    public string? City { get; set; }

    public Guid? GuardianId { get; set; }
    public GuardianKinship? GuardianKinship { get; set; }
    public Surah LastMemorizedSurah { get; set; }
    public SchoolGrade SchoolGrade { get; set; }
}


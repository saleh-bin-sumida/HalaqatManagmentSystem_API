namespace HalaqatManagmentSystem_API.Dtos;

public record GetTeacherNameDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
};
public record class GetTeacherDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; }
    public string? PhoneNumber { get; set; }
}


public class GetTeacherFullInfoDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string Neighborhood { get; set; }
    public string? City { get; set; }
    public IdentityType IdentityType { get; set; }
    public string? IdentityNumber { get; set; }
    public QuranicNarration QuranicNarration { get; set; }
    public Surah LastMemorizedSurah { get; set; }
}

public class AddTeacherDto
{
    public string FullName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
    public string Neighborhood { get; set; }
    public string? City { get; set; }
    public IdentityType IdentityType { get; set; }
    public string? IdentityNumber { get; set; }
    public QuranicNarration QuranicNarration { get; set; }
    public Surah LastMemorizedSurah { get; set; }
}
public class UpdateTeacherDto
{
    public string FullName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Gender { get; set; }
    [Phone]

    public string? PhoneNumber { get; set; }

    public string? Neighborhood { get; set; }

    public string? City { get; set; }

    public IdentityType IdentityType { get; set; }
    public string? IdentityNumber { get; set; }
    public QuranicNarration QuranicNarration { get; set; }
    public Surah LastMemorizedSurah { get; set; }

}


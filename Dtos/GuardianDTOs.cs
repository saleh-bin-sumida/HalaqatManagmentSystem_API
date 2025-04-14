namespace HalaqatManagmentSystem_API.Dtos;

public record GetGuardianNameDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
}

public class GetGuardianDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; }

    public string? Occupation { get; set; }
    public string? PhoneNumber { get; set; }
}

public class GetGuardianFullInfoDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; } = true;
    public string? PhoneNumber { get; set; }


    public string? Occupation { get; set; }


    public IdentityType IdentityType { get; set; }
    public string? IdentityNumber { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public ICollection<GetStudentNameDto> Students { get; set; }
}


public class AddGuardianDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; } = true;
    [Phone]
    public string PhoneNumber { get; set; }
    public string? Occupation { get; set; }

    public IdentityType IdentityType { get; set; }

    public string? IdentityNumber { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
}

public class UpdateGuardianDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; } = true;
    [Phone]
    public string PhoneNumber { get; set; }
    public string? Occupation { get; set; }


    public IdentityType IdentityType { get; set; }

    public string? IdentityNumber { get; set; }
    public MaritalStatus MaritalStatus { get; set; }


}

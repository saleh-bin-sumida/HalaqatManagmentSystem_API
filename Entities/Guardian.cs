
namespace HalaqatManagmentSystem_API.Entities;

public class Guardian
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool Gender { get; set; } = true;
    public string PhoneNumber { get; set; }
    public IdentityType IdentityType { get; set; }
    public string? IdentityNumber { get; set; }
    public string? Occupation { get; set; }
    public MaritalStatus MaritalStatus { get; set; }

    public ICollection<Student>? Students { get; set; }
}


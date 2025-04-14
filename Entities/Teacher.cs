namespace HalaqatManagmentSystem_API.Entities;

public class Teacher
{

    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool Gender { get; set; } = true;
    public string PhoneNumber { get; set; }

    public DateTime DateOfBirth { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public IdentityType IdentityType { get; set; }
    public string? IdentityNumber { get; set; }
    public Surah LastMemorizedSurah { get; set; }
    public QuranicNarration QuranicNarration { get; set; }


    public ICollection<Halaqa>? Halaqat { get; set; } = new List<Halaqa>();
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
}

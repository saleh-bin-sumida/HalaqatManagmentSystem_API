namespace HalaqatManagmentSystem_API.Dtos;


public record class GetHalaqaNameDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}

public record class GetHalaqaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? TeacherName { get; set; }
    public Guid? TeacherId { get; set; }
    public int? TotalStudents { get; set; }
}





public class AddHalaqaDto
{
    public string Name { get; set; }
    public Guid TeacherId { get; set; }
}

public class UpdateHalaqaDto
{
    public string Name { get; set; }

}

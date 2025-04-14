namespace HalaqatManagmentSystem_API.Dtos;


public record class GetAttendanceDto
{
    public int? AttendanceId { get; set; }
    public Guid StudentId { get; set; }
    public string FullName { get; set; }
    public int HalaqaId { get; set; }
    //public DateOnly AttendanceDate { get; set; }
    public AttendanceStatus? Status { get; set; }
    public string? Remarks { get; set; }

}

public record class GetStudentAttendanceDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public AttendanceStatus AttendanceStatus { get; set; }
    public int HalaqaId { get; set; }
}



public record AddUpdatedAttendanceDto(
    Guid StudentId,
    int HalaqaId,
    DateOnly AttendanceDate,
    [Range(0,4)]
    AttendanceStatus Status,
    string? Remarks);


//public record UpdateAttendanceDto(
//    //Guid? StudentId,
//    //Student? Student,
//    //int? Halaqa_Id,
//    //Halaqa? Halaqa,
//    //DateTime AttendanceDate,
//    [Range(0,4)]
//    AttendanceStatus Status,
//    string? Remarks);

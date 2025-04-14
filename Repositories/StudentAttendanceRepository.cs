namespace HalaqatManagmentSystem_API.Repositories;

public class StudentAttendanceRepository : BaseRepository<StudentAttendance>
{
    public StudentAttendanceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<BaseResponse<IEnumerable<GetAttendanceDto>>> GetAttendancesByHalaqaAsync(int halaqaId, DateOnly date)
    {
        var halaqa = await _context.Halaqat.FindAsync(halaqaId);
        if (halaqa is null)
        {
            return new BaseResponse<IEnumerable<GetAttendanceDto>>
            {
                Success = false,
                Message = "No Halaqa with that Id"
            };
        }

        var result = await GetAllDataWithSelectionAsync(
            orderBy: x => x.Student.FirstName,
            selector: x => x.ToGetAttendanceDto(),
            criteria: x => x.HalaqaId == halaqaId && x.AttendanceDate == date,
            includes: x => x.Student
        );

        return new BaseResponse<IEnumerable<GetAttendanceDto>>
        {
            Success = true,
            Data = result
        };
    }

    public async Task<BaseResponse<string>> AddOrUpdateAttendancesAsync(List<AddUpdatedAttendanceDto> attendancesDto)
    {
        List<StudentAttendance> newAttendances = new();
        foreach (var record in attendancesDto)
        {
            var existingAttendance = await FindAsync(
                x => x.StudentId == record.StudentId && x.AttendanceDate == record.AttendanceDate
            );

            if (existingAttendance != null)
            {
                existingAttendance.Status = record.Status;
                existingAttendance.Remarks = record.Remarks;
                existingAttendance.UpdateStudentAttendance(record);
            }
            else
            {
                newAttendances.Add(record.ToStudentAttendance());
            }
        }

        if (newAttendances.Any())
        {
            await AddRangeAsync(newAttendances);
        }

        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Data = "Attendances added or updated successfully"
        };
    }

    public async Task<BaseResponse<string>> DeleteAttendanceAsync(List<int> attendanceIds)
    {
        var effectedRows = await Where(x => attendanceIds.Contains(x.Id)).ExecuteDeleteAsync();
        if (effectedRows > 0)
        {
            return new BaseResponse<string>
            {
                Success = true,
                Data = "Attendances deleted successfully"
            };
        }

        return new BaseResponse<string>
        {
            Success = false,
            Message = "No attendances found with the provided IDs"
        };
    }
}



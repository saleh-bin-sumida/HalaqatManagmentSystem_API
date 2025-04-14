
namespace HalaqatManagmentSystem_API.Repositories;

public class StudentRepository : BaseRepository<Student>
{
    //public UserManager<AppUser> UserManager { get; }
    //public RoleManager<AppRole> RoleManager { get; }

    public StudentRepository(
        AppDbContext context

    ) : base(context)
    {
    }

    public async Task<BaseResponse<PagedResult<GetStudentDto>>> GetAllStudentsAsync(
        int pageSize,
        int pageNumber,
        string? searchTerm = null,
        int? halaqaId = null,
        SchoolGrade? schoolGrade = null,
        //IEnumerable<int>? yearsOfBirth = null,
        bool? gender = null)
    {
        Expression<Func<Student, bool>> filter = x => true;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = filter.AndAlso(x => x.FirstName.Contains(searchTerm) ||
                                         x.LastName.Contains(searchTerm));
        }

        if (halaqaId.HasValue)
            filter = filter.AndAlso(x => x.HalaqaId == halaqaId);



        if (schoolGrade.HasValue)
            filter = filter.AndAlso(x => x.SchoolGrade == schoolGrade);

        //if (yearsOfBirth != null && yearsOfBirth.Any())
        //    filter = filter.AndAlso(x => yearsOfBirth.Contains(x.DateOfBirth.Year));

        if (gender.HasValue)
            filter = filter.AndAlso(x => x.Gender == gender);

        var pagedResult = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.FirstName,
            selector: StudentProfile.ToGetStudentDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize
        );

        return new BaseResponse<PagedResult<GetStudentDto>>
        {
            Success = true,
            Data = pagedResult
        };
    }


    public async Task<BaseResponse<GetStudentDto?>> GetStudentByIdAsync(Guid id)
    {
        var student = await FindWithSelectionAsync(
            selector: StudentProfile.ToGetStudentDto(),
            criteria: x => x.Id == id
        );

        if (student == null)
        {
            return new BaseResponse<GetStudentDto?>
            {
                Success = false,
                Message = $"No student found with ID {id}"
            };
        }

        return new BaseResponse<GetStudentDto?>
        {
            Success = true,
            Data = student
        };
    }

    public async Task<BaseResponse<GetStudentFullInfoDto>> GetStudentFullInfoByIdAsync(Guid id)
    {
        var student = await FindWithSelectionAsync(
            selector: StudentProfile.ToGetStudentFullInfoDto(),
            criteria: x => x.Id == id
        );

        if (student == null)
        {
            return new BaseResponse<GetStudentFullInfoDto>
            {
                Success = false,
                Message = $"No student found with ID {id}"
            };
        }

        return new BaseResponse<GetStudentFullInfoDto>
        {
            Success = true,
            Data = student
        };
    }


    public async Task<BaseResponse<IEnumerable<GetStudentNameDto>>> GetStudentsByHalaqaAsync(
        int halaqaId,
        string? searchTerm = null
    )
    {
        Expression<Func<Student, bool>> filter = x => x.HalaqaId == halaqaId;
        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = filter.AndAlso(x => x.FirstName.Contains(searchTerm) ||
                                         x.LastName.Contains(searchTerm));
        }

        var students = await GetAllDataWithSelectionAsync(
            orderBy: x => x.FirstName,
            selector: StudentProfile.ToGetStudentNameDto(),
            criteria: filter
        );

        return new BaseResponse<IEnumerable<GetStudentNameDto>>
        {
            Success = true,
            Data = students
        };
    }

    public async Task<BaseResponse<string>> AddStudentAsync(AddStudentDto studentDto)
    {
        if (!await _context.Guardians.AnyAsync(g => g.Id == studentDto.GuardianId))
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No guardian found with ID {studentDto.GuardianId}"
            };



        var newStudent = studentDto.ToStudent();
        await AddAsync(newStudent);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Data = "Student Added Suseccfully"
        };
    }

    public async Task<BaseResponse<string>> UpdateStudentAsync(Guid id, UpdateStudentDto studentDto)
    {
        var student = await GetByIdAsync(id);
        if (student == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No student found with ID {id}"
            };
        }

        if (!await _context.Guardians.AnyAsync(g => g.Id == studentDto.GuardianId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No guardian found with ID {studentDto.GuardianId}"
            };
        }


        student.UpdateStudent(studentDto);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Data = student.Id.ToString(),
            Message = "Student Updated Suseccfully"
        };
    }

    public async Task<BaseResponse<string>> DeleteStudentAsync(Guid id)
    {
        var studentToDelete = await GetByIdAsync(id);
        if (studentToDelete == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No student found with ID {id}"
            };
        }

        Delete(studentToDelete);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Data = id.ToString(),
            Message = "Student deleted successfully"
        };
    }

    public async Task<BaseResponse<string>> DeleteRangeStudentsAsync(List<Guid> ids)
    {
        try
        {
            await _context.Students
                .Where(e => ids.Contains(e.Id))
                .ExecuteDeleteAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = $"{ids.Count} Students deleted successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = ex.Message
            };
        }
    }


    public async Task<BaseResponse<List<GetStudentNameDto>>> GetStudentsNamesNotLinkedToHalaqaAsync()
    {

        var result = await GetAllDataWithSelectionAsync(
            orderBy: x => x.FirstName,
            criteria: x => x.HalaqaId == null,
            selector: StudentProfile.ToGetStudentNameDto()
        );

        return new BaseResponse<List<GetStudentNameDto>>
        {
            Success = true,
            Data = result
        };
    }


}


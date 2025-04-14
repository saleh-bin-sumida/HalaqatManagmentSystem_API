namespace HalaqatManagmentSystem_API.Repositories;

public class HalaqaRepository : BaseRepository<Halaqa>
{
    public HalaqaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<BaseResponse<PagedResult<GetHalaqaDto>>> GetAllHalaqatAsync(
        int pageSize,
        int pageNumber,
        string? searchTerm = null
    )
    {
        Expression<Func<Halaqa, bool>>? filter = null;
        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = x => x.Name.Contains(searchTerm);
        }

        var result = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: HalaqaProfile.ToGetHalaqaDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize
        );

        return new BaseResponse<PagedResult<GetHalaqaDto>>
        {
            Success = true,
            Data = result
        };
    }

    public async Task<BaseResponse<PagedResult<GetHalaqaDto>>> GetAllHalaqatAssignedToTeacherAsync(
        Guid teacherId,
        int pageSize,
        int pageNumber,
        string? searchTerm = null
    )
    {
        Expression<Func<Halaqa, bool>> filter = x => x.TeacherId == teacherId;
        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = filter.AndAlso(x => x.Name.Contains(searchTerm));
        }

        var result = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: HalaqaProfile.ToGetHalaqaDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize
        );

        return new BaseResponse<PagedResult<GetHalaqaDto>>
        {
            Success = true,
            Data = result
        };
    }

    public async Task<BaseResponse<GetHalaqaDto>> GetHalaqaByIdAsync(int id)
    {
        var halaqa = await FindWithSelectionAsync(
            selector: HalaqaProfile.ToGetHalaqaDto(),
            criteria: x => x.Id == id
        );

        if (halaqa is null)
        {
            return new BaseResponse<GetHalaqaDto>
            {
                Success = false,
                Message = "No halaqa with that Id"
            };
        }

        return new BaseResponse<GetHalaqaDto>
        {
            Success = true,
            Data = halaqa
        };
    }



    public async Task<BaseResponse<string>> AddStudentToHalaqaAsync(Guid studentId, int halaqaId)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No student found with ID {studentId}"
            };
        }

        if (!await _context.Halaqat.AnyAsync(g => g.Id == halaqaId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No halaqa found with ID {halaqaId}"
            };
        }

        student.HalaqaId = halaqaId;
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Data = student.Id.ToString(),
            Message = "Student Linked to halaqa Sussccfully"
        };
    }

    public async Task<BaseResponse<string>> AddStudentsToHalaqaAsync(List<Guid> Ids, int halaqaId)
    {

        if (!await _context.Halaqat.AnyAsync(g => g.Id == halaqaId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"No halaqa found with ID {halaqaId}"
            };
        }

        var students = _context.Students.Where(x => Ids.Contains(x.Id)).ToList();
        foreach (var student in students)
        {
            student.HalaqaId = halaqaId;
        }

        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Students Linked to halaqa Sussccfully"
        };
    }

    public async Task<BaseResponse<string>> DeleteStudentFromHalaqa(Guid studentId)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "Student not found"
            };
        }

        student.HalaqaId = null;
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Student removed from Halaqa successfully"
        };
    }

    public async Task<BaseResponse<string>> AddHalaqaAsync(AddHalaqaDto halaqaDto)
    {

        if (!await _context.Teachers.AnyAsync(t => t.Id == halaqaDto.TeacherId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "Invalid TeacherId"
            };
        }

        var newHalaqa = halaqaDto.ToHalaqa();
        await AddAsync(newHalaqa);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Halaqa added successfully"
        };
    }

    public async Task<BaseResponse<string>> UpdateHalaqaAsync(int id, UpdateHalaqaDto halaqaDto)
    {
        var halaqa = await GetByIdAsync(id);
        if (halaqa == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "No Halaqa with that Id"
            };
        }

        halaqa.UpdateHalaqa(halaqaDto);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Halaqa updated successfully"
        };
    }

    public async Task<BaseResponse<string>> DeleteHalaqaAsync(int id)
    {
        var halaqaToDelete = await GetByIdAsync(id);
        if (halaqaToDelete == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "No Halaqa with that Id"
            };
        }

        Delete(halaqaToDelete);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Halaqa deleted successfully"
        };
    }

    public async Task<BaseResponse<PagedResult<GetHalaqaNameDto>>> GetAllHalaqatNamesAsync(
        int pageSize,
        int pageNumber,
        string? searchTerm = null
    )
    {
        Expression<Func<Halaqa, bool>>? filter = null;
        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = x => x.Name.Contains(searchTerm);
        }

        var result = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: HalaqaProfile.ToGetHalaqaNameDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize
        );

        return new BaseResponse<PagedResult<GetHalaqaNameDto>>
        {
            Success = true,
            Data = result
        };
    }


}


using Microsoft.EntityFrameworkCore;

namespace HalaqatManagmentSystem_API.Repositories;

public class GuardianRepository : BaseRepository<Guardian>
{


    public GuardianRepository(
        AppDbContext context) : base(context)
    {

    }

    public async Task<BaseResponse<PagedResult<GetGuardianDto>>> GetAllGuardiansAsync(
        int pageSize,
        int pageNumber,
        string? searchTerm = null,
        bool? gender = null)
    {
        Expression<Func<Guardian, bool>>? filter = null;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            var searchTermLower = searchTerm.ToLower();
            filter = x =>
                (x.FirstName != null && x.FirstName.ToLower().Contains(searchTermLower)) ||
                (x.LastName != null && x.LastName.ToLower().Contains(searchTermLower)) ||
                (x.PhoneNumber != null && x.PhoneNumber.Contains(searchTerm));
        }

        if (gender.HasValue)
        {
            filter = filter == null
                ? x => x.Gender == gender
                : filter.AndAlso(x => x.Gender == gender);
        }

        var result = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.FirstName,
            selector: GuardianProfile.ToGetGuardianDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize);

        return new BaseResponse<PagedResult<GetGuardianDto>>
        {
            Success = true,
            Message = "Guardians retrieved successfully",
            Data = result
        };
    }

    public async Task<BaseResponse<GetGuardianDto>> GetGuardianByIdAsync(Guid id)
    {
        var guardian = await FindWithSelectionAsync(
            selector: GuardianProfile.ToGetGuardianDto(),
            criteria: x => x.Id == id);

        if (guardian == null)
        {
            return new BaseResponse<GetGuardianDto>
            {
                Success = false,
                Message = "No guardian with that Id",
                Data = null
            };
        }

        return new BaseResponse<GetGuardianDto>
        {
            Success = true,
            Message = "Guardian retrieved successfully",
            Data = guardian
        };
    }

    public async Task<BaseResponse<GetGuardianFullInfoDto>> GetGuardianFullInfoByIdAsync(Guid id)
    {
        var guardian = await FindWithSelectionAsync(
            selector: GuardianProfile.ToGetGuardianFullInfoDto(),
            criteria: x => x.Id == id);

        if (guardian == null)
        {
            return new BaseResponse<GetGuardianFullInfoDto>
            {
                Success = false,
                Message = "No guardian with that Id",
                Data = null
            };
        }

        var guardianStudents = await _context.Students
            .Where(x => x.GuardianId == guardian.Id)
            .Select(StudentProfile.ToGetStudentNameDto())
            .ToListAsync();

        guardian!.Students = guardianStudents;

        return new BaseResponse<GetGuardianFullInfoDto>
        {
            Success = true,
            Message = "Guardian full info retrieved successfully",
            Data = guardian
        };
    }

    public async Task<BaseResponse<string>> AddGuardianAsync(AddGuardianDto guardianDto)
    {


        var newGuardian = guardianDto.ToGuardian();
        await AddAsync(newGuardian);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Guardian saved successfully",
            Data = newGuardian.Id.ToString()
        };
    }

    public async Task<BaseResponse<string>> UpdateGuardianAsync(Guid id, UpdateGuardianDto guardianDto)
    {
        var guardian = await GetByIdAsync(id);
        if (guardian == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "No Guardian with that Id",
            };
        }

        guardian.UpdateGuardian(guardianDto);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "Guardian updated successfully",
        };
    }

    public async Task<BaseResponse<string>> DeleteGuardianAsync(Guid id)
    {
        var guardianToDelete = await GetByIdAsync(id);
        if (guardianToDelete == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "No Guardian with that Id",
            };
        }


        Delete(guardianToDelete);
        await _context.SaveChangesAsync();

        await _context.Students.Where(x => x.GuardianId == guardianToDelete.Id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.GuardianId, (Guid?)null)
                .SetProperty(s => s.GuardianKinship, (GuardianKinship?)null));


        return new BaseResponse<string>
        {
            Success = true,
            Message = "Guardian deleted successfully",
        };
    }

    public async Task<BaseResponse<string>> DeleteRangeGuardiansAsync(List<Guid> ids)
    {
        try
        {
            var effected = await _context.Guardians
                .Where(e => ids.Contains(e.Id)) // Filter by the provided IDs
                .ExecuteDeleteAsync();

            await _context.Students.Where(x => ids.Contains(x.GuardianId.Value))
                       .ExecuteUpdateAsync(setters => setters
                           .SetProperty(s => s.GuardianId, (Guid?)null)
                           .SetProperty(s => s.GuardianKinship, (GuardianKinship?)null));

            return new BaseResponse<string>
            {
                Success = true,
                Message = $"{effected} guardians deleted successfully"
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

    public async Task<BaseResponse<PagedResult<GetGuardianNameDto>>> GetAllGuardiansNamesAsync(
        int pageSize,
        int pageNumber)
    {
        var result = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.FirstName,
            selector: GuardianProfile.ToGetGuardianNameDto(),
            criteria: null,
            pageNumber: pageNumber,
            pageSize: pageSize);

        return new BaseResponse<PagedResult<GetGuardianNameDto>>
        {
            Success = true,
            Message = "Guardian names retrieved successfully",
            Data = result
        };
    }
}

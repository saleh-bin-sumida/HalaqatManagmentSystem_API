
using Microsoft.EntityFrameworkCore;

namespace HalaqatManagmentSystem_API.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {


        public TeacherRepository(
            AppDbContext context

        ) : base(context)
        {

        }

        public async Task<BaseResponse<PagedResult<GetTeacherDto>>> GetAllTeachersAsync(
            int pageSize,
            int pageNumber,
            string? searchTerm = null
        )
        {
            Expression<Func<Teacher, bool>>? filter = null;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter = x => x.FirstName != null && x.FirstName.Contains(searchTerm) ||
                              x.LastName != null && x.LastName.Contains(searchTerm) ||
                              x.PhoneNumber != null && x.PhoneNumber.Contains(searchTerm);
            }

            var result = await GetPagedDataWithSelectionAsync(
                orderBy: x => x.FirstName,
                selector: TeacherProfile.ToGetTeacherDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize
            );

            return new BaseResponse<PagedResult<GetTeacherDto>>
            {
                Success = true,
                Message = "Teachers retrieved successfully",
                Data = result
            };
        }

        public async Task<BaseResponse<PagedResult<GetTeacherNameDto>>> GetTeachersNamesAsync(
            int pageSize,
            int pageNumber
        )
        {
            var result = await GetPagedDataWithSelectionAsync(
                orderBy: x => x.FirstName,
                selector: TeacherProfile.ToGetTeacherNameDto(),
                criteria: null,
                pageNumber: pageNumber,
                pageSize: pageSize
            );

            return new BaseResponse<PagedResult<GetTeacherNameDto>>
            {
                Success = true,
                Message = "Teacher names retrieved successfully",
                Data = result
            };
        }

        //public async Task<BaseResponse<PagedResult<GetTeacherDto>>> GetAllTeachersInLevelAsync(
        //    int levelId,
        //    int pageSize,
        //    int pageNumber,
        //    string? searchTerm = null
        //)
        //{
        //    Expression<Func<Teacher, bool>> filter = x => x.Halaqat.Any(h => h.LevelId == levelId);

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        filter = filter.AndAlso(x =>
        //            x.FirstName != null && x.FirstName.Contains(searchTerm) ||
        //            x.LastName != null && x.LastName.Contains(searchTerm) ||
        //            x.PhoneNumber != null && x.PhoneNumber.Contains(searchTerm)
        //        );
        //    }

        //    var result = await GetPagedDataWithSelectionAsync(
        //        orderBy: x => x.FirstName,
        //        selector: TeacherProfile.ToGetTeacherDto(),
        //        criteria: filter,
        //        pageNumber: pageNumber,
        //        pageSize: pageSize
        //    );

        //    return new BaseResponse<PagedResult<GetTeacherDto>>
        //    {
        //        Success = true,
        //        Message = "Teachers in level retrieved successfully",
        //        Data = result
        //    };
        //}

        public async Task<BaseResponse<GetTeacherDto>> GetTeacherByIdAsync(Guid id)
        {
            var teacher = await FindWithSelectionAsync(
                selector: TeacherProfile.ToGetTeacherDto(),
                criteria: x => x.Id == id
            );

            if (teacher == null)
            {
                return new BaseResponse<GetTeacherDto>
                {
                    Success = false,
                    Message = "No teacher with that Id",
                    Data = null
                };
            }

            return new BaseResponse<GetTeacherDto>
            {
                Success = true,
                Message = "Teacher retrieved successfully",
                Data = teacher
            };
        }

        public async Task<BaseResponse<GetTeacherFullInfoDto>> GetTeacherFullInfoByIdAsync(Guid id)
        {
            var teacher = await FindWithSelectionAsync(
                selector: x => x.ToGetTeacherFullInfoDto(),
                criteria: x => x.Id == id
            );

            if (teacher == null)
            {
                return new BaseResponse<GetTeacherFullInfoDto>
                {
                    Success = false,
                    Message = "No teacher with that Id",
                    Data = null
                };
            }

            return new BaseResponse<GetTeacherFullInfoDto>
            {
                Success = true,
                Message = "Teacher full info retrieved successfully",
                Data = teacher
            };
        }

        public async Task<BaseResponse<string>> AddTeacherAsync(AddTeacherDto teacherDto)
        {
            var newTeacher = teacherDto.ToTeacher();
            await AddAsync(newTeacher);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Teacher Added Successfully",
                Data = newTeacher.Id.ToString()
            };
        }

        public async Task<BaseResponse<string>> UpdateTeacherAsync(Guid Id, UpdateTeacherDto teacherDto)
        {
            var teacher = await GetByIdAsync(Id);
            if (teacher == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "No Teacher with that Id",
                };
            }


            teacher.UpdateTeacher(teacherDto);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Teacher updated successfully",
            };
        }

        public async Task<BaseResponse<string>> DeleteTeacherAsync(Guid id)
        {
            var teacherToDelete = await GetByIdAsync(id);
            if (teacherToDelete == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "No Teacher with that Id",
                };
            }

            Delete(teacherToDelete);
            await _context.SaveChangesAsync();

            await _context.Halaqat.Where(x => x.TeacherId == teacherToDelete.Id)
                .ExecuteUpdateAsync(x => x.SetProperty(h => h.TeacherId, (Guid?)null));


            return new BaseResponse<string>
            {
                Success = true,
                Message = "Teacher deleted successfully",
            };
        }

        public async Task<BaseResponse<string>> DeleteRangeTeachersAsync(List<Guid> Ids)
        {
            var teachersToDelete = await Where(x => Ids.Contains(x.Id)).ToListAsync();
            if (!teachersToDelete.Any())
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "No Teachers with the provided Ids",
                };
            }

            await DeleteRange(teachersToDelete);
            await _context.SaveChangesAsync();


            await _context.Halaqat
                .Where(x => Ids.Contains(x.TeacherId.Value))
                .ExecuteUpdateAsync(x => x.SetProperty(h => h.TeacherId, (Guid?)null));


            return new BaseResponse<string>
            {
                Success = true,
                Message = $"{Ids.Count} Teachers deleted successfully",
            };
        }

        public async Task<BaseResponse<string>> AssignTeacherToHalaqa(Guid TeacherId, int Halaqa_Id)
        {
            var teacher = await GetByIdAsync(TeacherId);
            if (teacher == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "No Teacher with that Id",
                };
            }

            var halaqa = await _context.Halaqat.FindAsync(Halaqa_Id);
            if (halaqa == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "No Halaqa with that Id",
                };
            }

            halaqa.TeacherId = TeacherId;
            _context.Halaqat.Update(halaqa);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Teacher assigned to Halaqa successfully",
            };
        }
    }
}

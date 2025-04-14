namespace HalaqatManagmentSystem_API.Mapping;

public static class TeacherProfile
{
    public static Expression<Func<Teacher, GetTeacherNameDto>> ToGetTeacherNameDto()
    {
        return teacher => new GetTeacherNameDto
        {
            Id = teacher.Id,
            FullName = teacher.FirstName + " " + teacher.LastName,
        };
    }

    public static Expression<Func<Teacher, GetTeacherDto>> ToGetTeacherDto()
    {
        return teacher => new GetTeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Gender = teacher.Gender,
            PhoneNumber = teacher.PhoneNumber,
        };
    }

    public static GetTeacherFullInfoDto ToGetTeacherFullInfoDto(this Teacher teacher)
    {
        return new GetTeacherFullInfoDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            DateOfBirth = teacher.DateOfBirth,
            Gender = teacher.Gender,
            PhoneNumber = teacher.PhoneNumber,
            Neighborhood = teacher.Neighborhood!,
            City = teacher.City,
            IdentityType = teacher.IdentityType,
            IdentityNumber = teacher.IdentityNumber,
            LastMemorizedSurah = teacher.LastMemorizedSurah
        };
    }

    public static Teacher ToTeacher(this AddTeacherDto addTeacherDto)
    {
        var teacher = new Teacher
        {
            FirstName = addTeacherDto.FullName,
            LastName = addTeacherDto.LastName,
            DateOfBirth = addTeacherDto.DateOfBirth,
            Gender = addTeacherDto.Gender,
            PhoneNumber = addTeacherDto.PhoneNumber,
            Neighborhood = addTeacherDto.Neighborhood,
            LastMemorizedSurah = addTeacherDto.LastMemorizedSurah,
            City = addTeacherDto.City,
            IdentityType = addTeacherDto.IdentityType,
            IdentityNumber = addTeacherDto.IdentityNumber,
        };

        return teacher;
    }

    public static void UpdateTeacher(this Teacher teacher, UpdateTeacherDto updateTeacherDto)
    {
        teacher.FirstName = updateTeacherDto.FullName;
        teacher.LastName = updateTeacherDto.LastName;
        teacher.DateOfBirth = updateTeacherDto.DateOfBirth;
        teacher.Gender = updateTeacherDto.Gender;
        teacher.PhoneNumber = updateTeacherDto.PhoneNumber;
        teacher.LastMemorizedSurah = updateTeacherDto.LastMemorizedSurah;
        teacher.Neighborhood = updateTeacherDto.Neighborhood;
        teacher.City = updateTeacherDto.City;
        teacher.IdentityType = updateTeacherDto.IdentityType;
        teacher.IdentityNumber = updateTeacherDto.IdentityNumber;
    }
}


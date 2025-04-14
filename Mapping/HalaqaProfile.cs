namespace HalaqatSchoolSystem.Core.Mapping;

public static class HalaqaProfile
{
    public static Expression<Func<Halaqa, GetHalaqaNameDto>> ToGetHalaqaNameDto()
    {
        return halaqa => new GetHalaqaNameDto
        {
            Id = halaqa.Id,
            Name = halaqa.Name,
        };
    }

    public static Expression<Func<Halaqa, GetHalaqaDto>> ToGetHalaqaDto()
    {
        return halaqa => new GetHalaqaDto
        {
            Id = halaqa.Id,
            Name = halaqa.Name,
            TeacherName = halaqa.Teacher.FirstName + " " + halaqa.Teacher.LastName,
            TeacherId = halaqa.TeacherId,
            TotalStudents = halaqa.Students.Count
        };
    }

    public static Halaqa ToHalaqa(this AddHalaqaDto addHalaqaDto)
    {
        return new Halaqa
        {
            Name = addHalaqaDto.Name,
            TeacherId = addHalaqaDto.TeacherId,
        };
    }

    public static void UpdateHalaqa(this Halaqa halaqa, UpdateHalaqaDto updateHalaqaDto)
    {
        halaqa.Name = updateHalaqaDto.Name;

    }
}

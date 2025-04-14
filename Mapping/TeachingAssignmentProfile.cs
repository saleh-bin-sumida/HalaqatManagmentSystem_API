namespace HalaqatManagmentSystem_API.Mapping
{
    public static class TeachingAssignmentProfile
    {
        public static TeachingAssingmentDto ToTeachingAssingmentDto(this TeachingAssignment teachingAssignment)
        {
            return new TeachingAssingmentDto
            {
                Id = teachingAssignment.Id,
                TeacherId = teachingAssignment.TeacherId,
                TeacherFirstName = teachingAssignment.Teacher.FirstName,
                Halaqa_Id = teachingAssignment.HalaqaId,
                HalaqaName = teachingAssignment.Halaqa.Name,
                StartDate = teachingAssignment.StartDate,
                EndDate = teachingAssignment.EndDate,
                IsCurrent = teachingAssignment.IsCurrent
            };
        }

        public static TeachingAssignment ToTeachingAssignment(this TeachingAssingmentDto teachingAssingmentDto)
        {
            return new TeachingAssignment
            {
                Id = teachingAssingmentDto.Id,
                TeacherId = teachingAssingmentDto.TeacherId,
                HalaqaId = teachingAssingmentDto.Halaqa_Id,
                StartDate = teachingAssingmentDto.StartDate,
                EndDate = teachingAssingmentDto.EndDate,
                IsCurrent = teachingAssingmentDto.IsCurrent
            };
        }
    }
}



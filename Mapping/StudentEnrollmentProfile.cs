namespace HalaqatManagmentSystem_API.Mapping
{
    public static class StudentEnrollmentProfile
    {
        public static StudentEnrollmentDto ToStudentEnrollmentDto(this StudentHalaqaEnrollment studentEnrollment)
        {
            return new StudentEnrollmentDto
            {
                Id = studentEnrollment.Id,
                StudentId = studentEnrollment.StudentId,
                HalaqaId = studentEnrollment.HalaqaId,
                FullName = studentEnrollment.Student.FirstName + " " + studentEnrollment.Student.LastName,
                EnrolledToHalaqa = studentEnrollment.Halaqa.Name,
                EnrollmentDate = studentEnrollment.StartDate,
                EndDate = studentEnrollment.EndDate,
                IsCurrent = studentEnrollment.IsCurrent
            };
        }

        public static StudentHalaqaEnrollment ToStudentEnrollment(this StudentEnrollmentDto studentEnrollmentDto)
        {
            return new StudentHalaqaEnrollment
            {
                Id = studentEnrollmentDto.Id,
                StudentId = studentEnrollmentDto.StudentId,
                HalaqaId = studentEnrollmentDto.HalaqaId,
                StartDate = studentEnrollmentDto.EnrollmentDate,
                EndDate = studentEnrollmentDto.EndDate,
                IsCurrent = studentEnrollmentDto.IsCurrent
            };
        }
    }
}


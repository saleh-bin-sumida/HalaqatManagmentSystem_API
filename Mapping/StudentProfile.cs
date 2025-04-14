namespace HalaqatManagmentSystem_API.Mapping
{
    public static class StudentProfile
    {
        public static Expression<Func<Student, GetStudentNameDto>> ToGetStudentNameDto()
        {
            return student => new GetStudentNameDto
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
            };
        }

        public static Expression<Func<Student, GetStudentDto>> ToGetStudentDto()
        {
            return student => new GetStudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gender = student.Gender,
                //Neighborhood = student.Neighborhood,
                //PhoneNumber = student.PhoneNumber,
                SchoolGrade = student.SchoolGrade,
                //GuardianFullName = student.Guardian.FirstName + " " + student.Guardian.LastName,
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                HalaqaName = student.Halaqa.Name,
                HalaqaId = student.HalaqaId
            };
        }

        public static Expression<Func<Student, GetStudentFullInfoDto>> ToGetStudentFullInfoDto()
        {
            return student => new GetStudentFullInfoDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                SerialNumber = student.SerialNumber,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                PhoneNumber = student.PhoneNumber,

                City = student.City,
                Neighborhood = student.Neighborhood,

                GuardianId = student.GuardianId,
                GuardianFullName = student.Guardian.FirstName + " " + student.Guardian.LastName,
                GuardianPhoneNumber = student.Guardian.PhoneNumber,

                GuardianKinship = student.GuardianKinship,
                HalaqaId = student.HalaqaId,

                HalaqaName = student.Halaqa.Name,

                LastMemorizedSurah = student.LastMemorizedSurah,
                SchoolGrade = student.SchoolGrade,

            };
        }

        public static Student ToStudent(this AddStudentDto addStudentDto)
        {
            var student = new Student
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                DateOfBirth = addStudentDto.DateOfBirth,
                Gender = addStudentDto.Gender,
                PhoneNumber = addStudentDto.PhoneNumber,

                City = addStudentDto.City,

                GuardianId = addStudentDto.GuardianId,
                GuardianKinship = addStudentDto.GuardianKinship,
                LastMemorizedSurah = addStudentDto.LastMemorizedSurah,
                SchoolGrade = addStudentDto.SchoolGrade,

            };

            return student;
        }

        public static void UpdateStudent(this Student student, UpdateStudentDto updateStudentDto)
        {
            student.FirstName = updateStudentDto.FirstName;
            student.LastName = updateStudentDto.LastName;
            student.DateOfBirth = updateStudentDto.DateOfBirth;
            student.Gender = updateStudentDto.Gender;
            student.PhoneNumber = updateStudentDto.PhoneNumber;
            student.Neighborhood = updateStudentDto.Neighborhood;
            student.City = updateStudentDto.City;
            student.GuardianId = updateStudentDto.GuardianId;
            student.GuardianKinship = updateStudentDto.GuardianKinship;
            student.LastMemorizedSurah = updateStudentDto.LastMemorizedSurah;
            student.SchoolGrade = updateStudentDto.SchoolGrade;
        }
    }
}

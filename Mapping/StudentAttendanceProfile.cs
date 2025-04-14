namespace HalaqatSchoolSystem.Core.Mapping
{
    public static class StudentAttendanceProfile
    {
        public static GetAttendanceDto ToGetAttendanceDto(this StudentAttendance studentAttendance)
        {
            return new GetAttendanceDto
            {
                AttendanceId = studentAttendance.Id,
                StudentId = studentAttendance.StudentId,
                FullName = studentAttendance.Student.FirstName + " " + studentAttendance.Student.LastName,
                HalaqaId = studentAttendance.HalaqaId,
                Status = studentAttendance.Status,
                Remarks = studentAttendance.Remarks
            };
        }


        public static StudentAttendance ToStudentAttendance(this AddUpdatedAttendanceDto addAttendanceDto)
        {
            return new StudentAttendance
            {
                StudentId = addAttendanceDto.StudentId,
                HalaqaId = addAttendanceDto.HalaqaId,
                AttendanceDate = addAttendanceDto.AttendanceDate,
                Status = addAttendanceDto.Status,
                Remarks = addAttendanceDto.Remarks
            };
        }

        public static void UpdateStudentAttendance(this StudentAttendance studentAttendance, AddUpdatedAttendanceDto addUpdateAttendanceDto)
        {
            studentAttendance.Status = addUpdateAttendanceDto.Status;
            studentAttendance.Remarks = addUpdateAttendanceDto.Remarks;
        }
    }
}


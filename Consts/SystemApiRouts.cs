namespace HalaqatManagmentSystem_API.Consts;

public static class SystemApiRouts
{
    public static class Guardians
    {
        public const string Base = "api/guardians";
        public const string GetAll = Base;
        public const string GetAllNames = Base + "/names";
        public const string GetById = Base + "/{Id}";
        public const string GetFullInfoById = Base + "/{Id:guid}/FullInfo";
        public const string Add = Base;
        public const string Update = Base + "/{Id}";
        public const string Delete = Base + "/{Id}";
        public const string DeleteRange = Base;
    }

    public static class Employees
    {
        public const string Base = "api/employees";
        public const string GetAll = Base;
        public const string GetAllNames = Base + "/names";
        public const string GetById = Base + "/{Id}";
        public const string GetFullInfoById = Base + "/{Id:guid}/FullInfo";
        public const string Add = Base;
        public const string Update = Base + "/{Id:guid}";
        public const string Delete = Base + "/{Id}";
        public const string DeleteRange = Base;
    }

    public static class Teachers
    {
        public const string Base = "api/teachers";
        public const string GetAll = Base;
        public const string GetAllNames = Base + "/names";
        public const string GetById = Base + "/{Id}";
        public const string GetFullInfoById = Base + "/{Id:guid}/FullInfo";
        public const string Add = Base;
        public const string Update = Base + "/{Id}";
        public const string Delete = Base + "/{Id}";
        public const string DeleteRange = Base;
        public const string AssignTeacherToHalaqa = Base + "/AssignTeacherToHalaqa/{TeacherId:guid}/{Halaqa_Id:int}";
        //public const string GetAllTeachersInLevel = Base + "/GetAllTeachersInLevel/{levelId}";
    }

    public static class Halaqat
    {
        public const string Base = "api/halaqat";
        public const string GetAll = Base;
        public const string GetAllNames = Base + "/names";
        public const string GetById = Base + "/{Id}";
        public const string GetAllAssignedToTeacher = Base + "/ByTeacher/{teacherId}";
        public const string AddStudentsToHalaqa = Base + "/{HalaqaId}/AddStudentsToHalaqa";
        public const string AddStudentToHalaqa = Base + "/{HalaqaId}/AddStudentToHalaqa/{StudentId}";
        public const string Add = Base;
        public const string Update = Base + "/{Id}";
        public const string Delete = Base + "/{Id}";
        public const string GetEnrollmentsInHalaqa = Base + "/GetEnrollmentsInHalaqa/{id}";
        public const string ChangeTeacherOfHalaqa = Base + "/ChangeTeacherOfHalaqa";

    }

    public static class Levels
    {
        public const string Base = "api/levels";
        public const string GetAll = Base;
        public const string GetById = Base + "/{Id}";
        public const string Add = Base;
        public const string Update = Base + "/{Id}";
        public const string Delete = Base + "/{Id}";
        public const string AssignCurriculumToLevel = Base + "/AssignCurriculumToLevel/{levelId}/{curriculumId}";
    }

    public static class Classes
    {
        public const string Base = "api/classes";
        public const string GetAll = Base;
        public const string GetById = Base + "/{Id}";
        public const string GetByLevel = Base + "/ByLevel/{levelId}";
        public const string AddStudentsToClass = Base + "/{ClassId}/AddStudentsToClass";
        public const string AddStudentToClass = Base + "/{ClassId}/AddStudentToClass/{StudentId}";
        public const string Add = Base;
        public const string Update = Base + "/{Id}";
        public const string Delete = Base + "/{Id}";
    }

    public static class Students
    {
        public const string Base = "api/students";
        public const string GetAll = Base;
        public const string GetStudentsNamesNotLinkedToHalaqa = Base + "GetStudentsNamesNotLinkedToHalaqa";
        public const string GetStudentsNamesNotLinkedToClass = Base + "GetStudentsNamesNotLinkedToClass";
        public const string GetByHalaqa = Base + "/ByHalaqa/{HalaqaId}";
        public const string GetByClass = Base + "/ByClass/{classId}";
        public const string GetByLevel = Base + "/ByLevel/{levelId}";
        public const string GetById = Base + "/{Id}";
        public const string GetFullInfoById = Base + "/{Id}/FullInfo";
        public const string GetAllEnrollments = Base + "/Enrollments/{id}";
        public const string Add = Base;
        public const string Accept = Base + "/{Id}/Accept";
        public const string DeleteStudentFromClass = Base + "/{Id}/DeleteStudentFromClass";
        public const string DeleteStudentFromHalaqa = Base + "/{Id}/DeleteStudentFromHalaqa";


        public const string Update = Base + "/{Id}";
        public const string Delete = Base + "/{Id}";
        public const string Recover = Base + "/{Id}/recover";
        public const string DeleteRange = Base;
    }

    public static class StudentAttendances
    {
        public const string Base = "api/attendances";
        public const string GetAll = Base;
        public const string GetById = Base + "/{Id}";
        public const string GetByStudent = Base + "/ByStudent/{studentId:guid}";
        public const string GetByHalaqa = Base + "/ByHalaqa";
        public const string AddOrUpdate = Base;
        public const string Delete = Base + "/Delete";
    }

    public static class StudentGrades
    {
        public const string Base = "api/StudentGrades";
        public const string GetYearlyGrades = Base + "/YearlyGrades/{YearNumber}/{ClassId}";
        public const string GetAcadimYearsNumbers = Base + "/AcadimYearsNumbers";
        public const string CreateNewAcadimcYear = Base + "/CreateNewAcadimcYear/{acadimcYear}";
        public const string GetMonthlyGrades = Base + "/MonthlyGrades/{YearNumber}/{MonthNumber}/{ClassId}";
        public const string AddOrUpdateMonthlyGrades = Base + "/MonthlyGrades";
        public const string DeleteMonthlyGrades = Base + "/MonthlyGrades/Delete";
        public const string GetSemesterGrades = Base + "/Semesters/{YearNumber}/{IsFirstSemester}/{ClassId}";
        public const string GetTestGrades = Base + "/Semesters/TestGrades/{YearNumber}/{IsFirstSemester}/{ClassId}";
        public const string AddOrUpdateTestGrade = Base + "/Semesters/TestGrade/{YearNumber}/{IsFirstSemester}/{TestType}";
    }

    public static class AcadimcYears
    {
        public const string Base = "api/acadimcyears";
        public const string GetAll = Base;
        public const string GetById = Base + "/{Id}";
        public const string Add = Base;
        public const string Update = Base;
        public const string Delete = Base + "/{Id}";
        public const string GetFullInfo = Base + "/FullInfo"; // New route
    }

    public static class Semesters
    {
        public const string Base = "api/semesters";
        public const string GetAll = Base;
        public const string GetById = Base + "/{Id}";
        public const string Add = Base;
        public const string Update = Base;
        public const string Delete = Base + "/{Id}";

    }
    public static class Months
    {
        public const string Base = "api/months";
        public const string GetAll = Base;
        public const string GetById = Base + "/{Id}";
        public const string Add = Base;
        public const string Update = Base;
        public const string Delete = Base + "/{Id}";

    }
}



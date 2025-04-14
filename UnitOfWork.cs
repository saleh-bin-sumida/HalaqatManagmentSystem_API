using HalaqatManagmentSystem_API.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace HalaqatManagmentSystem_API;

public class UnitOfWork
{
    private readonly AppDbContext _context;
    //private readonly UserManager<AppUser> userManager;
    //private readonly RoleManager<AppRole> roleManager;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        //this.userManager = userManager;
        //this.roleManager = roleManager;
        InitializeRepositories();
    }

    private void InitializeRepositories()
    {
        Students = new StudentRepository(_context);
        //Employees = new EmployeeRepository(_context, userManager, roleManager);
        Guardians = new GuardianRepository(_context);
        Teachers = new TeacherRepository(_context);
        //Classes = new ClassRepository(_context);
        //Levels = new LevelRepository(_context);
        Halaqat = new HalaqaRepository(_context);
        StudentAttendances = new StudentAttendanceRepository(_context);
        //AcadimcYears = new AcadimcYearRepository(_context);
        // StudentsEnrollments = new StudentEnrollmentRepository(_context);
        // Curricula = new CurriculumRepository(_context);
        //TeachingAssignments = new TeachingAssignmentRepository(_context);
        // HalaqatSchedules = new HalaqaScheduleRepository(_context);
        // StudyPlans = new StudyPlanRepository(_context);
        // MonthPlans = new MonthPlanRepository(_context);
        //MonthlyGrades = new MonthlyGradeRepository(_context);
        //Semesters = new SemesterRepository(_context);
        //YearlyGrades = new YearlyGradeRepository(_context);
        //ApplicationUsers = new AppUserRepository(_context);
        //ApplicationRoles = new AppRoleRepository(_context);
        //UserRoles = new UserRoleRepository(_context);
    }

    public StudentRepository Students { get; private set; }
    //public EmployeeRepository Employees { get; private set; }
    public GuardianRepository Guardians { get; private set; }
    public TeacherRepository Teachers { get; private set; }
    //public ClassRepository Classes { get; private set; }
    //public LevelRepository Levels { get; private set; }
    public HalaqaRepository Halaqat { get; private set; }
    public StudentAttendanceRepository StudentAttendances { get; private set; }
    //public AcadimcYearRepository AcadimcYears { get; private set; }


    // public IStudentEnrollmentRepository StudentsEnrollments { get; private set; }
    // public IBaseRepository<Curriculum> Curricula { get; private set; }
    //public ITeachingAssignmentRepository TeachingAssignments { get; private set; }
    // public IBaseRepository<HalaqaSchedule> HalaqatSchedules { get; private set; }
    // public IBaseRepository<StudyPlan> StudyPlans { get; private set; }
    // public IBaseRepository<MonthPlan> MonthPlans { get; private set; }
    //public IMonthlyGradeRepository MonthlyGrades { get; private set; }
    //public ISemesterRepository Semesters { get; private set; }
    //public IYearlyGradeRepository YearlyGrades { get; private set; }
    //public IAppUserRepository ApplicationUsers { get; private set; }
    //public IAppRoleRepository ApplicationRoles { get; private set; }
    //public IUserRoleRepository UserRoles { get; private set; }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}


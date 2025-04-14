using Microsoft.EntityFrameworkCore.Metadata;

namespace HalaqatManagmentSystem_API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected AppDbContext()
    {
    }

    #region DbSets
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Halaqa> Halaqat { get; set; }
    public DbSet<StudentHalaqaEnrollment> StudentsEnrollments { get; set; }
    public DbSet<TeachingAssignment> TeachingAssignments { get; set; }
    public DbSet<StudentAttendance> StudentAttendances { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Teacher Entity
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable(TablesNames.Teacher);
            entity.AddEnumCheckConstraint<Surah>(TablesNames.Teacher, nameof(Teacher.LastMemorizedSurah));
        });
        #endregion

        #region Student Entity
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable(TablesNames.Student);

            entity.HasOne(x => x.Guardian)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GuardianId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(x => x.Halaqa)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.HalaqaId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(x => x.SerialNumber)
                .IsUnicode(true)
                .UseIdentityColumn(1000, 1)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


            entity.AddEnumCheckConstraint<SchoolGrade>(TablesNames.Student, nameof(Student.SchoolGrade));
            entity.AddEnumCheckConstraint<GuardianKinship>(TablesNames.Student, nameof(Student.GuardianKinship));
            entity.AddEnumCheckConstraint<Surah>(TablesNames.Student, nameof(Student.LastMemorizedSurah));
        });
        #endregion

        #region Halaqat Entity
        modelBuilder.Entity<Halaqa>(entity =>
        {
            entity.ToTable(TablesNames.Halaqa);
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Teacher)
                .WithMany(x => x.Halaqat)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

        });
        #endregion

        #region StudentEnrollmentHistory Entity
        modelBuilder.Entity<StudentHalaqaEnrollment>(entity =>
        {
            entity.ToTable(TablesNames.studentEnrollment);
            entity.Property(x => x.StartDate).HasDefaultValueSql("GETDATE()");
            entity.HasOne(x => x.Student)
                .WithMany(x => x.EnrollmentsHistories)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Halaqa)
                .WithMany(x => x.EnrollmentsHistories)
                .HasForeignKey(x => x.HalaqaId)
                .OnDelete(DeleteBehavior.Cascade);


        });
        #endregion

        #region StudentAttendance Entity
        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.ToTable(TablesNames.StudentAttendance);
            entity.HasOne(x => x.Student)
                .WithMany(x => x.StudentAttendances)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Halaqa)
                .WithMany(x => x.StudentAttendances)
                .HasForeignKey(x => x.HalaqaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(x => new { x.StudentId, x.AttendanceDate }).IsUnique();

            entity.AddEnumCheckConstraint<AttendanceStatus>(TablesNames.StudentAttendance, nameof(StudentAttendance.Status));



        });
        #endregion

        #region Guardian Entity
        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.ToTable(TablesNames.Guardian);

            entity.AddEnumCheckConstraint<MaritalStatus>(TablesNames.Guardian, nameof(Guardian.MaritalStatus));
        });
        #endregion

        #region TeachingAssignment Entity
        modelBuilder.Entity<TeachingAssignment>(entity =>
        {
            entity.ToTable(TablesNames.TeachingAssignment);
            entity.HasKey(x => x.Id);
            entity.Property(x => x.StartDate).HasDefaultValueSql("GETDATE()");
            entity.HasOne(x => x.Teacher)
                .WithMany(t => t.TeachingAssignments)
                .HasForeignKey(ta => ta.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Halaqa)
                .WithMany(h => h.TeachingAssignments)
                .HasForeignKey(ta => ta.HalaqaId)
                .OnDelete(DeleteBehavior.Cascade);

        });
        #endregion

    }
}

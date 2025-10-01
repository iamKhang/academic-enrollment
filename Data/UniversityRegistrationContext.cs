using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Text;
using UniversityRegistration.Models;

namespace UniversityRegistration.Data;

public class UniversityRegistrationContext : DbContext
{
    public UniversityRegistrationContext(DbContextOptions<UniversityRegistrationContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<ProgramCohort> ProgramCohorts => Set<ProgramCohort>();

    public DbSet<Curriculum> Curriculums => Set<Curriculum>();

    public DbSet<SubjectCurriculum> SubjectCurriculums => Set<SubjectCurriculum>();

    public DbSet<ElectiveGroup> ElectiveGroups => Set<ElectiveGroup>();

    public DbSet<Class> Classes => Set<Class>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Lecturer> Lecturers => Set<Lecturer>();

    public DbSet<Subject> Subjects => Set<Subject>();

    public DbSet<SubjectLecturer> SubjectLecturers => Set<SubjectLecturer>();

    public DbSet<Semester> Semesters => Set<Semester>();

    public DbSet<CourseClass> CourseClasses => Set<CourseClass>();

    public DbSet<PracticeGroup> PracticeGroups => Set<PracticeGroup>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Schedule> Schedules => Set<Schedule>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public DbSet<SubjectCurriculumElectiveGroup> SubjectCurriculumElectiveGroups => Set<SubjectCurriculumElectiveGroup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SubjectLecturer>()
            .HasKey(sl => new { sl.SubjectId, sl.LecturerId });

        modelBuilder.Entity<Department>()
            .HasMany(d => d.ProgramCohorts)
            .WithOne(pc => pc.Department)
            .HasForeignKey(pc => pc.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Lecturers)
            .WithOne(l => l.Department)
            .HasForeignKey(l => l.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Subjects)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProgramCohort>()
            .HasMany(pc => pc.Classes)
            .WithOne(c => c.ProgramCohort)
            .HasForeignKey(c => c.ProgramCohortId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProgramCohort>()
            .HasOne(pc => pc.Curriculum)
            .WithMany()
            .HasForeignKey(pc => pc.CurriculumId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Curriculum>()
            .HasMany(c => c.SubjectCurriculums)
            .WithOne(sc => sc.Curriculum)
            .HasForeignKey(sc => sc.CurriculumId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Curriculum>()
            .HasMany(c => c.ElectiveGroups)
            .WithOne(eg => eg.Curriculum)
            .HasForeignKey(eg => eg.CurriculumId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubjectCurriculum>()
            .HasOne(sc => sc.Subject)
            .WithMany()
            .HasForeignKey(sc => sc.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        // Gỡ mapping 1-n cũ (đã bỏ ElectiveGroupId trong SubjectCurriculum)

        // 1) ElectiveGroup: unique trong 1 curriculum & 1 học kỳ
        modelBuilder.Entity<ElectiveGroup>()
            .HasIndex(x => new { x.CurriculumId, x.Semester, x.Name })
            .IsUnique();

        modelBuilder.Entity<ElectiveGroup>()
            .HasOne(x => x.Curriculum)
            .WithMany(c => c.ElectiveGroups)
            .HasForeignKey(x => x.CurriculumId)
            .OnDelete(DeleteBehavior.Cascade);

        // 3) Mapping m-n qua bảng nối
        modelBuilder.Entity<SubjectCurriculumElectiveGroup>()
            .ToTable("subject_curriculum_elective_groups")
            .HasKey(x => new { x.SubjectCurriculumId, x.ElectiveGroupId });

        modelBuilder.Entity<SubjectCurriculumElectiveGroup>()
            .HasOne(x => x.SubjectCurriculum)
            .WithMany(sc => sc.ElectiveGroups)
            .HasForeignKey(x => x.SubjectCurriculumId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SubjectCurriculumElectiveGroup>()
            .HasOne(x => x.ElectiveGroup)
            .WithMany(eg => eg.SubjectCurricula)
            .HasForeignKey(x => x.ElectiveGroupId)
            .OnDelete(DeleteBehavior.NoAction);

        // 4) (Optional) Ràng buộc cùng học kỳ & cùng curriculum ở mức DB
        modelBuilder.Entity<SubjectCurriculumElectiveGroup>()
            .ToTable(tb => tb.HasCheckConstraint(
                "ck_sc_eg_same_ids",
                // check mềm: chỉ kiểm non-empty; phần "cùng semester/curriculum" validate trong code
                "subject_curriculum_id <> '' AND elective_group_id <> ''"
            ));

        // 5) Quy đổi nhóm ở Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.AttributedElectiveGroup)
            .WithMany()
            .HasForeignKey(e => e.AttributedElectiveGroupId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure prerequisite/corequisite relationships
        modelBuilder.Entity<SubjectCurriculum>()
            .HasMany(sc => sc.Prerequisites)
            .WithMany()
            .UsingEntity(j => j.ToTable("prerequisites"));

        modelBuilder.Entity<SubjectCurriculum>()
            .HasMany(sc => sc.Corequisites)
            .WithMany()
            .UsingEntity(j => j.ToTable("corequisites"));

        modelBuilder.Entity<SubjectCurriculum>()
            .HasMany(sc => sc.ConcurrentCourses)
            .WithMany()
            .UsingEntity(j => j.ToTable("concurrent_courses"));


        modelBuilder.Entity<Class>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Class)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Subject>()
            .HasMany(s => s.CourseClasses)
            .WithOne(cc => cc.Subject)
            .HasForeignKey(cc => cc.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Semester>()
            .HasMany(s => s.CourseClasses)
            .WithOne(cc => cc.Semester)
            .HasForeignKey(cc => cc.SemesterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lecturer>()
            .HasMany(l => l.CourseClasses)
            .WithOne(cc => cc.Lecturer)
            .HasForeignKey(cc => cc.LecturerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Lecturer>()
            .HasMany(l => l.PracticeGroups)
            .WithOne(pg => pg.Lecturer)
            .HasForeignKey(pg => pg.LecturerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubjectLecturer>()
            .HasOne(sl => sl.Subject)
            .WithMany(s => s.SubjectLecturers)
            .HasForeignKey(sl => sl.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubjectLecturer>()
            .HasOne(sl => sl.Lecturer)
            .WithMany(l => l.SubjectLecturers)
            .HasForeignKey(sl => sl.LecturerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseClass>()
            .HasMany(cc => cc.PracticeGroups)
            .WithOne(pg => pg.CourseClass)
            .HasForeignKey(pg => pg.CourseClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseClass>()
            .HasMany(cc => cc.Schedules)
            .WithOne(s => s.CourseClass)
            .HasForeignKey(s => s.CourseClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseClass>()
            .HasMany(cc => cc.Enrollments)
            .WithOne(e => e.CourseClass)
            .HasForeignKey(e => e.CourseClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PracticeGroup>()
            .HasMany(pg => pg.Schedules)
            .WithOne(s => s.PracticeGroup)
            .HasForeignKey(s => s.PracticeGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PracticeGroup>()
            .HasMany(pg => pg.Enrollments)
            .WithOne(e => e.PracticeGroup)
            .HasForeignKey(e => e.PracticeGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Schedules)
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Room>()
            .Property(r => r.RoomType)
            .HasConversion<string>()
            .HasMaxLength(20);

        modelBuilder.Entity<Schedule>()
            .Property(s => s.DayOfWeek)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Explicit table names using simple s/es pluralization
        modelBuilder.Entity<Curriculum>().ToTable("curriculums");
        modelBuilder.Entity<SubjectCurriculum>().ToTable("subject_curriculums");

        ApplySnakeCaseNaming(modelBuilder);
    }

    private static void ApplySnakeCaseNaming(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                entity.SetTableName(NormalizeTableName(tableName));
            }

            foreach (var property in entity.GetProperties())
            {
                var columnName = property.Name;
                property.SetColumnName(ToSnakeCase(columnName));
            }

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrWhiteSpace(keyName))
                {
                    key.SetName(ToSnakeCase(keyName));
                }
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (!string.IsNullOrWhiteSpace(indexName))
                {
                    index.SetDatabaseName(ToSnakeCase(indexName));
                }
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var constraintName = foreignKey.GetConstraintName();
                if (!string.IsNullOrWhiteSpace(constraintName))
                {
                    foreignKey.SetConstraintName(ToSnakeCase(constraintName));
                }
            }
        }
    }

    private static string NormalizeTableName(string tableName)
    {
        return ToSnakeCase(tableName);
    }

    private static string ToSnakeCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var builder = new StringBuilder(value.Length + 10);

        for (int i = 0; i < value.Length; i++)
        {
            var current = value[i];

            if (current == '.')
            {
                builder.Append('_');
                continue;
            }

            if (char.IsUpper(current))
            {
                var hasPrior = i > 0;
                var priorIsLower = hasPrior && char.IsLetterOrDigit(value[i - 1]) && !char.IsUpper(value[i - 1]);
                var nextIsLower = i + 1 < value.Length && char.IsLetterOrDigit(value[i + 1]) && !char.IsUpper(value[i + 1]);

                if (hasPrior && (priorIsLower || nextIsLower))
                {
                    builder.Append('_');
                }

                builder.Append(char.ToLowerInvariant(current));
            }
            else
            {
                builder.Append(char.ToLowerInvariant(current));
            }
        }

        return builder.ToString();
    }
}

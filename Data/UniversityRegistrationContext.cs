using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Text;
using UniversityRegistration.Models;

namespace UniversityRegistration.Data;

public class UniversityRegistrationContext : IdentityDbContext
{
    public UniversityRegistrationContext(DbContextOptions<UniversityRegistrationContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<ProgramCohort> ProgramCohorts => Set<ProgramCohort>();

    public DbSet<Curriculum> Curriculums => Set<Curriculum>();

    public DbSet<CurriculumTerm> CurriculumTerms => Set<CurriculumTerm>();
    public DbSet<CurriculumTermSubject> CurriculumTermSubjects => Set<CurriculumTermSubject>();
    public DbSet<CurriculumElectiveGroup> CurriculumElectiveGroups => Set<CurriculumElectiveGroup>();
    public DbSet<CurriculumElectiveGroupSubject> CurriculumElectiveGroupSubjects => Set<CurriculumElectiveGroupSubject>();


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

    public DbSet<Admin> Admins => Set<Admin>();

    public DbSet<Campus> Campuses => Set<Campus>();

    public DbSet<Building> Buildings => Set<Building>();

    public DbSet<Floor> Floors => Set<Floor>();

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

        // Hierarchy: Campus -> Building -> Floor -> Room
        modelBuilder.Entity<Campus>()
            .HasMany(c => c.Buildings)
            .WithOne(b => b.Campus)
            .HasForeignKey(b => b.CampusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Building>()
            .HasMany(b => b.Floors)
            .WithOne(f => f.Building)
            .HasForeignKey(f => f.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Floor>()
            .HasMany(f => f.Rooms)
            .WithOne(r => r.FloorRef)
            .HasForeignKey(r => r.FloorId)
            .OnDelete(DeleteBehavior.SetNull);

        // (removed duplicate Building->Floors mapping)

        // Optional direct FKs on Room
        modelBuilder.Entity<Room>()
            .HasOne(r => r.CampusRef)
            .WithMany()
            .HasForeignKey(r => r.CampusId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Room>()
            .HasOne(r => r.BuildingRef)
            .WithMany()
            .HasForeignKey(r => r.BuildingId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Room>()
            .Property(r => r.RoomType)
            .HasConversion<string>()
            .HasMaxLength(20);

        modelBuilder.Entity<Schedule>()
            .Property(s => s.DayOfWeek)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Curriculum -> Terms
        modelBuilder.Entity<Curriculum>()
            .HasMany(c => c.Terms)
            .WithOne(t => t.Curriculum)
            .HasForeignKey(t => t.CurriculumId)
            .OnDelete(DeleteBehavior.Cascade);

        // CurriculumTerm -> RequiredSubjects
        modelBuilder.Entity<CurriculumTerm>()
            .HasMany(t => t.RequiredSubjects)
            .WithOne(rs => rs.CurriculumTerm)
            .HasForeignKey(rs => rs.CurriculumTermId)
            .OnDelete(DeleteBehavior.Cascade);

        // CurriculumTerm -> ElectiveGroups
        modelBuilder.Entity<CurriculumTerm>()
            .HasMany(t => t.ElectiveGroups)
            .WithOne(eg => eg.CurriculumTerm)
            .HasForeignKey(eg => eg.CurriculumTermId)
            .OnDelete(DeleteBehavior.Cascade);

        // CurriculumTermSubject -> Subject
        modelBuilder.Entity<CurriculumTermSubject>()
            .HasOne(ts => ts.Subject)
            .WithMany()
            .HasForeignKey(ts => ts.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        // CurriculumElectiveGroup -> Subjects
        modelBuilder.Entity<CurriculumElectiveGroup>()
            .HasMany(eg => eg.Subjects)
            .WithOne(s => s.ElectiveGroup)
            .HasForeignKey(s => s.ElectiveGroupId)
            .OnDelete(DeleteBehavior.Cascade);

        // CurriculumElectiveGroupSubject composite key
        modelBuilder.Entity<CurriculumElectiveGroupSubject>()
            .HasKey(egs => new { egs.ElectiveGroupId, egs.SubjectId });

        modelBuilder.Entity<CurriculumElectiveGroupSubject>()
            .HasOne(egs => egs.Subject)
            .WithMany()
            .HasForeignKey(egs => egs.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);


        // Explicit table names using simple s/es pluralization
        modelBuilder.Entity<Curriculum>().ToTable("curriculums");

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

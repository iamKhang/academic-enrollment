using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistration.Data;
using UniversityRegistration.Models;
using UniversityRegistration.Models.Enums;


public static class SeedData
{
    public static async Task SeedAsync(UniversityRegistrationContext context, UserManager<IdentityUser> userManager)
    {
        await context.Database.EnsureCreatedAsync();

        // ===== Create Admin User =====
        await CreateAdminUserAsync(userManager);

        // Helper shortcuts for Set<T>()
        var Departments        = context.Set<Department>();
        var Curriculums        = context.Set<Curriculum>();
        var ProgramCohorts     = context.Set<ProgramCohort>();
        var Classes            = context.Set<Class>();
        var Lecturers          = context.Set<Lecturer>();
        var Students           = context.Set<Student>();
        var Subjects           = context.Set<Subject>();
        var SubjectLecturers   = context.Set<SubjectLecturer>();
        var ElectiveGroups     = context.Set<ElectiveGroup>();
        var SubjectCurriculums = context.Set<SubjectCurriculum>();
        var Semesters          = context.Set<Semester>();
        var Rooms              = context.Set<Room>();
        var CourseClasses      = context.Set<CourseClass>();
        var PracticeGroups     = context.Set<PracticeGroup>();
        var Schedules          = context.Set<Schedule>();
        var Enrollments        = context.Set<Enrollment>();

        // ===== Department: CNTT =====
        if (!Departments.Any())
        {
            Departments.Add(new Department { Id = "CNTT", Name = "Công nghệ Thông tin" });
            await context.SaveChangesAsync();
        }

        // ===== Curriculum & Cohort (Khóa 17) =====
        if (!Curriculums.Any(c => c.Id == "CNTT17"))
        {
            Curriculums.Add(new Curriculum
            {
                Id = "CNTT17",
                Name = "Chương trình khung CNTT - Khóa 17"
            });
            await context.SaveChangesAsync();
        }

        if (!ProgramCohorts.Any(pc => pc.Id == "K17"))
        {
            ProgramCohorts.Add(new ProgramCohort
            {
                Id = "K17",
                Name = "Khóa 17 CNTT",
                DepartmentId = "CNTT",
                CurriculumId = "CNTT17",
                StartDate = new DateTime(2021, 9, 1),
                EndDate   = new DateTime(2025,12,31)
            });
            await context.SaveChangesAsync();
        }

        // ===== Class (lớp danh nghĩa) =====
        if (!Classes.Any())
        {
            Classes.AddRange(new[]
            {
                new Class { Id = "CNTT17A", Name = "CNTT17A", ProgramCohortId = "K17" },
                new Class { Id = "CNTT17B", Name = "CNTT17B", ProgramCohortId = "K17" }
            });
            await context.SaveChangesAsync();
        }

        // ===== Lecturers =====
        if (!Lecturers.Any())
        {
            Lecturers.AddRange(new[]
            {
                new Lecturer { Id = "GV001", LecturerCode = "GV001", FullName = "PGS.TS Nguyễn Văn An", DepartmentId = "CNTT" },
                new Lecturer { Id = "GV002", LecturerCode = "GV002", FullName = "TS Trần Thu Uyên",     DepartmentId = "CNTT" },
                new Lecturer { Id = "GV003", LecturerCode = "GV003", FullName = "ThS Lê Minh Đức",      DepartmentId = "CNTT" },
                new Lecturer { Id = "GV004", LecturerCode = "GV004", FullName = "ThS Phạm Thị Hoa",     DepartmentId = "CNTT" }
            });
            await context.SaveChangesAsync();
        }

        // ===== Students (mẫu) =====
        if (!Students.Any())
        {
            Students.AddRange(new[]
            {
                new Student { Id = "SV170001", StudentCode = "SV170001", FullName = "Nguyễn Văn A", ClassId = "CNTT17A" },
                new Student { Id = "SV170002", StudentCode = "SV170002", FullName = "Trần Thị B",   ClassId = "CNTT17A" },
                new Student { Id = "SV170003", StudentCode = "SV170003", FullName = "Lê Văn C",     ClassId = "CNTT17B" },
                new Student { Id = "SV170004", StudentCode = "SV170004", FullName = "Phạm Thị D",   ClassId = "CNTT17B" }
            });
            await context.SaveChangesAsync();
        }

        // ===== Subjects (đa dạng) =====
        if (!Subjects.Any())
        {
            Subjects.AddRange(new[]
            {
                new Subject { Id = "CTRR",  Name = "Nhập môn Lập trình",       TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "KTLT",  Name = "Kỹ thuật Lập trình",        TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "CTDL",  Name = "Cấu trúc dữ liệu & GT",    TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "OOP",   Name = "Lập trình Hướng đối tượng",TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "CSDL",  Name = "Cơ sở dữ liệu",             TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "HQT",   Name = "Hệ quản trị CSDL",          TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "HDH",   Name = "Hệ điều hành",              TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "MMT",   Name = "Mạng máy tính",             TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "WEBJ",  Name = "Lập trình Web với Java",    TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "WEBNET",Name = "Lập trình Web với .NET",    TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "WEBJS", Name = "Lập trình Web với NodeJS",  TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "MOB",  Name = "Lập trình Di động (Android)",TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "AI",    Name = "Nhập môn Trí tuệ nhân tạo", TheoryCredits = 3, PracticeCredits = 0, DepartmentId = "CNTT" },
                new Subject { Id = "SE",    Name = "Công nghệ phần mềm",        TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "DA1",   Name = "Đồ án 1",                   TheoryCredits = 0, PracticeCredits = 2, DepartmentId = "CNTT" },
                new Subject { Id = "DA2",   Name = "Đồ án 2",                   TheoryCredits = 0, PracticeCredits = 2, DepartmentId = "CNTT" },
                new Subject { Id = "TT",    Name = "Thực tập tốt nghiệp",       TheoryCredits = 0, PracticeCredits = 4, DepartmentId = "CNTT" },
                new Subject { Id = "UXUI",  Name = "Thiết kế UX/UI",            TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "ANM",   Name = "An ninh mạng cơ bản",       TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "CLOUD", Name = "Điện toán đám mây",         TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "DSSS",  Name = "Xử lý dữ liệu & SQL nâng cao", TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "KNS",   Name = "Kỹ năng mềm",               TheoryCredits = 2, PracticeCredits = 0, DepartmentId = "CNTT" },
                new Subject { Id = "ENG1",  Name = "Tiếng Anh học thuật 1",     TheoryCredits = 2, PracticeCredits = 0, DepartmentId = "CNTT" },
                new Subject { Id = "ENG2",  Name = "Tiếng Anh học thuật 2",     TheoryCredits = 2, PracticeCredits = 0, DepartmentId = "CNTT" },
                new Subject { Id = "XSTK",  Name = "Xác suất - Thống kê",       TheoryCredits = 3, PracticeCredits = 0, DepartmentId = "CNTT" },
                new Subject { Id = "DTTT",  Name = "Điện tử - Tín hiệu số cơ sở", TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "KTMT",  Name = "Kiến trúc máy tính",        TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" },
                new Subject { Id = "CSDLPT",Name = "CSDL phân tán",             TheoryCredits = 2, PracticeCredits = 1, DepartmentId = "CNTT" }
            });
            await context.SaveChangesAsync();
        }

        // ===== SubjectLecturer (năng lực giảng dạy) =====
        if (!SubjectLecturers.Any())
        {
            SubjectLecturers.AddRange(new[]
            {
                new SubjectLecturer { SubjectId = "CTRR",  LecturerId = "GV001" },
                new SubjectLecturer { SubjectId = "KTLT",  LecturerId = "GV001" },
                new SubjectLecturer { SubjectId = "CTDL",  LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "OOP",   LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "CSDL",  LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "HQT",   LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "HDH",   LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "MMT",   LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "WEBJ",  LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "WEBNET",LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "WEBJS", LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "MOB",   LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "AI",    LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "SE",    LecturerId = "GV001" },
                new SubjectLecturer { SubjectId = "DA1",   LecturerId = "GV001" },
                new SubjectLecturer { SubjectId = "DA2",   LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "TT",    LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "UXUI",  LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "ANM",   LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "CLOUD", LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "DSSS",  LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "KNS",   LecturerId = "GV001" },
                new SubjectLecturer { SubjectId = "ENG1",  LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "ENG2",  LecturerId = "GV004" },
                new SubjectLecturer { SubjectId = "XSTK",  LecturerId = "GV002" },
                new SubjectLecturer { SubjectId = "DTTT",  LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "KTMT",  LecturerId = "GV003" },
                new SubjectLecturer { SubjectId = "CSDLPT",LecturerId = "GV002" }
            });
            await context.SaveChangesAsync();
        }

        // ===== Elective Groups (theo Curriculum + Semester) =====
        if (!ElectiveGroups.Any())
        {
            ElectiveGroups.AddRange(new[]
            {
                new ElectiveGroup { Id = "EG_WEB6",   CurriculumId = "CNTT17", Semester = 6, Name = "Nhóm Công nghệ Web HK6",      RequiredCredits = 7 },
                new ElectiveGroup { Id = "EG_SKILL6", CurriculumId = "CNTT17", Semester = 6, Name = "Nhóm Kỹ năng HK6",            RequiredCredits = 3 },
                new ElectiveGroup { Id = "EG_DATA7",  CurriculumId = "CNTT17", Semester = 7, Name = "Nhóm Dữ liệu & AI HK7",       RequiredCredits = 6 },
                new ElectiveGroup { Id = "EG_DATA8",  CurriculumId = "CNTT17", Semester = 8, Name = "Nhóm Dữ liệu & AI HK8",       RequiredCredits = 4 }
            });
            await context.SaveChangesAsync();
        }

        // ===== Semesters (9 học kỳ từ 09/2021 đến 12/2025) =====
        if (!Semesters.Any())
        {
            var sems = new[]
            {
                new Semester { Id = "S1", Name = "Học kỳ 1 (2021-2022)", StartDate = new DateTime(2021,9,1),  EndDate = new DateTime(2021,12,31) },
                new Semester { Id = "S2", Name = "Học kỳ 2 (2021-2022)", StartDate = new DateTime(2022,1,1),  EndDate = new DateTime(2022,4,30)  },
                new Semester { Id = "S3", Name = "Học kỳ 3 (2021-2022)", StartDate = new DateTime(2022,5,1),  EndDate = new DateTime(2022,8,31)  },
                new Semester { Id = "S4", Name = "Học kỳ 1 (2022-2023)", StartDate = new DateTime(2022,9,1),  EndDate = new DateTime(2022,12,31) },
                new Semester { Id = "S5", Name = "Học kỳ 2 (2022-2023)", StartDate = new DateTime(2023,1,1),  EndDate = new DateTime(2023,4,30)  },
                new Semester { Id = "S6", Name = "Học kỳ 3 (2022-2023)", StartDate = new DateTime(2023,5,1),  EndDate = new DateTime(2023,8,31)  },
                new Semester { Id = "S7", Name = "Học kỳ 1 (2024-2025)", StartDate = new DateTime(2024,9,1),  EndDate = new DateTime(2024,12,31) },
                new Semester { Id = "S8", Name = "Học kỳ 2 (2024-2025)", StartDate = new DateTime(2025,1,1),  EndDate = new DateTime(2025,4,30)  },
                new Semester { Id = "S9", Name = "Học kỳ 3 (2024-2025)", StartDate = new DateTime(2025,9,1),  EndDate = new DateTime(2025,12,31) }
            };
            Semesters.AddRange(sems);
            await context.SaveChangesAsync();
        }

        // ===== Rooms =====
        if (!Rooms.Any())
        {
            Rooms.AddRange(new[]
            {
                new Room { Id = "A101", Name = "A101", Capacity = 60, RoomType = RoomType.Theory,      Location = "Tầng 1, Tòa A" },
                new Room { Id = "A102", Name = "A102", Capacity = 40, RoomType = RoomType.ComputerLab, Location = "Tầng 1, Tòa A" },
                new Room { Id = "B201", Name = "B201", Capacity = 50, RoomType = RoomType.Theory,      Location = "Tầng 2, Tòa B" },
                new Room { Id = "B202", Name = "B202", Capacity = 35, RoomType = RoomType.ComputerLab, Location = "Tầng 2, Tòa B" }
            });
            await context.SaveChangesAsync();
        }

        // ===== SubjectCurriculum (map môn vào CTK + kỳ + loại + nhóm) =====
        if (!SubjectCurriculums.Any())
        {
            var list = new List<SubjectCurriculum>
            {
                // Năm 1
                new SubjectCurriculum { Id="SC_CTRR",  CurriculumId="CNTT17", SubjectId="CTRR",  Semester=1, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_ENG1",  CurriculumId="CNTT17", SubjectId="ENG1",  Semester=1, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_KTLT",  CurriculumId="CNTT17", SubjectId="KTLT",  Semester=2, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_OOP",   CurriculumId="CNTT17", SubjectId="OOP",   Semester=2, CourseType=CourseType.Required },

                // Năm 2
                new SubjectCurriculum { Id="SC_CTDS",  CurriculumId="CNTT17", SubjectId="CTDL",  Semester=3, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_CSDL",  CurriculumId="CNTT17", SubjectId="CSDL",  Semester=3, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_HQT",   CurriculumId="CNTT17", SubjectId="HQT",   Semester=4, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_HDH",   CurriculumId="CNTT17", SubjectId="HDH",   Semester=4, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_ENG2",  CurriculumId="CNTT17", SubjectId="ENG2",  Semester=4, CourseType=CourseType.Required },

                // Năm 3
                new SubjectCurriculum { Id="SC_MMT",   CurriculumId="CNTT17", SubjectId="MMT",   Semester=5, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_SE",    CurriculumId="CNTT17", SubjectId="SE",    Semester=5, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_WEBJ",  CurriculumId="CNTT17", SubjectId="WEBJ",  Semester=6, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_WEBNET",CurriculumId="CNTT17", SubjectId="WEBNET",Semester=6, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_WEBJS", CurriculumId="CNTT17", SubjectId="WEBJS", Semester=6, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_UXUI",  CurriculumId="CNTT17", SubjectId="UXUI",  Semester=6, CourseType=CourseType.Elective },

                // Năm 4
                new SubjectCurriculum { Id="SC_AI",    CurriculumId="CNTT17", SubjectId="AI",    Semester=7, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_DSSS",  CurriculumId="CNTT17", SubjectId="DSSS",  Semester=7, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_ANM",   CurriculumId="CNTT17", SubjectId="ANM",   Semester=7, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_CLOUD", CurriculumId="CNTT17", SubjectId="CLOUD", Semester=8, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_MOB",   CurriculumId="CNTT17", SubjectId="MOB",   Semester=8, CourseType=CourseType.Elective },

                // Project/Intern
                new SubjectCurriculum { Id="SC_DA1",   CurriculumId="CNTT17", SubjectId="DA1",   Semester=8, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_DA2",   CurriculumId="CNTT17", SubjectId="DA2",   Semester=9, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_TT",    CurriculumId="CNTT17", SubjectId="TT",    Semester=9, CourseType=CourseType.Required },

                // Toán & nền tảng khác
                new SubjectCurriculum { Id="SC_XSTK",  CurriculumId="CNTT17", SubjectId="XSTK",  Semester=5, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_DTTT",  CurriculumId="CNTT17", SubjectId="DTTT",  Semester=3, CourseType=CourseType.Elective },
                new SubjectCurriculum { Id="SC_KTMT",  CurriculumId="CNTT17", SubjectId="KTMT",  Semester=4, CourseType=CourseType.Required },
                new SubjectCurriculum { Id="SC_CSDLPT",CurriculumId="CNTT17", SubjectId="CSDLPT",Semester=7, CourseType=CourseType.Elective },

                // Kỹ năng mềm (đảm bảo nhóm kỹ năng có đủ lựa chọn)
                new SubjectCurriculum { Id="SC_KNS",   CurriculumId="CNTT17", SubjectId="KNS",   Semester=5, CourseType=CourseType.Elective }
            };
            SubjectCurriculums.AddRange(list);
            await context.SaveChangesAsync();

            // Thiết lập tiên quyết / học trước / song hành
            var map = SubjectCurriculums.ToDictionary(x => x.Id);

            // Prereq: OOP -> cần KTLT; CTDL -> cần OOP; CSDL -> cần CTDL; HQT -> cần CSDL; WEB* -> cần OOP + CSDL; DA2 -> cần DA1
            map["SC_OOP"].Prerequisites.Add(map["SC_KTLT"]);
            map["SC_CTDS"].Prerequisites.Add(map["SC_OOP"]);
            map["SC_CSDL"].Prerequisites.Add(map["SC_CTDS"]);
            map["SC_HQT"].Prerequisites.Add(map["SC_CSDL"]);
            map["SC_WEBJ"].Prerequisites.Add(map["SC_OOP"]);    map["SC_WEBJ"].Prerequisites.Add(map["SC_CSDL"]);
            map["SC_WEBNET"].Prerequisites.Add(map["SC_OOP"]);  map["SC_WEBNET"].Prerequisites.Add(map["SC_CSDL"]);
            map["SC_WEBJS"].Prerequisites.Add(map["SC_OOP"]);   map["SC_WEBJS"].Prerequisites.Add(map["SC_CSDL"]);
            map["SC_DA2"].Prerequisites.Add(map["SC_DA1"]);

            // Coreq (must take before – không pass): HDH yêu cầu "đã học" KTLT; MMT yêu cầu "đã học" HDH
            map["SC_HDH"].Corequisites.Add(map["SC_KTLT"]);
            map["SC_MMT"].Corequisites.Add(map["SC_HDH"]);

            // Concurrent (cùng kỳ được): SE có thể học song hành với WEB*; DA1 có thể học song hành với CLOUD
            map["SC_SE"].ConcurrentCourses.Add(map["SC_WEBJ"]);
            map["SC_SE"].ConcurrentCourses.Add(map["SC_WEBNET"]);
            map["SC_SE"].ConcurrentCourses.Add(map["SC_WEBJS"]);
            map["SC_DA1"].ConcurrentCourses.Add(map["SC_CLOUD"]);

            await context.SaveChangesAsync();
        }

        // ===== SubjectCurriculumElectiveGroup (m-n relationships) =====
        if (!context.Set<SubjectCurriculumElectiveGroup>().Any())
        {
            var scEgRelationships = new[]
            {
                // HK6: Web technologies
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_WEBJ",   ElectiveGroupId = "EG_WEB6" },
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_WEBNET", ElectiveGroupId = "EG_WEB6" },
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_WEBJS",  ElectiveGroupId = "EG_WEB6" },
                
                // HK6: Skills
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_UXUI",   ElectiveGroupId = "EG_SKILL6" },
                
                // HK7: Data & AI
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_AI",     ElectiveGroupId = "EG_DATA7" },
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_DSSS",   ElectiveGroupId = "EG_DATA7" },
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_ANM",     ElectiveGroupId = "EG_DATA7" },
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_CSDLPT", ElectiveGroupId = "EG_DATA7" },
                
                // HK8: Data & AI (continued)
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_CLOUD", ElectiveGroupId = "EG_DATA8" },
                new SubjectCurriculumElectiveGroup { SubjectCurriculumId = "SC_MOB",    ElectiveGroupId = "EG_DATA8" }
            };
            
            context.Set<SubjectCurriculumElectiveGroup>().AddRange(scEgRelationships);
            await context.SaveChangesAsync();
        }

        // ===== CourseClass (mở một số lớp HK1 & HK2) =====
        if (!CourseClasses.Any())
        {
            CourseClasses.AddRange(new[]
            {
                new CourseClass { Id="CTRR-S1-01",  SubjectId="CTRR",  SemesterId="S1", LecturerId="GV001", MaxCapacity=60, CurrentCapacity=0, Status=ClassStatus.OpenForRegistration },
                new CourseClass { Id="ENG1-S1-01",  SubjectId="ENG1",  SemesterId="S1", LecturerId="GV004", MaxCapacity=60, CurrentCapacity=0, Status=ClassStatus.OpenForRegistration },

                new CourseClass { Id="KTLT-S2-01",  SubjectId="KTLT",  SemesterId="S2", LecturerId="GV001", MaxCapacity=50, CurrentCapacity=0, Status=ClassStatus.OpenForRegistration },
                new CourseClass { Id="OOP-S2-01",   SubjectId="OOP",   SemesterId="S2", LecturerId="GV003", MaxCapacity=50, CurrentCapacity=0, Status=ClassStatus.OpenForRegistration }
            });
            await context.SaveChangesAsync();
        }

        // ===== PracticeGroup (cho lớp có thực hành) =====
        if (!PracticeGroups.Any())
        {
            PracticeGroups.AddRange(new[]
            {
                new PracticeGroup { Id="PG-CTRR-01", CourseClassId="CTRR-S1-01", Name="Thực hành 01", MaxCapacity=30, CurrentCapacity=0, LecturerId="GV001" },
                new PracticeGroup { Id="PG-KTLT-01", CourseClassId="KTLT-S2-01", Name="Thực hành 01", MaxCapacity=25, CurrentCapacity=0, LecturerId="GV001" },
                new PracticeGroup { Id="PG-OOP-01",  CourseClassId="OOP-S2-01",  Name="Thực hành 01", MaxCapacity=25, CurrentCapacity=0, LecturerId="GV003" }
            });
            await context.SaveChangesAsync();
        }

        // ===== Schedule (minh họa – cả lý thuyết & thực hành) =====
        if (!Schedules.Any())
        {
            Schedules.AddRange(new[]
            {
                // CTRR-S1-01 (LT)
                new Schedule { Id="S1", CourseClassId="CTRR-S1-01", DayOfWeek=WeekDay.Monday,    StartPeriod=1, EndPeriod=3, RoomId="A101" },
                // CTRR-S1-01 (TH)
                new Schedule { Id="S2", PracticeGroupId="PG-CTRR-01", DayOfWeek=WeekDay.Wednesday, StartPeriod=1, EndPeriod=3, RoomId="A102" },

                // ENG1-S1-01 (LT)
                new Schedule { Id="S3", CourseClassId="ENG1-S1-01", DayOfWeek=WeekDay.Tuesday,  StartPeriod=4, EndPeriod=6, RoomId="B201" },

                // KTLT-S2-01
                new Schedule { Id="S4", CourseClassId="KTLT-S2-01", DayOfWeek=WeekDay.Monday,    StartPeriod=4, EndPeriod=6, RoomId="A101" },
                new Schedule { Id="S5", PracticeGroupId="PG-KTLT-01", DayOfWeek=WeekDay.Thursday, StartPeriod=1, EndPeriod=3, RoomId="A102" },

                // OOP-S2-01
                new Schedule { Id="S6", CourseClassId="OOP-S2-01", DayOfWeek=WeekDay.Tuesday,    StartPeriod=1, EndPeriod=3, RoomId="B201" },
                new Schedule { Id="S7", PracticeGroupId="PG-OOP-01", DayOfWeek=WeekDay.Friday,     StartPeriod=1, EndPeriod=3, RoomId="B202" }
            });
            await context.SaveChangesAsync();
        }

        // ===== Enrollment (mẫu HK1) =====
        if (!Enrollments.Any())
        {
            Enrollments.AddRange(new[]
            {
                new Enrollment { Id="E001", StudentId="SV170001", CourseClassId="CTRR-S1-01", PracticeGroupId="PG-CTRR-01", EnrollmentDate = new DateTime(2021,9,10) },
                new Enrollment { Id="E002", StudentId="SV170002", CourseClassId="CTRR-S1-01", PracticeGroupId="PG-CTRR-01", EnrollmentDate = new DateTime(2021,9,10) },
                new Enrollment { Id="E003", StudentId="SV170003", CourseClassId="ENG1-S1-01", PracticeGroupId=null,         EnrollmentDate = new DateTime(2021,9,11) }
            });
            await context.SaveChangesAsync();
        }
    }

    private static async Task CreateAdminUserAsync(UserManager<IdentityUser> userManager)
    {
        const string adminUsername = "admin";
        const string adminPassword = "Admin123!";
        const string adminEmail = "admin@university.edu";

        var existingUser = await userManager.FindByNameAsync(adminUsername);
        if (existingUser == null)
        {
            var adminUser = new IdentityUser
            {
                UserName = adminUsername,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                // Create Admin record
                var admin = new Admin
                {
                    Id = adminUser.Id,
                    Username = adminUsername,
                    FullName = "System Administrator",
                    Email = adminEmail,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                // Note: We'll add this to context in the main seed method
                Console.WriteLine($"Admin user created: {adminUsername}");
            }
            else
            {
                Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            Console.WriteLine("Admin user already exists");
        }
    }
}

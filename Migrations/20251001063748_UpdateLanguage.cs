using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "curricula",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curricula", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    room_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "semesters",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_semesters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "elective_groups",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    required_credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elective_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_elective_groups_curricula_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lecturers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lecturer_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    department_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lecturers", x => x.id);
                    table.ForeignKey(
                        name: "fk_lecturers_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "program_cohorts",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    department_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_program_cohorts", x => x.id);
                    table.ForeignKey(
                        name: "fk_program_cohorts_curricula_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_program_cohorts_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    theory_credits = table.Column<int>(type: "int", nullable: false),
                    practice_credits = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_subjects_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    program_cohort_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_classes", x => x.id);
                    table.ForeignKey(
                        name: "fk_classes__program_cohorts_program_cohort_id",
                        column: x => x.program_cohort_id,
                        principalTable: "program_cohorts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_classes",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    subject_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    semester_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lecturer_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    max_capacity = table.Column<int>(type: "int", nullable: false),
                    current_capacity = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_classes", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_classes__lecturers_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "lecturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_classes__semesters_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semesters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_course_classes__subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject_curricula",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    subject_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false),
                    course_type = table.Column<int>(type: "int", nullable: false),
                    elective_group_id = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_curricula", x => x.id);
                    table.ForeignKey(
                        name: "fk_subject_curricula_curricula_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subject_curricula_elective_groups_elective_group_id",
                        column: x => x.elective_group_id,
                        principalTable: "elective_groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_subject_curricula_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subject_lecturers",
                columns: table => new
                {
                    subject_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lecturer_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_lecturers", x => new { x.subject_id, x.lecturer_id });
                    table.ForeignKey(
                        name: "fk_subject_lecturers_lecturers_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "lecturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subject_lecturers_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    student_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    class_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_classes_class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "practice_groups",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    course_class_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    max_capacity = table.Column<int>(type: "int", nullable: false),
                    current_capacity = table.Column<int>(type: "int", nullable: false),
                    lecturer_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_practice_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_practice_groups_course_classes_course_class_id",
                        column: x => x.course_class_id,
                        principalTable: "course_classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_practice_groups_lecturers_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "lecturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concurrent_courses",
                columns: table => new
                {
                    concurrent_courses_id = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    subject_curriculum2_id = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concurrent_courses", x => new { x.concurrent_courses_id, x.subject_curriculum2_id });
                    table.ForeignKey(
                        name: "fk_concurrent_courses__subject_curricula_concurrent_courses_id",
                        column: x => x.concurrent_courses_id,
                        principalTable: "subject_curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_concurrent_courses__subject_curricula_subject_curriculum2_id",
                        column: x => x.subject_curriculum2_id,
                        principalTable: "subject_curricula",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "corequisites",
                columns: table => new
                {
                    corequisites_id = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    subject_curriculum1_id = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_corequisites", x => new { x.corequisites_id, x.subject_curriculum1_id });
                    table.ForeignKey(
                        name: "fk_corequisites__subject_curricula_corequisites_id",
                        column: x => x.corequisites_id,
                        principalTable: "subject_curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_corequisites__subject_curricula_subject_curriculum1_id",
                        column: x => x.subject_curriculum1_id,
                        principalTable: "subject_curricula",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "prerequisites",
                columns: table => new
                {
                    prerequisites_id = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    subject_curriculum_id = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prerequisites", x => new { x.prerequisites_id, x.subject_curriculum_id });
                    table.ForeignKey(
                        name: "fk_prerequisites__subject_curricula_prerequisites_id",
                        column: x => x.prerequisites_id,
                        principalTable: "subject_curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_prerequisites__subject_curricula_subject_curriculum_id",
                        column: x => x.subject_curriculum_id,
                        principalTable: "subject_curricula",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    student_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    course_class_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    practice_group_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enrollments", x => x.id);
                    table.ForeignKey(
                        name: "fk_enrollments__practice_groups_practice_group_id",
                        column: x => x.practice_group_id,
                        principalTable: "practice_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_enrollments__students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enrollments_course_classes_course_class_id",
                        column: x => x.course_class_id,
                        principalTable: "course_classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    course_class_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    practice_group_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    day_of_week = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    start_period = table.Column<int>(type: "int", nullable: false),
                    end_period = table.Column<int>(type: "int", nullable: false),
                    room_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schedules", x => x.id);
                    table.ForeignKey(
                        name: "fk_schedules_course_classes_course_class_id",
                        column: x => x.course_class_id,
                        principalTable: "course_classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_schedules_practice_groups_practice_group_id",
                        column: x => x.practice_group_id,
                        principalTable: "practice_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_schedules_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_classes_program_cohort_id",
                table: "classes",
                column: "program_cohort_id");

            migrationBuilder.CreateIndex(
                name: "ix_concurrent_courses_subject_curriculum2_id",
                table: "concurrent_courses",
                column: "subject_curriculum2_id");

            migrationBuilder.CreateIndex(
                name: "ix_corequisites_subject_curriculum1_id",
                table: "corequisites",
                column: "subject_curriculum1_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_classes_lecturer_id",
                table: "course_classes",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_classes_semester_id",
                table: "course_classes",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_classes_subject_id",
                table: "course_classes",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_elective_groups_curriculum_id",
                table: "elective_groups",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_enrollments_course_class_id",
                table: "enrollments",
                column: "course_class_id");

            migrationBuilder.CreateIndex(
                name: "ix_enrollments_practice_group_id",
                table: "enrollments",
                column: "practice_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_enrollments_student_id",
                table: "enrollments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_lecturers_department_id",
                table: "lecturers",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_practice_groups_course_class_id",
                table: "practice_groups",
                column: "course_class_id");

            migrationBuilder.CreateIndex(
                name: "ix_practice_groups_lecturer_id",
                table: "practice_groups",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_prerequisites_subject_curriculum_id",
                table: "prerequisites",
                column: "subject_curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_program_cohorts_curriculum_id",
                table: "program_cohorts",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_program_cohorts_department_id",
                table: "program_cohorts",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_schedules_course_class_id",
                table: "schedules",
                column: "course_class_id");

            migrationBuilder.CreateIndex(
                name: "ix_schedules_practice_group_id",
                table: "schedules",
                column: "practice_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_schedules_room_id",
                table: "schedules",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_class_id",
                table: "students",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_curricula_curriculum_id",
                table: "subject_curricula",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_curricula_elective_group_id",
                table: "subject_curricula",
                column: "elective_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_curricula_subject_id",
                table: "subject_curricula",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_lecturers_lecturer_id",
                table: "subject_lecturers",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_subjects_department_id",
                table: "subjects",
                column: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concurrent_courses");

            migrationBuilder.DropTable(
                name: "corequisites");

            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "prerequisites");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "subject_lecturers");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subject_curricula");

            migrationBuilder.DropTable(
                name: "practice_groups");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "elective_groups");

            migrationBuilder.DropTable(
                name: "course_classes");

            migrationBuilder.DropTable(
                name: "program_cohorts");

            migrationBuilder.DropTable(
                name: "lecturers");

            migrationBuilder.DropTable(
                name: "semesters");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "curricula");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}

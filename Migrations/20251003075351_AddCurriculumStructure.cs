using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class AddCurriculumStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_enrollments_elective_groups_attributed_elective_group_id",
                table: "enrollments");

            migrationBuilder.DropTable(
                name: "concurrent_courses");

            migrationBuilder.DropTable(
                name: "corequisites");

            migrationBuilder.DropTable(
                name: "prerequisites");

            migrationBuilder.DropTable(
                name: "subject_curriculum_elective_groups");

            migrationBuilder.DropTable(
                name: "elective_groups");

            migrationBuilder.DropTable(
                name: "subject_curriculums");

            migrationBuilder.DropIndex(
                name: "ix_enrollments_attributed_elective_group_id",
                table: "enrollments");

            migrationBuilder.AddColumn<int>(
                name: "enrollment_type",
                table: "enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "grade_id",
                table: "enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "curriculum_terms",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    term_order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curriculum_terms", x => x.id);
                    table.ForeignKey(
                        name: "fk_curriculum_terms_curriculums_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    midterm_score = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    final_score = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    total_score10 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    total_score4 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    letter_grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "curriculum_elective_groups",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_term_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    min_credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curriculum_elective_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_curriculum_elective_groups__curriculum_terms_curriculum_term_id",
                        column: x => x.curriculum_term_id,
                        principalTable: "curriculum_terms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "curriculum_term_subjects",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_term_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    subject_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curriculum_term_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_curriculum_term_subjects__subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_curriculum_term_subjects_curriculum_terms_curriculum_term_id",
                        column: x => x.curriculum_term_id,
                        principalTable: "curriculum_terms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grade_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    component_type = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    score = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grade_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_grade_detail_grade_grade_id",
                        column: x => x.grade_id,
                        principalTable: "grade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "curriculum_elective_group_subjects",
                columns: table => new
                {
                    elective_group_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    subject_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curriculum_elective_group_subjects", x => new { x.elective_group_id, x.subject_id });
                    table.ForeignKey(
                        name: "fk_curriculum_elective_group_subjects__subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_curriculum_elective_group_subjects_curriculum_elective_groups_elective_group_id",
                        column: x => x.elective_group_id,
                        principalTable: "curriculum_elective_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_enrollments_grade_id",
                table: "enrollments",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_elective_group_subjects_subject_id",
                table: "curriculum_elective_group_subjects",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_elective_groups_curriculum_term_id",
                table: "curriculum_elective_groups",
                column: "curriculum_term_id");

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_term_subjects_curriculum_term_id",
                table: "curriculum_term_subjects",
                column: "curriculum_term_id");

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_term_subjects_subject_id",
                table: "curriculum_term_subjects",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_terms_curriculum_id",
                table: "curriculum_terms",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_grade_detail_grade_id",
                table: "grade_detail",
                column: "grade_id");

            migrationBuilder.AddForeignKey(
                name: "fk_enrollments__grade_grade_id",
                table: "enrollments",
                column: "grade_id",
                principalTable: "grade",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_enrollments__grade_grade_id",
                table: "enrollments");

            migrationBuilder.DropTable(
                name: "curriculum_elective_group_subjects");

            migrationBuilder.DropTable(
                name: "curriculum_term_subjects");

            migrationBuilder.DropTable(
                name: "grade_detail");

            migrationBuilder.DropTable(
                name: "curriculum_elective_groups");

            migrationBuilder.DropTable(
                name: "grade");

            migrationBuilder.DropTable(
                name: "curriculum_terms");

            migrationBuilder.DropIndex(
                name: "ix_enrollments_grade_id",
                table: "enrollments");

            migrationBuilder.DropColumn(
                name: "enrollment_type",
                table: "enrollments");

            migrationBuilder.DropColumn(
                name: "grade_id",
                table: "enrollments");

            migrationBuilder.CreateTable(
                name: "elective_groups",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    required_credits = table.Column<int>(type: "int", nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elective_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_elective_groups_curriculums_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject_curriculums",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    subject_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    course_type = table.Column<int>(type: "int", nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_curriculums", x => x.id);
                    table.ForeignKey(
                        name: "fk_subject_curriculums_curriculums_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subject_curriculums_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
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
                        name: "fk_concurrent_courses_subject_curriculums_concurrent_courses_id",
                        column: x => x.concurrent_courses_id,
                        principalTable: "subject_curriculums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_concurrent_courses_subject_curriculums_subject_curriculum2_id",
                        column: x => x.subject_curriculum2_id,
                        principalTable: "subject_curriculums",
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
                        name: "fk_corequisites_subject_curriculums_corequisites_id",
                        column: x => x.corequisites_id,
                        principalTable: "subject_curriculums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_corequisites_subject_curriculums_subject_curriculum1_id",
                        column: x => x.subject_curriculum1_id,
                        principalTable: "subject_curriculums",
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
                        name: "fk_prerequisites_subject_curriculums_prerequisites_id",
                        column: x => x.prerequisites_id,
                        principalTable: "subject_curriculums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_prerequisites_subject_curriculums_subject_curriculum_id",
                        column: x => x.subject_curriculum_id,
                        principalTable: "subject_curriculums",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subject_curriculum_elective_groups",
                columns: table => new
                {
                    subject_curriculum_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    elective_group_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_curriculum_elective_groups", x => new { x.subject_curriculum_id, x.elective_group_id });
                    table.CheckConstraint("ck_sc_eg_same_ids", "subject_curriculum_id <> '' AND elective_group_id <> ''");
                    table.ForeignKey(
                        name: "fk_subject_curriculum_elective_groups_elective_groups_elective_group_id",
                        column: x => x.elective_group_id,
                        principalTable: "elective_groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_subject_curriculum_elective_groups_subject_curriculums_subject_curriculum_id",
                        column: x => x.subject_curriculum_id,
                        principalTable: "subject_curriculums",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_enrollments_attributed_elective_group_id",
                table: "enrollments",
                column: "attributed_elective_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_concurrent_courses_subject_curriculum2_id",
                table: "concurrent_courses",
                column: "subject_curriculum2_id");

            migrationBuilder.CreateIndex(
                name: "ix_corequisites_subject_curriculum1_id",
                table: "corequisites",
                column: "subject_curriculum1_id");

            migrationBuilder.CreateIndex(
                name: "ix_elective_groups_curriculum_id_semester_name",
                table: "elective_groups",
                columns: new[] { "curriculum_id", "semester", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_prerequisites_subject_curriculum_id",
                table: "prerequisites",
                column: "subject_curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_curriculum_elective_groups_elective_group_id",
                table: "subject_curriculum_elective_groups",
                column: "elective_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_curriculums_curriculum_id",
                table: "subject_curriculums",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_curriculums_subject_id",
                table: "subject_curriculums",
                column: "subject_id");

            migrationBuilder.AddForeignKey(
                name: "fk_enrollments_elective_groups_attributed_elective_group_id",
                table: "enrollments",
                column: "attributed_elective_group_id",
                principalTable: "elective_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class RenamePluralization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_concurrent_courses__subject_curricula_concurrent_courses_id",
                table: "concurrent_courses");

            migrationBuilder.DropForeignKey(
                name: "fk_concurrent_courses__subject_curricula_subject_curriculum2_id",
                table: "concurrent_courses");

            migrationBuilder.DropForeignKey(
                name: "fk_corequisites__subject_curricula_corequisites_id",
                table: "corequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_corequisites__subject_curricula_subject_curriculum1_id",
                table: "corequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_elective_groups_curricula_curriculum_id",
                table: "elective_groups");

            migrationBuilder.DropForeignKey(
                name: "fk_prerequisites__subject_curricula_prerequisites_id",
                table: "prerequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_prerequisites__subject_curricula_subject_curriculum_id",
                table: "prerequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_program_cohorts_curricula_curriculum_id",
                table: "program_cohorts");

            migrationBuilder.DropForeignKey(
                name: "fk_subject_curricula_curricula_curriculum_id",
                table: "subject_curricula");

            migrationBuilder.DropForeignKey(
                name: "fk_subject_curricula_elective_groups_elective_group_id",
                table: "subject_curricula");

            migrationBuilder.DropForeignKey(
                name: "fk_subject_curricula_subjects_subject_id",
                table: "subject_curricula");

            migrationBuilder.DropPrimaryKey(
                name: "pk_subject_curricula",
                table: "subject_curricula");

            migrationBuilder.DropPrimaryKey(
                name: "pk_curricula",
                table: "curricula");

            migrationBuilder.RenameTable(
                name: "subject_curricula",
                newName: "subject_curriculums");

            migrationBuilder.RenameTable(
                name: "curricula",
                newName: "curriculums");

            migrationBuilder.RenameIndex(
                name: "ix_subject_curricula_subject_id",
                table: "subject_curriculums",
                newName: "ix_subject_curriculums_subject_id");

            migrationBuilder.RenameIndex(
                name: "ix_subject_curricula_elective_group_id",
                table: "subject_curriculums",
                newName: "ix_subject_curriculums_elective_group_id");

            migrationBuilder.RenameIndex(
                name: "ix_subject_curricula_curriculum_id",
                table: "subject_curriculums",
                newName: "ix_subject_curriculums_curriculum_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_subject_curriculums",
                table: "subject_curriculums",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_curriculums",
                table: "curriculums",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_concurrent_courses_subject_curriculums_concurrent_courses_id",
                table: "concurrent_courses",
                column: "concurrent_courses_id",
                principalTable: "subject_curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_concurrent_courses_subject_curriculums_subject_curriculum2_id",
                table: "concurrent_courses",
                column: "subject_curriculum2_id",
                principalTable: "subject_curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_corequisites_subject_curriculums_corequisites_id",
                table: "corequisites",
                column: "corequisites_id",
                principalTable: "subject_curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_corequisites_subject_curriculums_subject_curriculum1_id",
                table: "corequisites",
                column: "subject_curriculum1_id",
                principalTable: "subject_curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_elective_groups_curriculums_curriculum_id",
                table: "elective_groups",
                column: "curriculum_id",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_prerequisites_subject_curriculums_prerequisites_id",
                table: "prerequisites",
                column: "prerequisites_id",
                principalTable: "subject_curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_prerequisites_subject_curriculums_subject_curriculum_id",
                table: "prerequisites",
                column: "subject_curriculum_id",
                principalTable: "subject_curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_program_cohorts_curriculums_curriculum_id",
                table: "program_cohorts",
                column: "curriculum_id",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curriculums_curriculums_curriculum_id",
                table: "subject_curriculums",
                column: "curriculum_id",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curriculums_elective_groups_elective_group_id",
                table: "subject_curriculums",
                column: "elective_group_id",
                principalTable: "elective_groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curriculums_subjects_subject_id",
                table: "subject_curriculums",
                column: "subject_id",
                principalTable: "subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_concurrent_courses_subject_curriculums_concurrent_courses_id",
                table: "concurrent_courses");

            migrationBuilder.DropForeignKey(
                name: "fk_concurrent_courses_subject_curriculums_subject_curriculum2_id",
                table: "concurrent_courses");

            migrationBuilder.DropForeignKey(
                name: "fk_corequisites_subject_curriculums_corequisites_id",
                table: "corequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_corequisites_subject_curriculums_subject_curriculum1_id",
                table: "corequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_elective_groups_curriculums_curriculum_id",
                table: "elective_groups");

            migrationBuilder.DropForeignKey(
                name: "fk_prerequisites_subject_curriculums_prerequisites_id",
                table: "prerequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_prerequisites_subject_curriculums_subject_curriculum_id",
                table: "prerequisites");

            migrationBuilder.DropForeignKey(
                name: "fk_program_cohorts_curriculums_curriculum_id",
                table: "program_cohorts");

            migrationBuilder.DropForeignKey(
                name: "fk_subject_curriculums_curriculums_curriculum_id",
                table: "subject_curriculums");

            migrationBuilder.DropForeignKey(
                name: "fk_subject_curriculums_elective_groups_elective_group_id",
                table: "subject_curriculums");

            migrationBuilder.DropForeignKey(
                name: "fk_subject_curriculums_subjects_subject_id",
                table: "subject_curriculums");

            migrationBuilder.DropPrimaryKey(
                name: "pk_subject_curriculums",
                table: "subject_curriculums");

            migrationBuilder.DropPrimaryKey(
                name: "pk_curriculums",
                table: "curriculums");

            migrationBuilder.RenameTable(
                name: "subject_curriculums",
                newName: "subject_curricula");

            migrationBuilder.RenameTable(
                name: "curriculums",
                newName: "curricula");

            migrationBuilder.RenameIndex(
                name: "ix_subject_curriculums_subject_id",
                table: "subject_curricula",
                newName: "ix_subject_curricula_subject_id");

            migrationBuilder.RenameIndex(
                name: "ix_subject_curriculums_elective_group_id",
                table: "subject_curricula",
                newName: "ix_subject_curricula_elective_group_id");

            migrationBuilder.RenameIndex(
                name: "ix_subject_curriculums_curriculum_id",
                table: "subject_curricula",
                newName: "ix_subject_curricula_curriculum_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_subject_curricula",
                table: "subject_curricula",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_curricula",
                table: "curricula",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_concurrent_courses__subject_curricula_concurrent_courses_id",
                table: "concurrent_courses",
                column: "concurrent_courses_id",
                principalTable: "subject_curricula",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_concurrent_courses__subject_curricula_subject_curriculum2_id",
                table: "concurrent_courses",
                column: "subject_curriculum2_id",
                principalTable: "subject_curricula",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_corequisites__subject_curricula_corequisites_id",
                table: "corequisites",
                column: "corequisites_id",
                principalTable: "subject_curricula",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_corequisites__subject_curricula_subject_curriculum1_id",
                table: "corequisites",
                column: "subject_curriculum1_id",
                principalTable: "subject_curricula",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_elective_groups_curricula_curriculum_id",
                table: "elective_groups",
                column: "curriculum_id",
                principalTable: "curricula",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_prerequisites__subject_curricula_prerequisites_id",
                table: "prerequisites",
                column: "prerequisites_id",
                principalTable: "subject_curricula",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_prerequisites__subject_curricula_subject_curriculum_id",
                table: "prerequisites",
                column: "subject_curriculum_id",
                principalTable: "subject_curricula",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_program_cohorts_curricula_curriculum_id",
                table: "program_cohorts",
                column: "curriculum_id",
                principalTable: "curricula",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curricula_curricula_curriculum_id",
                table: "subject_curricula",
                column: "curriculum_id",
                principalTable: "curricula",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curricula_elective_groups_elective_group_id",
                table: "subject_curricula",
                column: "elective_group_id",
                principalTable: "elective_groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curricula_subjects_subject_id",
                table: "subject_curricula",
                column: "subject_id",
                principalTable: "subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

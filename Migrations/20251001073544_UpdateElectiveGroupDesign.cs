using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateElectiveGroupDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_subject_curriculums_elective_groups_elective_group_id",
                table: "subject_curriculums");

            migrationBuilder.DropIndex(
                name: "ix_subject_curriculums_elective_group_id",
                table: "subject_curriculums");

            migrationBuilder.DropIndex(
                name: "ix_elective_groups_curriculum_id",
                table: "elective_groups");

            migrationBuilder.DropColumn(
                name: "elective_group_id",
                table: "subject_curriculums");

            migrationBuilder.AddColumn<string>(
                name: "attributed_elective_group_id",
                table: "enrollments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "semester",
                table: "elective_groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "ix_elective_groups_curriculum_id_semester_name",
                table: "elective_groups",
                columns: new[] { "curriculum_id", "semester", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subject_curriculum_elective_groups_elective_group_id",
                table: "subject_curriculum_elective_groups",
                column: "elective_group_id");

            migrationBuilder.AddForeignKey(
                name: "fk_enrollments_elective_groups_attributed_elective_group_id",
                table: "enrollments",
                column: "attributed_elective_group_id",
                principalTable: "elective_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_enrollments_elective_groups_attributed_elective_group_id",
                table: "enrollments");

            migrationBuilder.DropTable(
                name: "subject_curriculum_elective_groups");

            migrationBuilder.DropIndex(
                name: "ix_enrollments_attributed_elective_group_id",
                table: "enrollments");

            migrationBuilder.DropIndex(
                name: "ix_elective_groups_curriculum_id_semester_name",
                table: "elective_groups");

            migrationBuilder.DropColumn(
                name: "attributed_elective_group_id",
                table: "enrollments");

            migrationBuilder.DropColumn(
                name: "semester",
                table: "elective_groups");

            migrationBuilder.AddColumn<string>(
                name: "elective_group_id",
                table: "subject_curriculums",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_subject_curriculums_elective_group_id",
                table: "subject_curriculums",
                column: "elective_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_elective_groups_curriculum_id",
                table: "elective_groups",
                column: "curriculum_id");

            migrationBuilder.AddForeignKey(
                name: "fk_subject_curriculums_elective_groups_elective_group_id",
                table: "subject_curriculums",
                column: "elective_group_id",
                principalTable: "elective_groups",
                principalColumn: "id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class AddCampusBuildingFloorHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "building",
                table: "rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "building_id",
                table: "rooms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "campus",
                table: "rooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "campus_id",
                table: "rooms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "floor",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "floor_id",
                table: "rooms",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "campuses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_campuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    campus_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_buildings", x => x.id);
                    table.ForeignKey(
                        name: "fk_buildings__campuses_campus_id",
                        column: x => x.campus_id,
                        principalTable: "campuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    building_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_floors", x => x.id);
                    table.ForeignKey(
                        name: "fk_floors_buildings_building_id",
                        column: x => x.building_id,
                        principalTable: "buildings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_rooms_building_id",
                table: "rooms",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_campus_id",
                table: "rooms",
                column: "campus_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_floor_id",
                table: "rooms",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_campus_id",
                table: "buildings",
                column: "campus_id");

            migrationBuilder.CreateIndex(
                name: "ix_floors_building_id",
                table: "floors",
                column: "building_id");

            migrationBuilder.AddForeignKey(
                name: "fk_rooms_buildings_building_id",
                table: "rooms",
                column: "building_id",
                principalTable: "buildings",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_rooms_campuses_campus_id",
                table: "rooms",
                column: "campus_id",
                principalTable: "campuses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_rooms_floors_floor_id",
                table: "rooms",
                column: "floor_id",
                principalTable: "floors",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_rooms_buildings_building_id",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_rooms_campuses_campus_id",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_rooms_floors_floor_id",
                table: "rooms");

            migrationBuilder.DropTable(
                name: "floors");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "campuses");

            migrationBuilder.DropIndex(
                name: "ix_rooms_building_id",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "ix_rooms_campus_id",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "ix_rooms_floor_id",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "building",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "building_id",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "campus",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "campus_id",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "floor",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "floor_id",
                table: "rooms");
        }
    }
}

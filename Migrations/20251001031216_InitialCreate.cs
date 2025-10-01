using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chuong_trinh_hoc",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_chuong_trinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chuong_trinh_hoc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hoc_ky",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_hoc_ky = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hoc_ky", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "khoa",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_khoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_khoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phong_hoc",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_phong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    suc_chua = table.Column<int>(type: "int", nullable: false),
                    loai_phong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dia_diem = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_phong_hoc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "giang_vien",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ma_gv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ho_ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    khoa_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_giang_vien", x => x.id);
                    table.ForeignKey(
                        name: "fk_giang_vien__danh_sach_khoa_khoa_id",
                        column: x => x.khoa_id,
                        principalTable: "khoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "khoa_dao_tao",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_khoa_dao_tao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_bat_dau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_ket_thuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    khoa_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    chuong_trinh_hoc_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_khoa_dao_tao", x => x.id);
                    table.ForeignKey(
                        name: "fk_khoa_dao_tao_chuong_trinh_hoc_chuong_trinh_hoc_id",
                        column: x => x.chuong_trinh_hoc_id,
                        principalTable: "chuong_trinh_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_khoa_dao_tao_khoa_khoa_id",
                        column: x => x.khoa_id,
                        principalTable: "khoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mon_hoc",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_mon_hoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tin_chi_lt = table.Column<int>(type: "int", nullable: false),
                    tin_chi_th = table.Column<int>(type: "int", nullable: false),
                    khoa_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    chuong_trinh_hoc_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mon_hoc", x => x.id);
                    table.ForeignKey(
                        name: "fk_mon_hoc_chuong_trinh_hoc_chuong_trinh_hoc_id",
                        column: x => x.chuong_trinh_hoc_id,
                        principalTable: "chuong_trinh_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_mon_hoc_khoa_khoa_id",
                        column: x => x.khoa_id,
                        principalTable: "khoa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lop_danh_nghia",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_lop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    khoa_dao_tao_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lop_danh_nghia", x => x.id);
                    table.ForeignKey(
                        name: "fk_lop_danh_nghia_khoa_dao_tao_khoa_dao_tao_id",
                        column: x => x.khoa_dao_tao_id,
                        principalTable: "khoa_dao_tao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lop_hoc_phan",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    mon_hoc_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    hoc_ky_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    giang_vien_lt_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    so_luong_toi_da_lt = table.Column<int>(type: "int", nullable: false),
                    so_luong_hien_tai_lt = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lop_hoc_phan", x => x.id);
                    table.ForeignKey(
                        name: "fk_lop_hoc_phan__danh_sach_mon_hoc_mon_hoc_id",
                        column: x => x.mon_hoc_id,
                        principalTable: "mon_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lop_hoc_phan_giang_vien_giang_vien_lt_id",
                        column: x => x.giang_vien_lt_id,
                        principalTable: "giang_vien",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lop_hoc_phan_hoc_ky_hoc_ky_id",
                        column: x => x.hoc_ky_id,
                        principalTable: "hoc_ky",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mon_hoc_giang_vien",
                columns: table => new
                {
                    mon_hoc_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    giang_vien_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mon_hoc_giang_vien", x => new { x.mon_hoc_id, x.giang_vien_id });
                    table.ForeignKey(
                        name: "fk_mon_hoc_giang_vien_giang_vien_giang_vien_id",
                        column: x => x.giang_vien_id,
                        principalTable: "giang_vien",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mon_hoc_giang_vien_mon_hoc_mon_hoc_id",
                        column: x => x.mon_hoc_id,
                        principalTable: "mon_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sinh_vien",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ma_sv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ho_ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lop_danh_nghia_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sinh_vien", x => x.id);
                    table.ForeignKey(
                        name: "fk_sinh_vien_lop_danh_nghia_lop_danh_nghia_id",
                        column: x => x.lop_danh_nghia_id,
                        principalTable: "lop_danh_nghia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhom_thuc_hanh",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lop_hoc_phan_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ten_nhom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_luong_toi_da = table.Column<int>(type: "int", nullable: false),
                    so_luong_hien_tai = table.Column<int>(type: "int", nullable: false),
                    giang_vien_th_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nhom_thuc_hanh", x => x.id);
                    table.ForeignKey(
                        name: "fk_nhom_thuc_hanh_giang_vien_giang_vien_th_id",
                        column: x => x.giang_vien_th_id,
                        principalTable: "giang_vien",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_nhom_thuc_hanh_lop_hoc_phan_lop_hoc_phan_id",
                        column: x => x.lop_hoc_phan_id,
                        principalTable: "lop_hoc_phan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dang_ky_hoc_phan",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    sinh_vien_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lop_hoc_phan_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nhom_thuc_hanh_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ngay_dang_ky = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dang_ky_hoc_phan", x => x.id);
                    table.ForeignKey(
                        name: "fk_dang_ky_hoc_phan__danh_sach_lop_hoc_phan_lop_hoc_phan_id",
                        column: x => x.lop_hoc_phan_id,
                        principalTable: "lop_hoc_phan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dang_ky_hoc_phan__danh_sach_nhom_thuc_hanh_nhom_thuc_hanh_id",
                        column: x => x.nhom_thuc_hanh_id,
                        principalTable: "nhom_thuc_hanh",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_dang_ky_hoc_phan__danh_sach_sinh_vien_sinh_vien_id",
                        column: x => x.sinh_vien_id,
                        principalTable: "sinh_vien",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lich_hoc_phan",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lop_hoc_phan_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    nhom_thuc_hanh_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    thu = table.Column<int>(type: "int", nullable: false),
                    tiet_bat_dau = table.Column<int>(type: "int", nullable: false),
                    tiet_ket_thuc = table.Column<int>(type: "int", nullable: false),
                    phong_hoc_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lich_hoc_phan", x => x.id);
                    table.ForeignKey(
                        name: "fk_lich_hoc_phan__danh_sach_lop_hoc_phan_lop_hoc_phan_id",
                        column: x => x.lop_hoc_phan_id,
                        principalTable: "lop_hoc_phan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lich_hoc_phan__danh_sach_nhom_thuc_hanh_nhom_thuc_hanh_id",
                        column: x => x.nhom_thuc_hanh_id,
                        principalTable: "nhom_thuc_hanh",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lich_hoc_phan__danh_sach_phong_hoc_phong_hoc_id",
                        column: x => x.phong_hoc_id,
                        principalTable: "phong_hoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_dang_ky_hoc_phan_lop_hoc_phan_id",
                table: "dang_ky_hoc_phan",
                column: "lop_hoc_phan_id");

            migrationBuilder.CreateIndex(
                name: "ix_dang_ky_hoc_phan_nhom_thuc_hanh_id",
                table: "dang_ky_hoc_phan",
                column: "nhom_thuc_hanh_id");

            migrationBuilder.CreateIndex(
                name: "ix_dang_ky_hoc_phan_sinh_vien_id",
                table: "dang_ky_hoc_phan",
                column: "sinh_vien_id");

            migrationBuilder.CreateIndex(
                name: "ix_giang_vien_khoa_id",
                table: "giang_vien",
                column: "khoa_id");

            migrationBuilder.CreateIndex(
                name: "ix_khoa_dao_tao_chuong_trinh_hoc_id",
                table: "khoa_dao_tao",
                column: "chuong_trinh_hoc_id");

            migrationBuilder.CreateIndex(
                name: "ix_khoa_dao_tao_khoa_id",
                table: "khoa_dao_tao",
                column: "khoa_id");

            migrationBuilder.CreateIndex(
                name: "ix_lich_hoc_phan_lop_hoc_phan_id",
                table: "lich_hoc_phan",
                column: "lop_hoc_phan_id");

            migrationBuilder.CreateIndex(
                name: "ix_lich_hoc_phan_nhom_thuc_hanh_id",
                table: "lich_hoc_phan",
                column: "nhom_thuc_hanh_id");

            migrationBuilder.CreateIndex(
                name: "ix_lich_hoc_phan_phong_hoc_id",
                table: "lich_hoc_phan",
                column: "phong_hoc_id");

            migrationBuilder.CreateIndex(
                name: "ix_lop_danh_nghia_khoa_dao_tao_id",
                table: "lop_danh_nghia",
                column: "khoa_dao_tao_id");

            migrationBuilder.CreateIndex(
                name: "ix_lop_hoc_phan_giang_vien_lt_id",
                table: "lop_hoc_phan",
                column: "giang_vien_lt_id");

            migrationBuilder.CreateIndex(
                name: "ix_lop_hoc_phan_hoc_ky_id",
                table: "lop_hoc_phan",
                column: "hoc_ky_id");

            migrationBuilder.CreateIndex(
                name: "ix_lop_hoc_phan_mon_hoc_id",
                table: "lop_hoc_phan",
                column: "mon_hoc_id");

            migrationBuilder.CreateIndex(
                name: "ix_mon_hoc_chuong_trinh_hoc_id",
                table: "mon_hoc",
                column: "chuong_trinh_hoc_id");

            migrationBuilder.CreateIndex(
                name: "ix_mon_hoc_khoa_id",
                table: "mon_hoc",
                column: "khoa_id");

            migrationBuilder.CreateIndex(
                name: "ix_mon_hoc_giang_vien_giang_vien_id",
                table: "mon_hoc_giang_vien",
                column: "giang_vien_id");

            migrationBuilder.CreateIndex(
                name: "ix_nhom_thuc_hanh_giang_vien_th_id",
                table: "nhom_thuc_hanh",
                column: "giang_vien_th_id");

            migrationBuilder.CreateIndex(
                name: "ix_nhom_thuc_hanh_lop_hoc_phan_id",
                table: "nhom_thuc_hanh",
                column: "lop_hoc_phan_id");

            migrationBuilder.CreateIndex(
                name: "ix_sinh_vien_lop_danh_nghia_id",
                table: "sinh_vien",
                column: "lop_danh_nghia_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dang_ky_hoc_phan");

            migrationBuilder.DropTable(
                name: "lich_hoc_phan");

            migrationBuilder.DropTable(
                name: "mon_hoc_giang_vien");

            migrationBuilder.DropTable(
                name: "sinh_vien");

            migrationBuilder.DropTable(
                name: "nhom_thuc_hanh");

            migrationBuilder.DropTable(
                name: "phong_hoc");

            migrationBuilder.DropTable(
                name: "lop_danh_nghia");

            migrationBuilder.DropTable(
                name: "lop_hoc_phan");

            migrationBuilder.DropTable(
                name: "khoa_dao_tao");

            migrationBuilder.DropTable(
                name: "mon_hoc");

            migrationBuilder.DropTable(
                name: "giang_vien");

            migrationBuilder.DropTable(
                name: "hoc_ky");

            migrationBuilder.DropTable(
                name: "chuong_trinh_hoc");

            migrationBuilder.DropTable(
                name: "khoa");
        }
    }
}

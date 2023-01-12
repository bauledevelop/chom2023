using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHOM.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOAI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HINH = table.Column<string>(type: "nvarchar(MAX)", maxLength: 2147483647, nullable: false),
                    TUADE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SLIDE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NGUON = table.Column<string>(type: "nvarchar(MAX)", maxLength: 2147483647, nullable: false),
                    LINK = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLIDE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "THUVIEN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TUADE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HINH = table.Column<string>(type: "nvarchar(MAX)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUVIEN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DUAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TUADE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HINHGT = table.Column<string>(type: "nvarchar(MAX)", maxLength: 2147483647, nullable: false),
                    NOIDUNG = table.Column<string>(type: "ntext", nullable: false),
                    MaThuVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DUAN_THUVIEN_MaThuVien",
                        column: x => x.MaThuVien,
                        principalTable: "THUVIEN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_MaThuVien",
                table: "DUAN",
                column: "MaThuVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DUAN");

            migrationBuilder.DropTable(
                name: "LOAI");

            migrationBuilder.DropTable(
                name: "SLIDE");

            migrationBuilder.DropTable(
                name: "THUVIEN");
        }
    }
}

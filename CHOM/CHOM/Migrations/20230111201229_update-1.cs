using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHOM.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDMucLuc",
                table: "Loai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MucLucID",
                table: "Loai",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MucLuc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucLuc", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loai_MucLucID",
                table: "Loai",
                column: "MucLucID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loai_MucLuc_MucLucID",
                table: "Loai",
                column: "MucLucID",
                principalTable: "MucLuc",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loai_MucLuc_MucLucID",
                table: "Loai");

            migrationBuilder.DropTable(
                name: "MucLuc");

            migrationBuilder.DropIndex(
                name: "IX_Loai_MucLucID",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "IDMucLuc",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "MucLucID",
                table: "Loai");
        }
    }
}

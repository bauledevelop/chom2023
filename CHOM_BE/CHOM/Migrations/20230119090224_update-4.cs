using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHOM.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhGT",
                table: "DuAn",
                type: "nvarchar(MAX)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "BoSuuTam",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhGT",
                table: "DuAn",
                type: "nvarchar(MAX)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "BoSuuTam",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}

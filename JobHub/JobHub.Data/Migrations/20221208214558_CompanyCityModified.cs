using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHub.Infrastructure.Migrations
{
    public partial class CompanyCityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

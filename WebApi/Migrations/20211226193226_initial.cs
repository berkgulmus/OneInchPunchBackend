using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Users",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "FirsName");
        }
    }
}

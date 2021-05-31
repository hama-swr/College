using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Migrations
{
    public partial class AddNewFieldAndDataAnnotaionToStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Student");
        }
    }
}

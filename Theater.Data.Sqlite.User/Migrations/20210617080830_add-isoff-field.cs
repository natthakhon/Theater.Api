using Microsoft.EntityFrameworkCore.Migrations;

namespace Theater.Data.Sqlite.User.Migrations
{
    public partial class addisofffield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOff",
                table: "Login",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOff",
                table: "Login");
        }
    }
}

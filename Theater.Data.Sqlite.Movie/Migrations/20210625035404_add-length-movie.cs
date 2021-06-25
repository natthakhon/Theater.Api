using Microsoft.EntityFrameworkCore.Migrations;

namespace Theater.Data.Sqlite.Movie.Migrations
{
    public partial class addlengthmovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Movie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Movie");
        }
    }
}

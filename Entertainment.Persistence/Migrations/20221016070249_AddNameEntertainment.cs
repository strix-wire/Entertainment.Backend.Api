using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entertainment.Persistence.Migrations
{
    public partial class AddNameEntertainment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entertainments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entertainments");
        }
    }
}

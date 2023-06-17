using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entertainment.Persistence.Migrations
{
    public partial class AddUrlSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlSite",
                table: "Entertainments",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlSite",
                table: "Entertainments");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entertainment.Persistence.Migrations
{
    public partial class AddCityAndRankingToEntertainmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Entertainments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Entertainments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Ranking",
                table: "Entertainments",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Entertainments");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Entertainments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}

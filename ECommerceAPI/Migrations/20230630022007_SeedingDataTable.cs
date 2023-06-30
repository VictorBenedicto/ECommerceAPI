using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { new Guid("3230bbc4-7487-4f8e-b873-5b60b2459ffc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caloy", "Nolimark" },
                    { new Guid("44406f2e-7f21-4af4-bb43-7e47887ae58f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor", "Benedicto" },
                    { new Guid("901ca54f-cfa6-4abe-9ccb-f3525b75ec9d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elisha", "Rebucas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3230bbc4-7487-4f8e-b873-5b60b2459ffc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("44406f2e-7f21-4af4-bb43-7e47887ae58f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("901ca54f-cfa6-4abe-9ccb-f3525b75ec9d"));

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

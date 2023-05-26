using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspCore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableUsersGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserState",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UsersGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroup", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 24, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 16, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 23, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.InsertData(
                table: "UsersGroup",
                columns: new[] { "Id", "Code", "CreatedDate", "Description" },
                values: new object[,]
                {
                    { 1, "Active", new DateTime(2023, 5, 24, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9766), "CSGO Lovers" },
                    { 2, "Blocked", new DateTime(2023, 5, 21, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9770), "Data miners" },
                    { 3, "Super Active", new DateTime(2023, 5, 6, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9773), "Minecraft Enjoyers" },
                    { 4, "Active", new DateTime(2023, 5, 11, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9775), "Starcraft Koreans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersGroup");

            migrationBuilder.AlterColumn<string>(
                name: "UserState",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 14, 16, 28, 53, 427, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 6, 16, 28, 53, 427, DateTimeKind.Local).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 13, 16, 28, 53, 427, DateTimeKind.Local).AddTicks(6413));
        }
    }
}

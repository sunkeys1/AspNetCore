using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class AddRazorCategoryToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "GroupId", "Login", "Password", "UserState" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 19, 20, 9, 37, 814, DateTimeKind.Local).AddTicks(8522), 2, "boris2020razror", "123boris123rz", "Blocked" },
                    { 2, new DateTime(2023, 5, 11, 20, 9, 37, 814, DateTimeKind.Local).AddTicks(8539), 1, "superadminrazor", "adminadmin1rz", "Active" },
                    { 3, new DateTime(2023, 5, 18, 20, 9, 37, 814, DateTimeKind.Local).AddTicks(8541), 2, "serejenkarazor", "imserge222rz", "Blocked" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

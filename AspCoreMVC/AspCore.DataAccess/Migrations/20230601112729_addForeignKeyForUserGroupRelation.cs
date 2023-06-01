using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForUserGroupRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UsersGroup",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UsersGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "UsersGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 30, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 22, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 29, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MemberId" },
                values: new object[] { new DateTime(2023, 5, 30, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1700), 1 });

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MemberId" },
                values: new object[] { new DateTime(2023, 5, 27, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1704), 1 });

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MemberId" },
                values: new object[] { new DateTime(2023, 5, 12, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1705), 2 });

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MemberId" },
                values: new object[] { new DateTime(2023, 5, 17, 18, 27, 29, 503, DateTimeKind.Local).AddTicks(1707), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroup_MemberId",
                table: "UsersGroup",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroup_Users_MemberId",
                table: "UsersGroup",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroup_Users_MemberId",
                table: "UsersGroup");

            migrationBuilder.DropIndex(
                name: "IX_UsersGroup_MemberId",
                table: "UsersGroup");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "UsersGroup");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UsersGroup",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UsersGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 6, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 11, 15, 6, 51, 268, DateTimeKind.Local).AddTicks(9775));
        }
    }
}

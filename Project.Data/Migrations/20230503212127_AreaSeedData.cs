using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class AreaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "UserImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Areas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "e0eaf2c1-63ee-4be2-8378-da60a761cbba");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "da61b2ee-f07d-4787-92e5-9806433bba26", "AQAAAAEAACcQAAAAEE6upT1YhReR0M+/xPvnvl5z82xDWkJ1rTRLbOjuccDpWqZwy/gze1bGKeTUvNIbjA==" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "CD01", "Area 1" });

            migrationBuilder.InsertData(
                table: "AreaUsers",
                columns: new[] { "AreaId", "UserId" },
                values: new object[] { 1, new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AreaUsers",
                keyColumns: new[] { "AreaId", "UserId" },
                keyValues: new object[] { 1, new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec") });

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "UserImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Areas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "d0d8f06a-dfd1-490f-9431-1b8d5eb3f775");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e2ec18c-ba4d-451e-b0da-d3a0bdfb306b", "AQAAAAEAACcQAAAAEKQsDgQmMuHLgVHbtmhDKViSCwGoi9GLFItvq/7bebCX/3cyxU5tvIL3kfEkjTjTBA==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurePlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "TypeUser",
                table: "Plans",
                newName: "Purpose");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "Plans",
                newName: "Calendar");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "52119035-c737-40f5-8733-f154478feb7a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4180b159-bcc7-447e-b35f-6d929423b81a", "AQAAAAEAACcQAAAAEKNVccZq7Bj2h/FSk+AwijIiWQma7So5dIgJ8/vAAgX3w4WlTG1GBaqu0orVGt00MQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "Plans",
                newName: "TypeUser");

            migrationBuilder.RenameColumn(
                name: "Calendar",
                table: "Plans",
                newName: "FromDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Plans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
        }
    }
}

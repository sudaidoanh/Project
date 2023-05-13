using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurePlanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "0c3c73d4-437e-4fe9-9dc9-ea53a6c6847b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1bf55ef-0afa-4c89-9fac-d4293ae4ff20", "AQAAAAEAACcQAAAAELSY9WmPwtqY+Uf25gRmPx6NF0gILOwQn6IaYBA7ehDNDc0xDmdm2oiFT8HTpHmqxA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

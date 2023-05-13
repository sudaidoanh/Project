using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurePlanTabless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AppUsers_Invited",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_Invited",
                table: "Plans");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "d44767f1-80f0-4f57-8787-90319b17ae1c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2f4893e-fd74-428c-9edf-692a66e15fb0", "AQAAAAEAACcQAAAAEJHJm7cIzkWD3mPpeUTYsNqfwb/8NjCbFBx9/hOEoOBCfX1BQ4Jbo5ISMgmgDKSJmQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_AppUserId",
                table: "Plans",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AppUsers_AppUserId",
                table: "Plans",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AppUsers_AppUserId",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_AppUserId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Plans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                columns: new[] { "Id", "UserId", "DistributorId", "Invited" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Invited",
                table: "Plans",
                column: "Invited");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AppUsers_Invited",
                table: "Plans",
                column: "Invited",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

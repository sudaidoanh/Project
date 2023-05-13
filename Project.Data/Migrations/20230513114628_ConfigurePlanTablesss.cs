using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurePlanTablesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AppUsers_AppUserId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_AppUserId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Plans");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "ef26fb4f-9c7a-42d0-a851-d18a603377f4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d9ac21e-9d19-49c3-a7bd-be5dad6d3394", "AQAAAAEAACcQAAAAELTqndeCFgXRdPicva1Svv2kwoh1Cyf1cwTfbPGZwunpHNFEwfVVgA2iHzh4OY1oeA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}

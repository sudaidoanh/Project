using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CurrentSet = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => new { x.Id, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserImages_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "5fd14ae5-4155-4cb1-88af-a0b2e2829186");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c78488c2-0456-4424-a783-d7484bdca7f6", "AQAAAAEAACcQAAAAEBbOCkssu8UuDOMt4s6mE9e2HuNm3uIVlwjRixJhybQkfT0UfkcqtFuRl5xRUuAjVA==" });
        }
    }
}

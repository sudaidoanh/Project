using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class configureSurveyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "Surveyeds");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "SubmitedSurveyeds");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 11, 8, 30, 43, DateTimeKind.Local).AddTicks(9859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 2, 13, 6, 204, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Surveyeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PerformerName",
                table: "Surveyeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SubmitedSurveyeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("240e615a-2fa4-468a-8728-c3c9c7d3db58"),
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "63eb8f8c-b6b9-42db-8897-155a6d2c051e", "Guest" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "a1edd061-2fc6-43f5-8c0b-5f2609d391f9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bed15c1f-b73a-4301-97b8-65fb4f54d1a0"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "5b33eeb3-b024-4f9d-a11e-96bc07a0d3c0", "Owner" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d80c014-4959-4d4d-b699-8c10192afc15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b657f26b-4c52-4cbf-ba69-5f9ebee90845", "AQAAAAEAACcQAAAAECVluZ2YawDaeecrIRvmLBBtCNLG1wtbGjK5r0/fr3ak7WlIUf1a80XpidFD1zaRxA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "962f95d2-3855-4ea8-903e-912f4c9991fe", "AQAAAAEAACcQAAAAENRX7fzgAtIs9oAY7v+jEaOLImHrpRaV1SGNzxvAqEmvCy49E1gD2aPFjF96jXJz7Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("deabd869-b037-48f5-9201-052f23f01ca8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60ef324d-452d-4555-a6a0-b26ba197dd7e", "AQAAAAEAACcQAAAAEK274qmAgxGg75IC/zt1MgcFawbiIP5gEbNx8Vpo9HL+7OhTjfMgL0b/AC0Oc7J0Ow==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Surveyeds");

            migrationBuilder.DropColumn(
                name: "PerformerName",
                table: "Surveyeds");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SubmitedSurveyeds");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 2, 13, 6, 204, DateTimeKind.Local).AddTicks(4319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 11, 8, 30, 43, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.AddColumn<Guid>(
                name: "PerformerId",
                table: "Surveyeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PerformerId",
                table: "SubmitedSurveyeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("240e615a-2fa4-468a-8728-c3c9c7d3db58"),
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "be32ed3d-10c5-432b-85eb-899044816966", "Owner" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "1118e349-dffd-4d06-8e60-ce31f381a50c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bed15c1f-b73a-4301-97b8-65fb4f54d1a0"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "00b8c66e-263b-47bc-8930-c06f8cc618ef", "Adminstrator" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d80c014-4959-4d4d-b699-8c10192afc15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dee5a0b2-0faf-41cc-81b8-daf9aca0ffba", "AQAAAAEAACcQAAAAEJ7+SZnp8DFHatizhNqwO0c3bcxWfCH5Hf2gr5jYAaEXGr7NekbTQdod9ViAuq5GqA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "064cd95c-9f13-45af-a914-48521d9d8213", "AQAAAAEAACcQAAAAEIx+W8G2ANN7i3RGNFoexEZlAqiGfEw15m5hmzMVcKXGKtMXfHunXf/mFscLV5S2+Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("deabd869-b037-48f5-9201-052f23f01ca8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "328e36ac-98b0-4e71-bbe0-e74c0f8c2bad", "AQAAAAEAACcQAAAAEEbU6Vy1RPkhkUH9V+iymp0gGm1B6Vmict8mMIbAdircCkWIEAEfUoz0OKAn2TS1wg==" });
        }
    }
}

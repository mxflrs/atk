using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atk_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStyleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Styles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Styles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Styles",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Styles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Styles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Styles",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}

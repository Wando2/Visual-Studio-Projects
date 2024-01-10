using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 9, 11, 13, 1, 454, DateTimeKind.Utc).AddTicks(4951),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 9, 11, 13, 1, 454, DateTimeKind.Utc).AddTicks(4508),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1246));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1843),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 9, 11, 13, 1, 454, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1246),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 9, 11, 13, 1, 454, DateTimeKind.Utc).AddTicks(4508));
        }
    }
}

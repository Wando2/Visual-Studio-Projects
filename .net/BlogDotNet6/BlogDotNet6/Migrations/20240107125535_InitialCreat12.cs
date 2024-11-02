using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1843),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 7, 12, 15, 3, 600, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1246),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 7, 12, 15, 3, 600, DateTimeKind.Utc).AddTicks(8276));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 12, 15, 3, 600, DateTimeKind.Utc).AddTicks(9380),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 12, 15, 3, 600, DateTimeKind.Utc).AddTicks(8276),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 1, 7, 12, 55, 35, 224, DateTimeKind.Utc).AddTicks(1246));
        }
    }
}

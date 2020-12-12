using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Z01.Migrations
{
    public partial class addTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Teachers",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Subjects",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Slots",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Rooms",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "ClassGroups",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Activities",
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "ClassGroups");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityId",
                table: "Activities",
                type: "varchar(767)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}

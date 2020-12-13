using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Z01.Migrations
{
    public partial class addconcurencyhandlingwithsomenewideas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RowVersion",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(4000)",
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Activities",
                type: "varbinary(4000)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(long))
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }
    }
}

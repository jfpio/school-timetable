using Microsoft.EntityFrameworkCore.Migrations;

namespace Z01.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ClassGroup_ClassGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Slot_SlotId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Subject_SubjectId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Teacher_TeacherId",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassGroup",
                table: "ClassGroup");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Slot",
                newName: "Slots");

            migrationBuilder.RenameTable(
                name: "ClassGroup",
                newName: "ClassGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "SlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassGroups",
                table: "ClassGroups",
                column: "ClassGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ClassGroups_ClassGroupId",
                table: "Activities",
                column: "ClassGroupId",
                principalTable: "ClassGroups",
                principalColumn: "ClassGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Slots_SlotId",
                table: "Activities",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Subjects_SubjectId",
                table: "Activities",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Teachers_TeacherId",
                table: "Activities",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ClassGroups_ClassGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Slots_SlotId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Subjects_SubjectId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Teachers_TeacherId",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassGroups",
                table: "ClassGroups");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "Slot");

            migrationBuilder.RenameTable(
                name: "ClassGroups",
                newName: "ClassGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                table: "Slot",
                column: "SlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassGroup",
                table: "ClassGroup",
                column: "ClassGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ClassGroup_ClassGroupId",
                table: "Activities",
                column: "ClassGroupId",
                principalTable: "ClassGroup",
                principalColumn: "ClassGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Slot_SlotId",
                table: "Activities",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Subject_SubjectId",
                table: "Activities",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Teacher_TeacherId",
                table: "Activities",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

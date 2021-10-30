using Microsoft.EntityFrameworkCore.Migrations;

namespace assignments_api.Migrations
{
    public partial class initaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Assignments",
                newName: "IdType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Assignments",
                newName: "IdAssignment");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "TypeTaskId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TypeTaskId",
                table: "Assignments",
                column: "TypeTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Types_TypeTaskId",
                table: "Assignments",
                column: "TypeTaskId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Types_TypeTaskId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TypeTaskId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TypeTaskId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "IdType",
                table: "Assignments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "IdAssignment",
                table: "Assignments",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}

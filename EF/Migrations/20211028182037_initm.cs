using Microsoft.EntityFrameworkCore.Migrations;

namespace assignments_api.Migrations
{
    public partial class initm : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TypeId",
                table: "Assignments",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Types_TypeId",
                table: "Assignments",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Types_TypeId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TypeId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "IdType",
                table: "Assignments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "IdAssignment",
                table: "Assignments",
                newName: "Id");
        }
    }
}

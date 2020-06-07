using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo_Web.Migrations
{
    public partial class ChangeListOfTaskToListOfTaskGroupInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_UserId",
                table: "TaskGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskGroups_Users_UserId",
                table: "TaskGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskGroups_Users_UserId",
                table: "TaskGroups");

            migrationBuilder.DropIndex(
                name: "IX_TaskGroups_UserId",
                table: "TaskGroups");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

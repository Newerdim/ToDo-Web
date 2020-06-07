using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo_Web.Migrations
{
    public partial class ChangeRelationBetweenTaskTaskGroupAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskGroups_Users_UserId",
                table: "TaskGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskGroupModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskGroups_UserId",
                table: "TaskGroups");

            migrationBuilder.DropColumn(
                name: "TaskGroupModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskGroups");

            migrationBuilder.AddColumn<int>(
                name: "TaskGroupId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskGroupId",
                table: "Tasks",
                column: "TaskGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupId",
                table: "Tasks",
                column: "TaskGroupId",
                principalTable: "TaskGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskGroupId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskGroupId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskGroupModelId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskGroupModelId",
                table: "Tasks",
                column: "TaskGroupModelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupModelId",
                table: "Tasks",
                column: "TaskGroupModelId",
                principalTable: "TaskGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

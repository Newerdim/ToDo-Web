using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo_Web.Migrations
{
    public partial class ChangeRelationToUserTaskGroupTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TaskGroupId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TaskGroupModelId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskGroupModelId",
                table: "Tasks",
                column: "TaskGroupModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupModelId",
                table: "Tasks",
                column: "TaskGroupModelId",
                principalTable: "TaskGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskGroupModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskGroupModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskGroups");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskGroupId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskGroupId",
                table: "Tasks",
                column: "TaskGroupId");

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
    }
}

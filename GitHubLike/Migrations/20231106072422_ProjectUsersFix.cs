using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class ProjectUsersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModule_Project_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "ProjectModule_Project");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_Roles_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "RoleModule_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModule_User_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "UserModule_User");

            migrationBuilder.DropIndex(
                name: "IX_UserModule_User_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "UserModule_User");

            migrationBuilder.DropIndex(
                name: "IX_RoleModule_Roles_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "RoleModule_Roles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModule_Project_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "ProjectModule_Project");

            migrationBuilder.DropColumn(
                name: "ProjectUsersProjectId",
                table: "UserModule_User");

            migrationBuilder.DropColumn(
                name: "ProjectUsersRoleId",
                table: "UserModule_User");

            migrationBuilder.DropColumn(
                name: "ProjectUsersUserId",
                table: "UserModule_User");

            migrationBuilder.DropColumn(
                name: "ProjectUsersProjectId",
                table: "RoleModule_Roles");

            migrationBuilder.DropColumn(
                name: "ProjectUsersRoleId",
                table: "RoleModule_Roles");

            migrationBuilder.DropColumn(
                name: "ProjectUsersUserId",
                table: "RoleModule_Roles");

            migrationBuilder.DropColumn(
                name: "ProjectUsersProjectId",
                table: "ProjectModule_Project");

            migrationBuilder.DropColumn(
                name: "ProjectUsersRoleId",
                table: "ProjectModule_Project");

            migrationBuilder.DropColumn(
                name: "ProjectUsersUserId",
                table: "ProjectModule_Project");

            migrationBuilder.AddColumn<long>(
                name: "ProjectsId",
                table: "ProjectModule_ProjectUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RolesId",
                table: "ProjectModule_ProjectUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_ProjectUsers_ProjectsId",
                table: "ProjectModule_ProjectUsers",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_ProjectUsers_RolesId",
                table: "ProjectModule_ProjectUsers",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModule_ProjectUsers_ProjectModule_Project_ProjectsId",
                table: "ProjectModule_ProjectUsers",
                column: "ProjectsId",
                principalTable: "ProjectModule_Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModule_ProjectUsers_RoleModule_Roles_RolesId",
                table: "ProjectModule_ProjectUsers",
                column: "RolesId",
                principalTable: "RoleModule_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModule_ProjectUsers_UserModule_User_UserId",
                table: "ProjectModule_ProjectUsers",
                column: "UserId",
                principalTable: "UserModule_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModule_ProjectUsers_ProjectModule_Project_ProjectsId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModule_ProjectUsers_RoleModule_Roles_RolesId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModule_ProjectUsers_UserModule_User_UserId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModule_ProjectUsers_ProjectsId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModule_ProjectUsers_RolesId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersProjectId",
                table: "UserModule_User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersRoleId",
                table: "UserModule_User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersUserId",
                table: "UserModule_User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersProjectId",
                table: "RoleModule_Roles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersRoleId",
                table: "RoleModule_Roles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersUserId",
                table: "RoleModule_Roles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersProjectId",
                table: "ProjectModule_Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersRoleId",
                table: "ProjectModule_Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectUsersUserId",
                table: "ProjectModule_Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModule_User_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "UserModule_User",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_Roles_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "RoleModule_Roles",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_Project_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "ProjectModule_Project",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModule_Project_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "ProjectModule_Project",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" },
                principalTable: "ProjectModule_ProjectUsers",
                principalColumns: new[] { "UserId", "ProjectId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_Roles_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "RoleModule_Roles",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" },
                principalTable: "ProjectModule_ProjectUsers",
                principalColumns: new[] { "UserId", "ProjectId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserModule_User_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "UserModule_User",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" },
                principalTable: "ProjectModule_ProjectUsers",
                principalColumns: new[] { "UserId", "ProjectId", "RoleId" });
        }
    }
}

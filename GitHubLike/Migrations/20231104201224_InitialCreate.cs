using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectModule_ProjectUsers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModule_ProjectUsers", x => new { x.UserId, x.ProjectId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "WorkspaceModule_Workspace",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkspaceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceModule_Workspace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationModule_Organization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkspaceId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationModule_Organization_WorkspaceModule_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "WorkspaceModule_Workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModule_Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectUsersProjectId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectUsersRoleId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectUsersUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    WorkspaceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModule_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModule_Project_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                        columns: x => new { x.ProjectUsersUserId, x.ProjectUsersProjectId, x.ProjectUsersRoleId },
                        principalTable: "ProjectModule_ProjectUsers",
                        principalColumns: new[] { "UserId", "ProjectId", "RoleId" });
                    table.ForeignKey(
                        name: "FK_ProjectModule_Project_WorkspaceModule_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "WorkspaceModule_Workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserModule_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectUsersProjectId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectUsersRoleId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectUsersUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    WorkspaceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModule_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModule_User_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                        columns: x => new { x.ProjectUsersUserId, x.ProjectUsersProjectId, x.ProjectUsersRoleId },
                        principalTable: "ProjectModule_ProjectUsers",
                        principalColumns: new[] { "UserId", "ProjectId", "RoleId" });
                    table.ForeignKey(
                        name: "FK_UserModule_User_WorkspaceModule_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "WorkspaceModule_Workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerType",
                columns: table => new
                {
                    OwnerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProjectsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerType", x => x.OwnerTypeId);
                    table.ForeignKey(
                        name: "FK_OwnerType_ProjectModule_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "ProjectModule_Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleModule_Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Permissions = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    ProjectUsersProjectId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectUsersRoleId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectUsersUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModule_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModule_Roles_ProjectModule_ProjectUsers_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                        columns: x => new { x.ProjectUsersUserId, x.ProjectUsersProjectId, x.ProjectUsersRoleId },
                        principalTable: "ProjectModule_ProjectUsers",
                        principalColumns: new[] { "UserId", "ProjectId", "RoleId" });
                    table.ForeignKey(
                        name: "FK_RoleModule_Roles_UserModule_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserModule_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_Organization_WorkspaceId",
                table: "OrganizationModule_Organization",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerType_ProjectsId",
                table: "OwnerType",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_Project_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "ProjectModule_Project",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_Project_WorkspaceId",
                table: "ProjectModule_Project",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_Roles_CreatedById",
                table: "RoleModule_Roles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_Roles_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "RoleModule_Roles",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserModule_User_ProjectUsersUserId_ProjectUsersProjectId_ProjectUsersRoleId",
                table: "UserModule_User",
                columns: new[] { "ProjectUsersUserId", "ProjectUsersProjectId", "ProjectUsersRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserModule_User_WorkspaceId",
                table: "UserModule_User",
                column: "WorkspaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationModule_Organization");

            migrationBuilder.DropTable(
                name: "OwnerType");

            migrationBuilder.DropTable(
                name: "RoleModule_Roles");

            migrationBuilder.DropTable(
                name: "ProjectModule_Project");

            migrationBuilder.DropTable(
                name: "UserModule_User");

            migrationBuilder.DropTable(
                name: "ProjectModule_ProjectUsers");

            migrationBuilder.DropTable(
                name: "WorkspaceModule_Workspace");
        }
    }
}

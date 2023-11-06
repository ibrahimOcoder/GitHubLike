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
                name: "OrganizationModule_OrganizationRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationRoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_OrganizationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerType",
                columns: table => new
                {
                    OwnerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerType", x => x.OwnerTypeId);
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
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceModule_Workspace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModule_Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModule_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModule_Project_OwnerType_OwnerTypeId",
                        column: x => x.OwnerTypeId,
                        principalTable: "OwnerType",
                        principalColumn: "OwnerTypeId",
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    WorkspaceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModule_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModule_User_WorkspaceModule_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "WorkspaceModule_Workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationModule_Organization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    WorkspaceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationModule_Organization_UserModule_User_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "UserModule_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationModule_Organization_WorkspaceModule_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "WorkspaceModule_Workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModule_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModule_Roles_UserModule_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "UserModule_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationModule_OrganizationUsers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    OrgRoleId = table.Column<long>(type: "bigint", nullable: false),
                    AcceptedInvite = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_OrganizationUsers", x => new { x.UserId, x.OrganizationId, x.OrgRoleId });
                    table.ForeignKey(
                        name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_OrganizationRoles_OrgRoleId",
                        column: x => x.OrgRoleId,
                        principalTable: "OrganizationModule_OrganizationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "OrganizationModule_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationModule_OrganizationUsers_UserModule_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModule_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModule_ProjectUsers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    AcceptedInvite = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModule_ProjectUsers", x => new { x.UserId, x.ProjectId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ProjectModule_ProjectUsers_ProjectModule_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectModule_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModule_ProjectUsers_RoleModule_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModule_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModule_ProjectUsers_UserModule_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModule_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_Organization_OwnerUserId",
                table: "OrganizationModule_Organization",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_Organization_WorkspaceId",
                table: "OrganizationModule_Organization",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationId",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrgRoleId",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrgRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_Project_OwnerTypeId",
                table: "ProjectModule_Project",
                column: "OwnerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_ProjectUsers_ProjectId",
                table: "ProjectModule_ProjectUsers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModule_ProjectUsers_RoleId",
                table: "ProjectModule_ProjectUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_Roles_CreatedByUserId",
                table: "RoleModule_Roles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModule_User_WorkspaceId",
                table: "UserModule_User",
                column: "WorkspaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropTable(
                name: "ProjectModule_ProjectUsers");

            migrationBuilder.DropTable(
                name: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropTable(
                name: "OrganizationModule_Organization");

            migrationBuilder.DropTable(
                name: "ProjectModule_Project");

            migrationBuilder.DropTable(
                name: "RoleModule_Roles");

            migrationBuilder.DropTable(
                name: "OwnerType");

            migrationBuilder.DropTable(
                name: "UserModule_User");

            migrationBuilder.DropTable(
                name: "WorkspaceModule_Workspace");
        }
    }
}

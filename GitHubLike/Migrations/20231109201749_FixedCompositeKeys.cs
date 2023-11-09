using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class FixedCompositeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModule_ProjectUsers",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModule_ProjectUsers",
                table: "ProjectModule_ProjectUsers",
                columns: new[] { "UserId", "ProjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers",
                columns: new[] { "UserId", "OrganizationId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModule_ProjectUsers",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModule_ProjectUsers",
                table: "ProjectModule_ProjectUsers",
                columns: new[] { "UserId", "ProjectId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers",
                columns: new[] { "UserId", "OrganizationId", "OrgRoleId" });
        }
    }
}

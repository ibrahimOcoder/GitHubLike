using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationModule_OrganizationUsers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationRoleId = table.Column<long>(type: "bigint", nullable: false),
                    AcceptedInvite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_OrganizationUsers", x => new { x.UserId, x.OrganizationId, x.OrganizationRoleId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationModule_Organization_OrganizationModule_OrganizationUsers_OrganizationUsersUserId_OrganizationUsersOrganizationId~",
                table: "OrganizationModule_Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationModule_OrganizationRoles_OrganizationModule_OrganizationUsers_OrganizationUsersUserId_OrganizationUsersOrganizat~",
                table: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModule_User_OrganizationModule_OrganizationUsers_OrganizationUsersUserId_OrganizationUsersOrganizationId_OrganizationUse~",
                table: "UserModule_User");

            migrationBuilder.DropTable(
                name: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropIndex(
                name: "IX_UserModule_User_OrganizationUsersUserId_OrganizationUsersOrganizationId_OrganizationUsersOrganizationRoleId",
                table: "UserModule_User");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationModule_OrganizationRoles_OrganizationUsersUserId_OrganizationUsersOrganizationId_OrganizationUsersOrganizationRo~",
                table: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationModule_Organization_OrganizationUsersUserId_OrganizationUsersOrganizationId_OrganizationUsersOrganizationRoleId",
                table: "OrganizationModule_Organization");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersOrganizationId",
                table: "UserModule_User");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersOrganizationRoleId",
                table: "UserModule_User");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersUserId",
                table: "UserModule_User");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersOrganizationId",
                table: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersOrganizationRoleId",
                table: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersUserId",
                table: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersOrganizationId",
                table: "OrganizationModule_Organization");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersOrganizationRoleId",
                table: "OrganizationModule_Organization");

            migrationBuilder.DropColumn(
                name: "OrganizationUsersUserId",
                table: "OrganizationModule_Organization");
        }
    }
}

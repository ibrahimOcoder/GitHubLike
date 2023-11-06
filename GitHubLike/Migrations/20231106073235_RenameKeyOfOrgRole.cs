using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class RenameKeyOfOrgRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_OrganizationRoles_OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.RenameColumn(
                name: "OrganizationRoleId",
                table: "OrganizationModule_OrganizationRoles",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationRoleId",
                table: "OrganizationModule_OrganizationUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "OrgRoleId",
                table: "OrganizationModule_OrganizationUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers",
                columns: new[] { "UserId", "OrganizationId", "OrgRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationRoleId",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_OrganizationRoles_OrganizationRoleId",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationRoleId",
                principalTable: "OrganizationModule_OrganizationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_OrganizationRoles_OrganizationRoleId",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationRoleId",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.DropColumn(
                name: "OrgRoleId",
                table: "OrganizationModule_OrganizationUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrganizationModule_OrganizationRoles",
                newName: "OrganizationRoleId");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationRoleId",
                table: "OrganizationModule_OrganizationUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationModule_OrganizationUsers",
                table: "OrganizationModule_OrganizationUsers",
                columns: new[] { "UserId", "OrganizationId", "OrganizationRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationRoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_OrganizationRoles_OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationRoleId1",
                principalTable: "OrganizationModule_OrganizationRoles",
                principalColumn: "OrganizationRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

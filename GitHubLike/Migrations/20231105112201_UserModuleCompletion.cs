using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class UserModuleCompletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "OrganizationModule_Organization",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "OrganizationModule_OrganizationRoles",
                columns: table => new
                {
                    OrganizationRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationRoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_OrganizationRoles", x => x.OrganizationRoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_Organization_OwnerUserId",
                table: "OrganizationModule_Organization",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationModule_Organization_UserModule_User_OwnerUserId",
                table: "OrganizationModule_Organization",
                column: "OwnerUserId",
                principalTable: "UserModule_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationModule_Organization_UserModule_User_OwnerUserId",
                table: "OrganizationModule_Organization");

            migrationBuilder.DropTable(
                name: "OrganizationModule_OrganizationRoles");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationModule_Organization_OwnerUserId",
                table: "OrganizationModule_Organization");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "OrganizationModule_Organization");
        }
    }
}

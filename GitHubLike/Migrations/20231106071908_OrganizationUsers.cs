using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationUsers : Migration
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
                    OrganizationRoleId1 = table.Column<int>(type: "int", nullable: false),
                    AcceptedInvite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationModule_OrganizationUsers", x => new { x.UserId, x.OrganizationId, x.OrganizationRoleId });
                    table.ForeignKey(
                        name: "FK_OrganizationModule_OrganizationUsers_OrganizationModule_OrganizationRoles_OrganizationRoleId1",
                        column: x => x.OrganizationRoleId1,
                        principalTable: "OrganizationModule_OrganizationRoles",
                        principalColumn: "OrganizationRoleId",
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

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationId",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationModule_OrganizationUsers_OrganizationRoleId1",
                table: "OrganizationModule_OrganizationUsers",
                column: "OrganizationRoleId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationModule_OrganizationUsers");
        }
    }
}

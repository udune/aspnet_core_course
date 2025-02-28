﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCore_Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RolePriority = table.Column<byte>(type: "tinyint", nullable: false),
                    ModifiedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    IsMembershipWithdrawn = table.Column<bool>(type: "bit", nullable: false),
                    JoinedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesByUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    OwnedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesByUser", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRolesByUser_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolesByUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesByUser_RoleId",
                table: "UserRolesByUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRolesByUser");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class UserUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserUsers",
                columns: table => new
                {
                    ReaderId = table.Column<string>(nullable: false),
                    FollowerId = table.Column<string>(nullable: false),
                    SubscribedAt = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUsers", x => new { x.ReaderId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_UserUsers_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserUsers_AspNetUsers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUsers_FollowerId",
                table: "UserUsers",
                column: "FollowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUsers");
        }
    }
}

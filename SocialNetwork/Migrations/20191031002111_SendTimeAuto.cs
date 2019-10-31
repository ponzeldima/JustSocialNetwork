using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class SendTimeAuto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatingTime",
                table: "Conversations",
                nullable: false,
                computedColumnSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatingTime",
                table: "Conversations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "GETDATE()");
        }
    }
}

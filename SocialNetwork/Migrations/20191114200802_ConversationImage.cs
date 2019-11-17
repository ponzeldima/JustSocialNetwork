using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class ConversationImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Conversations");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Conversations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Images_ImageId",
                table: "Conversations",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Images_ImageId",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Conversations");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Conversations",
                nullable: true);
        }
    }
}

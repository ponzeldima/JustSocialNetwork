using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class ConversationIdInImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Images",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Images_ConversationId",
                table: "Images",
                column: "ConversationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Conversations_ConversationId",
                table: "Images",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Conversations_ConversationId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ConversationId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Conversations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Images_ImageId",
                table: "Conversations",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

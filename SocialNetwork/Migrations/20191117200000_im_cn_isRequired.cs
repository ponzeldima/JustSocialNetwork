using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class im_cn_isRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Conversations_ConversationId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ConversationId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId1",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ConversationId1",
                table: "Images",
                column: "ConversationId1",
                unique: true,
                filter: "[ConversationId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Conversations_ConversationId1",
                table: "Images",
                column: "ConversationId1",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Conversations_ConversationId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ConversationId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ConversationId1",
                table: "Images");

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
    }
}

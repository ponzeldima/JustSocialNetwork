using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class ImageConversation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations",
                column: "ImageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ImageId",
                table: "Conversations",
                column: "ImageId");
        }
    }
}

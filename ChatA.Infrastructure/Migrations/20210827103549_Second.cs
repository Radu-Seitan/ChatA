using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatA.Infrastructure.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMemberships_MessageRooms_GroupMessageRoomId",
                table: "GroupMemberships");

            migrationBuilder.DropIndex(
                name: "IX_GroupMemberships_GroupMessageRoomId",
                table: "GroupMemberships");

            migrationBuilder.DropColumn(
                name: "GroupMessageRoomId",
                table: "GroupMemberships");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberships_RoomId",
                table: "GroupMemberships",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMemberships_MessageRooms_RoomId",
                table: "GroupMemberships",
                column: "RoomId",
                principalTable: "MessageRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMemberships_MessageRooms_RoomId",
                table: "GroupMemberships");

            migrationBuilder.DropIndex(
                name: "IX_GroupMemberships_RoomId",
                table: "GroupMemberships");

            migrationBuilder.AddColumn<int>(
                name: "GroupMessageRoomId",
                table: "GroupMemberships",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberships_GroupMessageRoomId",
                table: "GroupMemberships",
                column: "GroupMessageRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMemberships_MessageRooms_GroupMessageRoomId",
                table: "GroupMemberships",
                column: "GroupMessageRoomId",
                principalTable: "MessageRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomMicroservice.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RoomNo = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    MaxNoOfCatsInRoom = table.Column<int>(nullable: false),
                    CheckedIn = table.Column<bool>(nullable: false),
                    CheckedOut = table.Column<bool>(nullable: false),
                    Booked = table.Column<bool>(nullable: true),
                    BookingStart = table.Column<DateTime>(nullable: true),
                    BookingEnd = table.Column<DateTime>(nullable: true),
                    Available = table.Column<bool>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

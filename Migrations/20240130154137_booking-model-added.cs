using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Booking_System_API.Migrations
{
    /// <inheritdoc />
    public partial class bookingmodeladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_eventsId",
                table: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_eventsId",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "eventsId",
                table: "Attendees",
                newName: "events_id");

            migrationBuilder.AddColumn<int>(
                name: "Ticket_Sold_Quantity",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ticket_no",
                table: "Attendees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticket_Sold_Quantity",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Ticket_no",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "events_id",
                table: "Attendees",
                newName: "eventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_eventsId",
                table: "Attendees",
                column: "eventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_eventsId",
                table: "Attendees",
                column: "eventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Booking_System_API.Migrations
{
    /// <inheritdoc />
    public partial class ticket_price_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ticket_Price",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticket_Price",
                table: "Events");
        }
    }
}

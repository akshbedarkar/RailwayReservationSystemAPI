using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class addpnr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PNRNumber",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PNRNumber",
                table: "Reservations");
        }
    }
}

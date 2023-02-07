using RailwayReservationSystem.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayReservationSystem.Models.DTO
{
    public class Ticket
    {
        public Guid TicketId { get; set; }

        [ForeignKey("Reservation")]

        public Guid ReservationId { get; set; }
        public Reservation reservation { get; set; }

        public Guid PnrNo { get; set; }

    }
}

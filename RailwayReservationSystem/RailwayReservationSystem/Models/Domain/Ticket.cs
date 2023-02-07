using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayReservationSystem.Models.Domain
{
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }

        [ForeignKey("Reservation")]

        public Guid ReservationId { get; set; }
        public Reservation reservation { get; set; }

        public Guid PnrNo { get; set; }


    }
}

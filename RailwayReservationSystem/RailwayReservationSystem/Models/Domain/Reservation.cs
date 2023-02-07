using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayReservationSystem.Models.Domain
{
    public class Reservation
    {
        [Key]
        public Guid ReservationId { get; set; }

        [Required]
        public string ReservationName { get; set; }

        [Required]
        public string ReservationGender { get;set; }

        [Required]
        public string ReservationAddress { get; set; }


        [Required]
        public DateTime ReservationDate { get; set; }


        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
      

        [ForeignKey("Quota")]
        public Guid QuotaId { get; set; }
        public Quota quota { get; set; }         

        [ForeignKey("TrainDetails")]

        public Guid TrainId { get; set; }
        public TrainDetails TrainDetails { get; set; }









      



    }
}

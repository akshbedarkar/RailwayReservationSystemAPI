using RailwayReservationSystem.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayReservationSystem.Models.DTO
{
    public class Reservations
    {
 
        public Guid ReservationId { get; set; }

        public string ReservationName { get; set; }

        public string PNRNumber { get; set; }


        public string ReservationGender { get; set; }

    
        public string ReservationAddress { get; set; }


       
        public DateTime ReservationDate { get; set; }


        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }


       
        public string Quota { get; set; }

      

        public string TrainName { get; set; }
        
    }
}

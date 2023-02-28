using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayReservationSystem.Models.DTO
{
    public class AddReservationRequest
    {
       
        public string ReservationName { get; set; }

        


        public string ReservationGender { get; set; }


        public string ReservationAddress { get; set; }



        public DateTime ReservationDate { get; set; }

       
        public Guid UserId { get; set; }
       
      
        public string Quota { get; set; }
      
   
        public string TrainName { get; set; }
      
    }
}

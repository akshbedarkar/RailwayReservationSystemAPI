using System.ComponentModel.DataAnnotations;

namespace RailwayReservationSystem.Models.DTO
{
    public class TrainDetails
    {
        
        public Guid TrainId { get; set; }

       
        public string TrainName { get; set; }

        
        public string SourceStation { get; set; }

       
        public string DestinationStation { get; set; }

        
        public DateTime SourceDateTime { get; set; }

        
        public DateTime DestinationDateTime { get; set; }


    }
}

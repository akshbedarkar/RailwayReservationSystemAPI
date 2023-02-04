using System.ComponentModel.DataAnnotations;

namespace RailwayReservationSystem.Models.DTO
{
    public class TrainDetails
    {
        public Guid TrainId { get; set; }

        [Required]
        public string TrainName { get; set; }

        [Required]
        public string SourceStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public DateTime SourceDateTime { get; set; }

        [Required]
        public DateTime DestinationDateTime { get; set; }


    }
}

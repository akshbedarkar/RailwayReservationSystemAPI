using System.ComponentModel.DataAnnotations;

namespace RailwayReservationSystem.Models.DTO
{
    public class Addtrainrequest
    {

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

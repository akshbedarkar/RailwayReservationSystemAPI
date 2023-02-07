using System.ComponentModel.DataAnnotations;

namespace RailwayReservationSystem.Models.Domain
{
    public class Quota
    {
        [Key]
        public Guid QuotaId { get; set; }

        public string QuotaName { get; set;}

        public int Fare { get; set; }


    }
}

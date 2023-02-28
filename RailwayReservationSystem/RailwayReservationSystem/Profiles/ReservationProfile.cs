using AutoMapper;

namespace RailwayReservationSystem.Profiles
{
    public class ReservationProfile:Profile
    {
        public ReservationProfile()
        {
            CreateMap<Models.Domain.Reservation, Models.DTO.Reservations>().ReverseMap();


            CreateMap<Models.Domain.User, Models.DTO.User>().ReverseMap();




            CreateMap<Models.Domain.TrainDetails, Models.DTO.TrainDetails>().ReverseMap();
        }
    }
}

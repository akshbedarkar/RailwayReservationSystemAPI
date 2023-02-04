using AutoMapper;

namespace RailwayReservationSystem.Profiles
{
    public class TrainDetailsProfile : Profile
    {
        public TrainDetailsProfile()
        {
            CreateMap<Models.Domain.TrainDetails, Models.DTO.TrainDetails>().ReverseMap();
        }

    }
}

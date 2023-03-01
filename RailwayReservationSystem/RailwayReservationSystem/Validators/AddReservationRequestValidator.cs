using FluentValidation;
using RailwayReservationSystem.Models.DTO;

namespace RailwayReservationSystem.Validators
{
    public class AddReservationRequestValidator:AbstractValidator<AddReservationRequest>
    {
        //This Validator will be Validating the data entered by user for reservation
        public AddReservationRequestValidator()
        {
            

            RuleFor(x => x.ReservationName).NotEmpty();
            RuleFor(x=>x.ReservationGender).NotEmpty();
            RuleFor(x=>x.ReservationDate).NotEmpty();
            RuleFor(x=>x.ReservationAddress).NotEmpty();
            
            
        }
    }
}

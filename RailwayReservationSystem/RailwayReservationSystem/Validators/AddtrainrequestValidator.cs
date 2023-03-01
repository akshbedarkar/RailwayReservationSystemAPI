using FluentValidation;
using RailwayReservationSystem.Models.DTO;

namespace RailwayReservationSystem.Validators
{
    public class AddtrainrequestValidator:AbstractValidator<Addtrainrequest>
    {
        //this Validator will be Validating the data entered by admin for Crud operations related to train

        public AddtrainrequestValidator()
        {

            RuleFor(x => x.TrainName).NotEmpty();
            RuleFor(x=>x.SourceDateTime).NotEmpty();
            RuleFor(x => x.DestinationDateTime).NotEmpty();
            RuleFor(x=>x.SourceStation).NotEmpty();
            RuleFor(x => x.DestinationStation).NotEmpty();

        }
    }
}

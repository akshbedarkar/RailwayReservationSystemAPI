using FluentValidation;
using RailwayReservationSystem.Models.DTO;

namespace RailwayReservationSystem.Validators
{
    public class UserSignUpRequestValidator:AbstractValidator<UserSignUpRequest>
    {
        //This Validator will be Validating the user Credentials entered during SignUp and Login
        public UserSignUpRequestValidator()
        {
            /*condition to pass :  Message is necessary 
             * firstname,lastname -required/notnull/notwhitespace 
             * gender -required 
             * email -required 
             * password is required 
             */

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required");
            RuleFor(x=>x.Gender).NotEmpty().WithMessage("Gender is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");


        }


    }
}

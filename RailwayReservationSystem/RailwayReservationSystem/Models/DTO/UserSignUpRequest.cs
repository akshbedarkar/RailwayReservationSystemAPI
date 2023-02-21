﻿using System.ComponentModel.DataAnnotations;

namespace RailwayReservationSystem.Models.DTO
{
    public class UserSignUpRequest
    {
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

   
        public string Gender { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

﻿namespace RailwayReservationSystem.Models.DTO
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

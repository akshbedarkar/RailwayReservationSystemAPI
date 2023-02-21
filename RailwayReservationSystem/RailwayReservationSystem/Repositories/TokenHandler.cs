using Microsoft.IdentityModel.Tokens;
using RailwayReservationSystem.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RailwayReservationSystem.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> GenrateToken(User u)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName,u.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, u.LastName));
            claims.Add(new Claim(ClaimTypes.Email, u.Email));
            claims.Add(new Claim(ClaimTypes.Role, u.Role));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials

                );


            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}

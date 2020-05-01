using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.mis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Api.Dto;
//using WebApi.Entities;
//using WebApi.Helpers;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly misContext _context;
        public UserService(misContext context)
        {
            _context = context;
        }

        public User getUserById(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public UserDto Authenticate(string username, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sdjksjfkljasdoiqjojoiajdou3894729839  92347 1 1-3182 3ijo1j 1ojlmcls");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    //new Claim(ClaimTypes.Role,)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username
            };
            userDto.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return userDto;
        }
    }
}

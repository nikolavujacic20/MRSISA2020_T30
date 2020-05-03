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
        public IEmailSender _emailSender;
        public UserService(misContext context,IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _context = context;
        }

        public User getUserById(int id)
        {
           /* return*/ var zmaj= _context.User.FirstOrDefault(x => x.Id == id);
            //zmaj.Ime = "zmaj";
            //_context.SaveChanges();
            return zmaj;
        }


        public UserDto Register(UserDto user)
        {

            if (user.Ime.Length <= 3)
                return null;

            if (user.Prezime.Length <= 3)
                return null;

            if (user.Username.Length <= 3)
                return null;

            if (user.Password.Length <= 3)
                return null;

            var userBase = _context.User.Where(x => x.Username == user.Username).FirstOrDefault();


            if (userBase != null)
                return null;
            Guid g = Guid.NewGuid();


            var newUser = new User
            {
                Aktivan = 1,
                Prezime = user.Prezime,
                Ime = user.Ime,
                Username = user.Username,
                Password = user.Password,
                Email = "nikolavujacic20@gmail.com",
                Adresa=user.Adresa,
                Grad=user.Grad,
                Drzava = user.Drzava,
                Lbo = "123",
                Telefon = user.Telefon,
                AktivacioniToken = Convert.ToBase64String(g.ToByteArray())
               
        };
            
            _context.User.Add(newUser);
         
            _context.SaveChanges();

            newUser.UserRole = new List<UserRole>();
                newUser.UserRole.Add(new UserRole{ UserId = newUser.Id, RoleId = 3 });
            _context.SaveChanges();

            _emailSender.SendEmailAsync("nikolavujacic20@gmail.com", "123", "Radi");



            var newUserDto = new UserDto
            {
                Aktivan = 1,
                Prezime = newUser.Prezime,
                Ime = newUser.Ime,
                Username = newUser.Username,
                Password = newUser.Password,
                Id = newUser.Id,
            };


            return newUserDto;

        }



                
        public UserDto Authenticate(string username, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.Username == username && x.Password == password&&x.Aktivan==1);
            var roles = _context.UserRole.Where(x => x.UserId == user.Id).Select(x => new RoleDto 
            {
                Id = x.RoleId,
                Uloga = x.Role.Uloga
            });
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-79b265ebf256");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, string.Join(",", roles.Select(x => x.Uloga)))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Ime = user.Ime,
                Prezime = user.Prezime,
                Aktivan = user.Aktivan,
                Role = roles.Select(x => x.Uloga).ToList()
            };
            userDto.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return userDto;
        }
    }
}

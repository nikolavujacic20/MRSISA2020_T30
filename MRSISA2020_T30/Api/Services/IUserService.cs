using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.mis;
using Api.Dto;

namespace Api.Services
{
    public interface IUserService
    {
        User getUserById(int id);

        UserDto Authenticate(string username, string password);

        UserDto Register(UserDto user);

        bool Activate(string code);
    }
}

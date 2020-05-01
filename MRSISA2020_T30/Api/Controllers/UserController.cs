using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Api.mis;
using Api.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class UserController : ControllerBase
    {
        protected IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("api/user/{id}")]
        public User GetById(int id)
        {
            return _userService.getUserById(id);
        }

        //[HttpPost("api/user")]
        //public User GetByPostId([FromForm] Zmaj hey)
        //{
        //    return _userService.getUserById(hey.Id);
        //}

        [AllowAnonymous]
        [HttpPost("api/user/authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


    }

    public class Zmaj
    {
        public int Id { get; set; }
    }
}
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
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        protected IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public User GetById(int id)
        {
            if (Convert.ToInt32(HttpContext.User.Identity.Name) == id)
                //var let = HttpContext.User;
            return _userService.getUserById(id);
            return null;
        }

       

        //[AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userParam)
        {

            var user = _userService.Register(userParam);

            if (user == null)
                return BadRequest(new { message = "Registration is invalid" });

            return Ok(user);



        }

        [HttpGet("activate")]
        public IActionResult Activate([FromQuery] string code)
        {
            var completed = _userService.Activate(code);

            if (completed)
                return BadRequest(new { message = "Aktivacija nije uspesna, kontaktirajte administratora." });

            return Ok("Aktivacija uspesna");
        }

    }


}
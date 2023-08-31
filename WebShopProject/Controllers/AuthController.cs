using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using WebShopProject.Data.Domain.Repositories.Abstract;
using WebShopProject.Dtos;
using WebShopProject.Models;
using WebShopProject.Services;

namespace WebShopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        public AuthController(IUserRepository repository, JwtService jwtService) 
        {
            _userRepository = repository;
            _jwtService = jwtService;
        }


        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_userRepository.GetByLogin(dto.Login) != null) return BadRequest(new { message = "The user already exists" });
            var user = new User
            {
                Login = dto.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                RegisterDate = DateTime.UtcNow
            };
            
            return Created("Success", _userRepository.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userRepository.GetByLogin(dto.Login);
            if (user == null) return BadRequest(new {message = "Invalid Credentials"});

            if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "Success"
            });
        }

        [HttpGet("user")]
        
        public IActionResult GetUser()
        {
            var all = Request.Cookies.Keys.ToList();
            try
            {
                string jwt = Request.Cookies["jwt"];

                if (jwt == null)
                {
                    StringValues temp;
                    if(Request.Headers.TryGetValue("jwt", out temp))
                    {
                        jwt = temp.FirstOrDefault();
                    }
                    

                    //if (Request.Headers.Contains("jwt"))  //OK
                        //jwt = Request.Headers["jwt"];
                }

                var token = _jwtService.Varify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _userRepository.GetById(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "Success"
            });
        }
    }
}

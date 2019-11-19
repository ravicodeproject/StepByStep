using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.EmployeeExists(userForRegisterDto.Username))
                return BadRequest("Employee already exists");

            var userToCreate = new Employee
            {
                Username = userForRegisterDto.Username,
                Efirstname = userForRegisterDto.Efirstname,
                Elastname = userForRegisterDto.Elastname,
                Eage = userForRegisterDto.Eage,
                Egender = userForRegisterDto.Egender,
                Edateofbirth = userForRegisterDto.Edateofbirth,
                Eemail = userForRegisterDto.Eemail,
                Elanguages = userForRegisterDto.Elanguages,
                Eskills = userForRegisterDto.Eskills,
                Ereligion = userForRegisterDto.Ereligion,
                Enationality = userForRegisterDto.Enationality,
                Ecaste = userForRegisterDto.Ecaste
            };

            var createdEmployee = await _repo.Register(userToCreate, userForRegisterDto.password);

            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
           // throw new Exception("Login failed");

            var userFromRepo = await _repo.Login(userForLoginDto.username.ToLower(), userForLoginDto.password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Eid.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
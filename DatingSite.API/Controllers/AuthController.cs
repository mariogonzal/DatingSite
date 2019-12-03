using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Dto;
using DatingSite.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _conig;
        public AuthController(IAuthRepository repo, IConfiguration conig)
        {
            this._conig = conig;
            this._repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //TODO validate Request            
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (string.IsNullOrEmpty(userForRegisterDto.UserName) || string.IsNullOrEmpty(userForRegisterDto.Password))
                return BadRequest("empty username or password data in request");
            if (await _repo.UserExist(userForRegisterDto.UserName))
                return BadRequest("User already exist");
            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
             if (!ModelState.IsValid)
                return BadRequest();
            
            var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.UserName.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conig.GetSection("AppSettings:Token").Value));

            var creds= new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptior= new SecurityTokenDescriptor()
            {
                Subject= new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials=creds

            };

            var tokenHandler=new JwtSecurityTokenHandler();

            var token= tokenHandler.CreateToken(tokenDescriptior);

            return Ok(new {
                token= tokenHandler.WriteToken(token)
            });



        }


    }
}
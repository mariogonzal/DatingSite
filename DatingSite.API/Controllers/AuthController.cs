using System.Threading.Tasks;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Dto;
using DatingSite.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //TODO validate Request
            userForRegisterDto.UserName=userForRegisterDto.UserName.ToLower();
            if(await _repo.UserExist(userForRegisterDto.UserName))
                return BadRequest("User already exist");
            var userToCreate= new User
            {
                 UserName=userForRegisterDto.UserName
            };

            var createdUser=await _repo.Register(userToCreate,userForRegisterDto.Password);
            
            return StatusCode(201);
        }


    }
}
using System.Threading.Tasks;
using DatingSite.API.Data;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingSite.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repo;

        public UserController(IRepository<User> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.List();
            return Ok(users);
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.Find(id);
            return Ok(user);
        }
    }
}
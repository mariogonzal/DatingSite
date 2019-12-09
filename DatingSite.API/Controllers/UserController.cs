using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingSite.API.Data;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Dto;
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
        private readonly IMapper _mapper;

        public UserController( IRepository<User> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.List();
            var userList=_mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.Find(id);
            var userToReturn=_mapper.Map<UserForDetailDto>(user);
            return Ok(userToReturn);
        }
    }
}
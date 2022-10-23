using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SeedAPI.Data;
using SeedAPI.Services;

namespace SeedAPI.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : Controller
    {
        // private IUserMap _userMap;
        private IMongoCollection<Shipwreck> _shipWreckCollection;
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET api/user/getUsers
        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetAsync();
        }
        
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST api/user/create
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }
        
        // PUT api/user/update
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUserByIdAsync(user);
            return NoContent();
        }
        
        // DELETE api/user/delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
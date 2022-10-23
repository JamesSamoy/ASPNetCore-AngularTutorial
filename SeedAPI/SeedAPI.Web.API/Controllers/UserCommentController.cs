using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeedAPI.Data;
using SeedAPI.Services;

namespace SeedAPI.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserCommentController : Controller
    {
        private IUserCommentService _userCommentService;

        public UserCommentController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }
        
        [HttpGet("GetUserComments")]
        public async Task<List<UserComment>> GetUsers()
        {
            return await _userCommentService.GetAsync();
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserComment([FromBody] UserComment comment)
        {
            await _userCommentService.CreateAsync(comment);
            return CreatedAtAction(nameof(CreateUserComment), new { id = comment.Id }, comment);
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserComment([FromBody] UserComment comment)
        {
            await _userCommentService.UpdateCommentByIdAsync(comment);
            return NoContent();
        }
        
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUserComment(string id)
        {
            await _userCommentService.DeleteComment(id);
            return NoContent();
        }
    }
}
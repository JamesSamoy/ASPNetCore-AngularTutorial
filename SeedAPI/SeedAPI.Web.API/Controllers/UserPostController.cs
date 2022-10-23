using System.Collections.Generic;
using System.Linq;
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
    public class UserPostController : Controller
    {
        private IUserPostService _userPostService;

        public UserPostController(IUserPostService userPostService)
        {
            _userPostService = userPostService;
        }
        
        [HttpGet("GetUserPosts")]
        public async Task<List<UserPost>> GetUserPosts()
        {
            return await _userPostService.GetAsync();
        }
        
        [HttpGet("GetTopics")]
        public async Task<List<string>> GetTopics()
        {
            var posts = await _userPostService.GetAsync();
            return posts.Select(x => x.Type).ToList();
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserPost([FromBody] UserPost post)
        {
            await _userPostService.CreateAsync(post);
            return CreatedAtAction(nameof(CreateUserPost), new { id = post.Id }, post);
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserPost([FromBody] UserPost post)
        {
            await _userPostService.UpdateUserPostByIdAsync(post);
            return NoContent();
        }
        
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUserPost(string id)
        {
            await _userPostService.DeleteUserPost(id);
            return NoContent();
        }
    }
}
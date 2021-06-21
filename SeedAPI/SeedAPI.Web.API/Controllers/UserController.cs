using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeedAPI.Maps;
using SeedAPI.ViewModels;

namespace SeedAPI.Web.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private IUserMap _userMap;

        public UserController(IUserMap userMap)
        {
            _userMap = userMap;
        }
        
        // GET api/user
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _userMap.GetAll();
        }
        
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST api/user
        [HttpPost]
        public void Post([FromBody] string user)
        {
        }
        
        // PUT api/user/5
        [HttpPut]
        public void Put(int id, [FromBody] string user)
        {
        }
        
        // DELETE api/user/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
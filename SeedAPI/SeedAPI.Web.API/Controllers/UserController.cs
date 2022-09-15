using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SeedAPI.Data;

namespace SeedAPI.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : Controller
    {
        // private IUserMap _userMap;
        private IMongoCollection<Shipwreck> _shipWreckCollection;

        public UserController(IMongoClient client)
        {
            // _userMap = userMap;
            var database = client.GetDatabase("sample_geospatial");
            _shipWreckCollection = database.GetCollection<Shipwreck>("shipwrecks");
        }
        
        // GET api/user
        [HttpGet]
        public IEnumerable<Shipwreck> Get()
        {
            return _shipWreckCollection.Find(s => s.FeatureType == "Wrecks - Visible").ToList();
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
using System;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SeedAPI.Data
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Age { get; set; }
        
        public string Occupation { get; set; }
        
        // profileImage ? find out type
        
        public int NumberOfPosts { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        public DateTime JoiningDate { get; set; }
        
        public string Session { get; set; }
    }
}